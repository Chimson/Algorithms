namespace Lib.Chapter2;

// shellsort is like insertion sort, but pre-sorts on elems of size h apart first, 
// when h == 1 its regular insertion sort
// insertion sort on its own is slow, since there are many consec subexchanges 
//   this happens when an elem needs exch many times to get to its sorted spot
// shellsorts pre-sorting helps reduce the number of subexchanges
// every hth entry yields a sorted subsequence
// produces a n h-sorted array where it contains h sorted subsequences interleaved into one
// performance is not proven by the book, but is known to be around O(N^3/2) on worst case
//  with this h increment sequence
// book demonstrates that shellsort is 600*faster than insertion, when applied to 100 arrays of 100000 random doubles


public class Shell : ISort {

  public static void Sort(IComparable[] arr) {
    int N = arr.Length;
    int h = 1;
    
    // calculate an h to start with, this sequence is relatively arbitrary
    // better sequences could still be discovered 
    while (h < N/3) {
      h = 3*h + 1;
    } 
    
    while (h >= 1) {
      for (int i = h; i < N; ++i) {
        for (int j = i; j >= h && ISort.Less(arr[j], arr[j-h]); j -= h) {
          ISort.Exch(arr, j, j-h);
        }
      }
      h = h/3;
    }
  }
}

/*
I chose a bigger h with a smaller N to simplify the example
5 4 3 2 1 0
h = 3 
  i = 3
    j = 3
      2 4 3 5 1 0
  i = 4
    j = 4
      2 1 3 5 4 0
  i = 5
    j = 5
       2 1 0 5 4 3   // 3-sorted array
  h = 1
h = 1
  i = 1
    j = 1
      1 2 0 5 4 3
  i = 2
    j = 2
      1 0 2 5 4 3
    j = 1
      0 1 2 5 4 3
  i = 3
    j = 3
      loop breaks
  i = 4
    j = 4
      0 1 2 4 5 3
    j = 3
      loop breaks
  i = 5
    j = 5
      0 1 2 4 3 5
    j = 4
      0 1 2 3 4 5
    j = 3
      loop breaks
  h = 0








*/