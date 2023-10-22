namespace Lib.Chapter2;

public class Date : IComparable<Date> {

  public int Day {get; init;}
  public int Month {get; init;}
  public int Year {get; init;}

  public int CompareTo(Date? other) {
    // order matters here
    // ex: 10/23/84 10/24/83
    // year needs checked before month, then day 
    if (other is null) {
      throw new Exception("Date.CompareTo() accepted a null ref");
    }
    if (Year < other.Year) {return -1;} 
    if (Year > other.Year) {return 1;}     
    if (Month < other.Month) {return -1;} 
    if (Month > other.Month) {return 1;} 
    if (Day < other.Day) {return -1;} 
    if (Day > other.Day) {return 1;} 
    return 0;
  }

  override public string ToString() {
    return $"{Month}/{Day}/{Year}";
  }


}