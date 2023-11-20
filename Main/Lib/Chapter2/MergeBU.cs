namespace Lib.Chapter2;

public class MergeBU : IMerge, ISort {

  private static IComparable[]? aux;

  // Bottom Up Merge Sort
  // calls merges of size 1, 2, 4, etc.
  // execution avoids the many divide and conquer small merges
  // O(NLgN)
  // same as MergeSort (top-down) when the size is a power of 2
  // good for sorting in linked lists
  public static void Sort(IComparable[] arr) {
    int N = arr.Length;
    aux = new IComparable[N];
    for (int sz = 1; sz < N; sz = 2 * sz) {
      for (int i = 0; i < N - sz; i += 2 * sz) {
        IMerge.Merge(arr, i, i + sz - 1, Math.Min(i + 2 * sz - 1, N - 1));
      }  
    }     
  }

}

/*
N = 5
aux: [5, 4, 3, 2, 1]
sz = 1
  i = 0
    Merge(0, 0, min(1, 4))
      [4, 5, 3, 2, 1]
  i = 2
    Merge(2, 2, min(3, 4))
      [4, 5, 2, 3, 1]
sz = 2
  i = 0
    Merge(0, 1, min(3, 4))
      [2, 3, 4, 5, 1]
sz = 4
  i = 0
    Merge(0, 3, min(7, 4))
      [1, 2, 3, 4, 5]

*/