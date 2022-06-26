import { ToDateFormatValueConverter } from "value-converters/to-date-format";
import { getLogger } from "aurelia-logging";
import { Notyf } from "notyf";

type IMethodDecorator<T> = (target: T, propertyKey: string, descriptor: PropertyDescriptor) => void;

const dateFormatter = new ToDateFormatValueConverter();
const userFormattedFriendlyError = (friendlyError: string) =>
{
  return `${ friendlyError }
		<div class="float-left mr-4 dir-ltr text-left text-red-300">
			<sub class="text-2xs whitespace-nowrap">${ dateFormatter.toView(new Date(), "HH:mm:ss") }</sub>
		</div>`;
};

const logger = getLogger("handleErrors");
function displayError(friendlyError: string, realError?: unknown): void
{
  const notyfInstance = new Notyf({
    duration: 0, // 0 is infinite. was: 5 * second
    dismissible: true
  });

  if (realError instanceof Response)
  {
    realError
      .text()
      .then(bodyAsText =>
      {
        try { return JSON.parse(bodyAsText); }
        catch { return bodyAsText; }
      })
      .then(errorObj =>
      {
        let errorsArray = [friendlyError];
        if (realError.status === 400 && errorObj.modelState)
        {
          errorsArray = errorsArray.concat(...Object.values(errorObj.modelState) as string[]);
        }

        notyfInstance.error(errorsArray.join("<br>"));
        logger.error(friendlyError, realError.status, errorObj);
      });
  }
  else
  {
    notyfInstance.error(userFormattedFriendlyError(friendlyError));
    logger.error(friendlyError, realError);
  }
}

export function handleErrors<T>(friendlyError: string): IMethodDecorator<T>
{
  return function (_target: T, propertyKey: string, descriptor: PropertyDescriptor)
  {
    const givenFunc = descriptor.value;
    if (typeof givenFunc !== "function")
    {
      throw Error(`'handleErrors' Decorator should be used on functions only! you used it on [${ propertyKey }]`);
    }

    descriptor.value = function (...params: unknown[])
    {
      try
      {
        const retVal: unknown = givenFunc.call(this, ...params);
        if (retVal instanceof Promise)
        {
          return retVal.catch(e => displayError(friendlyError, e));
        }
        return retVal;
      }
      catch (e)
      {
        displayError(friendlyError, e);
      }
    };
  };
}
