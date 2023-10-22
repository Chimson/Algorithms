namespace Lib.Chapter2;

public class Date : IComparable {

  public int Day {get; init;}
  public int Month {get; init;}
  public int Year {get; init;}

  public int CompareTo(object? other) {
    // order matters here
    // ex: 10/23/84 10/24/83
    // year needs checked before month, then day 
    
		if (other is null) {
			throw new Exception("Date.CompareTo() recieved a null reference");
		}

		Date other_date = (Date) other;

    if (Year < other_date.Year) {return -1;} 
    if (Year > other_date.Year) {return 1;}     
    if (Month < other_date.Month) {return -1;} 
    if (Month > other_date.Month) {return 1;} 
    if (Day < other_date.Day) {return -1;} 
    if (Day > other_date.Day) {return 1;} 
    return 0;
  }

  override public string ToString() {
    return $"{Month}/{Day}/{Year}";
  }


}	