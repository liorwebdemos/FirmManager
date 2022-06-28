// https://stackoverflow.com/a/196991

export class ToTitleCaseValueConverter
{
  toView(str: string): string
  {
    if (str == null) return ""; // double equal for null/undefined
    return str.replace(
      /\w\S*/g,
      txt => txt.charAt(0).toUpperCase() + txt.substr(1).toLowerCase()
    );
  }
}
