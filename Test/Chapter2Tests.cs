namespace Test;

using Lib.Chapter2;
using NUnit.Framework;

[TestFixture]
public class Chapter2Tests {

  [OneTimeSetUp]
  public static void Init() {
    // error stream prints immediately
    Console.Error.WriteLine(Results.Title("Chapter 2 Tests"));
  }

  [Test]
  public void DateTest1() {
    Date date = new Date {Day = 23, Month = 10, Year = 1984};
    Results.Print($"DateTest1: {date.ToString()}");
    Assert.Pass();
  }

  [Test]
  public void DateTest2() {
    Date date1 = new Date {Day = 23, Month = 10, Year = 1984};
    Date date2 = new Date {Day = 22, Month = 10, Year = 1983};  // 1, date1 > date2 
    Date date3 = new Date {Day = 24, Month = 10, Year = 1984};  // -1
    Date date4 = new Date {Day = 23, Month = 11, Year = 1984};  // -1
    Date date5 = new Date {Day = 23, Month = 10, Year = 1983};  // 1
    Date date6 = new Date {Day = 23, Month = 10, Year = 1983};  // 1
    Date date7 = new Date {Day = 23, Month = 10, Year = 1985};  // -1
    Date date8 = new Date {Day = 23, Month = 10, Year = 1984};  // 0
    Assert.AreEqual(1, date1.CompareTo(date2));
    Assert.AreEqual(-1, date1.CompareTo(date3));
    Assert.AreEqual(-1, date1.CompareTo(date4));
    Assert.AreEqual(1, date1.CompareTo(date5));
    Assert.AreEqual(1, date1.CompareTo(date6));
    Assert.AreEqual(-1, date1.CompareTo(date7));
    Assert.AreEqual(0, date1.CompareTo(date8));
    Results.Print("Date.CompareTo() passes");
  }

  [Test]
  public void DateTest3() {
    // add a test that checks the exception in CompareTo
  }


}
