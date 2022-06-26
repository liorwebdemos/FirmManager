import format from "date-fns/format";

export class ToDateFormatValueConverter
{
  toView(value: Date, toFormat = "dd/MM/yyyy"): string
  {
    if (!(value instanceof Date) || !value?.getTime()) return;
    return format(value, toFormat);
  }
}
