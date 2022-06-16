export class ToFormattedNumberValueConverter
{
  toView(value: number): string
  {
    if (value == null) return ""; // double equal for null/undefined
    return (+value).toLocaleString("he-IL");
  }
}
