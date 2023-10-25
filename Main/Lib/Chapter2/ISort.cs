namespace Lib.Chapter2;

public interface ISort {
  
  public static abstract void Sort(IComparable[] arr);

  public static bool Less(IComparable a, IComparable b) {
    // CompareTo() returns -1 <, 0 ==, 1 >
    return a.CompareTo(b) < 0;
  }

  public static void Exch(IComparable[] arr, int i, int j) {
    // swap at an index;
    IComparable tmp = arr[i];
    arr[i] = arr[j];
    arr[j] = tmp;
  } 
  
  public static bool IsSorted(IComparable[] arr) {
    // false when a consecutive pair is not in order
    for (int i = 1; i < arr.Length; ++i) {
      if (ISort.Less(arr[i], arr[i-1])) {
        return false;
      }
    } 
    return true;
  }

}