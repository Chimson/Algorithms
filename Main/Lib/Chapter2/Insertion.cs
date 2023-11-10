namespace Lib.Chapter2;

public class Insertion : ISort {

  public static void Sort(IComparable[] arr) {
    // fix an elem, look at consec pairs behind it
    // if the right is smaller than the left then exchange them
    // otherwise stop, because then all to left are in order
    // worst case is O(n^2), when they are in increasing order (backwards)
    // O(n) when already sorted or all of the same value, since the inner loop never executess
    // works well when there is some order in a random array

    int N = arr.Length;

    for (int i = 1; i < N; ++i) {

        // loop breaks when the pair is already in order
        //  know at this point at all pairs to the left have been visited and are in order
        for (int j = i; j > 0 && ISort.Less(arr[j], arr[j-1]); --j) {
           ISort.Exch(arr, j, j-1); 
        }

    }

  }

}
/*
i=1
9 8 7 10 
  ^j
8 9 7 10
i=2  
8 9 7 10
    ^j
8 7 9 10
  ^j
7 8 9 10
i=3  
7 8 9 10   // loop stops by the condition, we know those to the left are already in order
      ^j
*/
