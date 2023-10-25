namespace Lib.Chapter2;

public interface ISort {
  
  public static abstract void Sort(IComparable[] arr);

  private static bool Less(IComparable a, IComparable b) {
    // CompareTo() returns -1 <, 0 ==, 1 >
    return a.CompareTo(b) < 0;
  }

  private static void Exch(IComparable[] arr, int i, int j) {
    // swap at an index;
    IComparable tmp = arr[i];
    arr[i] = arr[j];
    arr[j] = tmp;
  } 
  
  
  

}