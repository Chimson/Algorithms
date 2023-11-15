namespace Lib.Chapter2;

public class Merge : IMerge, ISort {

  private static IComparable[]? aux;

  public static void Sort(IComparable[] arr) {
    aux = new IComparable[arr.Length];
    sort(arr, 0, arr.Length - 1);
  }

  private static void sort(IComparable[] arr, int low, int high) {
    if (high <= low) return;
    int mid = low + (high - low)/2;  // find the index value in betweem low and high    
    sort(arr, low, mid);    
    sort(arr, mid + 1, high);
    IMerge.Merge(arr, low, mid, high);
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
        [4 3 5 2 1]
      return 
    

        

      
*/