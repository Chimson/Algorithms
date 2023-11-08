namespace Lib.Chapter2;

// ISort interface implements Less and Exch

public class Selection : ISort {
  
  public static void Sort(IComparable[] arr) {
    // for each member of the array look ahead and replace with the smallest element
    // O(n^2) in time complexity, even if the array is already sorted, or is filled with the same vals

    int N = arr.Length;

    for (int i = 0; i < N; ++i) {
      // initialize the index pointing to the smaller element
      int min = i;  
      
      // finds the index of smallest element
      for (int j = i+1; j < N; ++j) {
        if (ISort.Less(arr[j], arr[min])) {
          min = j;
        }
      } 

      ISort.Exch(arr, i, min);  // once smallest entry is found, exchange them

    } 

  }  


}
