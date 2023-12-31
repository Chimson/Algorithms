namespace Lib.Chapter1;

public class ArrayAlgs {

  public static double Max(in double[] arr) {
    // find the maximum of an array
    // could be unsorted
    // needs at least one element, or IndexxOutOfRange exception
    double max = arr[0];
    for (int i = 1; i < arr.Length; ++i) {
      if (arr[i] > max) {
        max = arr[i];
      }
    }
    return max;
  } 

  public static double Average(in double[] arr) {
    int N = arr.Length;
    double sum = 0.0;
    for (int i = 0; i < N; ++i) {
      sum += arr[i];            
    }
    return sum / N;
  }

  public static double[] Copy(in double[] from) {
    int N = from.Length;
    double[] to = new double[N];
    for (int i = 0; i < N; ++i) {
      to[i] = from[i];
    }
    return to;
  }

  public static void Reverse(double[] arr) {
    int N = arr.Length;
    for (int i = 0; i < N/2; ++i) {
      double temp = arr[i];
      int rind = N - 1 - i;
      arr[i] = arr[rind]; 
      arr[rind] = temp;
    }
  }

  public static int ThreeSum(in int[] arr) {
    // how many triplets of ints add to 0 in an array
    // brute force alg that checks each unique triplet, O(N^3)
    int N = arr.Length;
    int count = 0;
    for (int i = 0; i < N; ++i) {
      for (int j = i + 1; j < N; ++j) {
        for (int k = j + 1; k < N; ++k) {
          if (arr[i] + arr[j] + arr[k] == 0) {
            ++count;
          }
        }
      }
    }
    return count;
  }

  public static int ThreeSum(in int[] arr, out string results) {
    results = "";
    int N = arr.Length;
    int count = 0;
    for (int i = 0; i < N; ++i) {
      for (int j = i + 1; j < N; ++j) {
        for (int k = j + 1; k < N; ++k) {
          if (arr[i] + arr[j] + arr[k] == 0) {
            results += $"{arr[i]} {arr[j]} {arr[k]}\n";
            ++count;
          }
        }
      }
    }
    results = results.TrimEnd('\n');
    return count;
  }

  public static int ThreeSumFast(in int[] arr) {
    // faster version, O(N^2Log(N))
    // similar quirks with duplicates as TwoSum
    int N = arr.Length;
    int count = 0;
    Array.Sort(arr);
    for (int i = 0; i < N; ++i) {
      for (int j = i + 1; j < N; ++j) {
        if (BinarySearch.RecRank(-arr[i]-arr[j], arr) > j) {
          ++count;
        }
      }
    }
    return count;  
  }

  public static int TwoSum(in int[] arr, out string results) {
    // assume the array has unique ints, finds the pair that adds to 0
    //   will sometimes work if there is a duplicate of an (a, -a) pair
    //   see unit test for bug on duplicate of zeros case   
    // based on finding -a[i] for each a[i]
    // faster than brute force, by sorting and using binary search, O(N*Log(N))
    // Sort uses QuickSort, Insertion, or Heapsort depending on the size 
    results = "";
    int N = arr.Length;
    int count = 0;
    Array.Sort(arr);
    for (int i = 0; i < N; ++i) {
      int matching = BinarySearch.RecRank(-arr[i], arr);  // returns index when found or -1 when not found
      // avoid double counting, so only check ahead
      if (matching > i) {
        results += $"{arr[i]} {arr[matching]}\n";
        ++count;
      }
    }
    results = results.TrimEnd('\n');
    return count;
  }

}

/*
TwoSum 
on arr: {3, 4, -3}
  arr = {-3, 3, 4}
  count = 0
  i = 0
    1 = bin(3, arr) > 0
      ++count
  i = 1
=====
{-3, 4, 7, -7, 3, -4}    
{-7, -4, -3, 3, 4, 7}, then counts
=====
Two Sum with duplicate pairs
{0, -3, 4, 7, -7, 3, 0, -4};
{-7, -4, -3, 0, 0, 3, 4, 7}
*/


/*
ThreeSum
arr: {2, -4, 5, 1, 3, -7}
loop:
  2
    -4
      5
      1
      3
      7
    5
      1
      3
      7
    1
      3
      -7
    3
      -7
...
*/