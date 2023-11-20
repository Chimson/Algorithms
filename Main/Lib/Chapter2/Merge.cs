namespace Lib.Chapter2;

// using AlTest;

public class Merge : IMerge, ISort {

  private static IComparable[]? aux;

  public static void Sort(IComparable[] arr) {
    // recursive divide and conquer alg
    // O(NLog(N)) in time since the execution is a binary tree of depth log(N)
    // N leaves total at the lowest depth 
    // O(N) in space for the extra array
    // improve performance to switching to Insertion or Selection sort on arrays of size <= 15
    // can reduce the running time to linear for already sorted arrays by 
    //   skipping merge call on a[mid] <= a[mid+1]
    // can reduce the time on copying to aux by alternating between aux and orig array in the 
    //   sort calls

    aux = new IComparable[arr.Length];
    sort(arr, 0, arr.Length - 1);
  }

  private static void sort(IComparable[] arr, int low, int high) {
    if (high == low) return;
    int mid = low + (high - low)/2;  // find the index value in betweem low and high    
    sort(arr, low, mid);    
    sort(arr, mid + 1, high);
    IMerge.Merge(arr, low, mid, high);
  }

  public static string ArrStr(IComparable[] arr) {
    // used in debugging, same function in Test.Results
    string arrstr = "[";
    int N = arr.Length;
    for (int i = 0; i < N - 1; ++i) {
      arrstr += $"{arr[i]}, ";
    }
    arrstr += $"{arr[N - 1]}]";
    return arrstr;
  }

}

/*
sort([5 4 3 2 1])
  sort(0, 4)
    mid = 2
    sort(0, 2)
      mid = 1
      sort(0, 1)
        mid = 0
        sort(0, 0)
          return
        sort(1, 1)
          return
        merge(0, 0, 1)
          [4 5 3 2 1]
        return
      sort(2, 2)
        return
      merge(0, 1, 2)
        [3 4 5 2 1]
      return 
    sort(3, 4)
      mid = 3
      sort(3, 3)
        return
      sort(4, 4)
        return
      merge(3, 3, 4)
        [3 4 5 1 2]
      return
    merge(0, 2, 4)  
      [1 2 3 4 5]
    return
  return

    

        

      
*/