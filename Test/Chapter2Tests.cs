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
    Results.Print("DateTest2: Date.CompareTo() passes");
  }

	[Test]
  public void DateTest3() {
		// check the null ref 
		Date date1 = new Date {Day = 23, Month = 10, Year = 1984};
		Assert.Throws<Exception>(() => date1.CompareTo(null));
    Results.Print("DateTest3 throws on null ref");
  }

	[Test]
  public void DateTest4() {
    // check that explicit cast throws
		Date date1 = new Date {Day = 23, Month = 10, Year = 1984};
		Assert.Throws<InvalidCastException>(() => date1.CompareTo("Ben"));
    Results.Print("DateTest4 throws when Date is compared with a string");
  }

  [Test]
  public void SelectionSort1() {
    // chars implement IComparable.ToCompare
    IComparable[] arr = {'b', 'e', 'n', 'h', 'a', 'r', 'k', 'i'};
    Results.Print($"SelectionSort1: {Results.ICompToString(arr)} becomes ");
    Selection.Sort(arr);
    Results.Print(Results.ICompToString(arr));
    Assert.True(ISort.IsSorted(arr));
  }

  [Test]
  public void SelectionSort2() {
    // is O(n^2) even though it is sorted
    IComparable[] arr = {'a', 'b', 'c', 'd', 'e'};
    Results.Print($"SelectionSort2: {Results.ICompToString(arr)} becomes ");
    Selection.Sort(arr);
    Results.Print(Results.ICompToString(arr));
    Assert.True(ISort.IsSorted(arr));
  }

  [Test]
  public void InsertionSort1() {
    // chars implement IComparable.ToCompare
    IComparable[] arr = {'b', 'e', 'n', 'h', 'a', 'r', 'k', 'i'};
    Results.Print($"InsertionSort1: {Results.ICompToString(arr)} becomes ");
    Insertion.Sort(arr);
    Results.Print(Results.ICompToString(arr));
    Assert.True(ISort.IsSorted(arr));
  }

  [Test]
  public void InsertionSort2() {
    // worst case, O(n^2)
    IComparable[] arr = {'e', 'd', 'c', 'b', 'a'};
    Results.Print($"InsertionSort2: {Results.ICompToString(arr)} becomes ");
    Insertion.Sort(arr);
    Results.Print(Results.ICompToString(arr));
    Assert.True(ISort.IsSorted(arr));
  }

  [Test]
  public void InsertionSort3() {
    // is O(n) on the best case
    IComparable[] arr = {'a', 'b', 'c', 'd', 'e'};
    Results.Print($"InsertionSort3: {Results.ICompToString(arr)} becomes ");
    Insertion.Sort(arr);
    Results.Print(Results.ICompToString(arr));
    Assert.True(ISort.IsSorted(arr));
  }

  [Test]
  public void ShellSort1() {
    IComparable[] arr = {'b', 'e', 'n', 'h', 'a', 'r', 'k', 'i'};
    Results.Print($"ShellSort1: {Results.ICompToString(arr)} becomes ");
    Shell.Sort(arr);
    Results.Print(Results.ICompToString(arr));
    Assert.True(ISort.IsSorted(arr));
  }

  [Test]
  public void ShellSort2() {
    IComparable[] arr = {'e', 'd', 'c', 'b', 'a'};
    Results.Print($"ShellSort2: {Results.ICompToString(arr)} becomes ");
    Shell.Sort(arr);
    Results.Print(Results.ICompToString(arr));
    Assert.True(ISort.IsSorted(arr));
  }

  [Test]
  public void MergeTest1() {
    // used in MergeSort
    // when its sorted by halves, Merge returns it totally sorted
    IComparable[] arr = {2, 3, 5, 1, 6, 9};
    int low = 0; 
    int high = 5; 
    int mid = low + ((high - low) / 2);
    IMerge.Merge(arr, low, mid, high);
    Results.Print($"MergeTest1: 2 3 5 1 6 9 sorts to {Results.ICompToString(arr)}");
    Assert.True(ISort.IsSorted(arr));
  }

  [Test]
  public void MergeTest2() {
    // case where a half of the array is not seperately sorted
    IComparable[] arr = {1, 9, 7, 2, 4, 8};
    int low = 0; 
    int high = 5; 
    int mid = low + ((high - low) / 2);
    IMerge.Merge(arr, low, mid, high);
    Results.Print($"MergeTest2: 2 3 5 1 6 9 sorts to {Results.ICompToString(arr)}");
    Assert.False(ISort.IsSorted(arr));
  }
  

}

// STOPPED ON PAGE 286, but need to review the previous discussion

// execute one test, without the specific warning printed
// > dotnet test -warnAsMessage:NUnit2005 Test --filter "Chapter2Tests.DateTest"
