namespace Lib.Chapter2;

public class IMerge {

  public static void Merge(IComparable[] arr, int low, int mid, int high) {

    IComparable[] aux = new IComparable[arr.Length]; 
    
    // copy to aux
    arr.CopyTo(aux, 0);  

    // merge back to arr
    int i = low;
    int j = mid + 1;

    for (int k = low; k <= high; ++k) {
      // i or j travels forward depending on the comparison

      if (i > mid) {
        // if i has traveled past half then, just copy the j val in
        arr[k] = aux[j++];
      }
      else if (j > high) {
        // if j travels past the end, then copy the i val in 
        arr[k] = aux[i++];
      }
      else if (ISort.Less(aux[j], aux[i])) {
        // always looks back at the vals in the initial order in aux
        // second half val is out of order from the given 1st half val, keep traveling in the second half
        arr[k] = aux[j++];   // select the 2nd half val
      }
      else {
        // when the first half val is already in order with respect to given 2nd half val
        // keep traveling through the first half
        arr[k] = aux[i++];  // select the first half val
      }
    }
  }

}

/*
arr = 2 3 5 1 6 9 
 
// X's show which member of aux has already been copied in arr 
aux= 2  3  5  1  6  9   |   arr = 1 3 5 1 6 9
     ^i       ^j  
     2  3  5  X  6  9   |   arr = 1 2 5 1 6 9
     ^i          ^j
     X  3  5  X  6  9   |   arr = 1 2 3 1 6 9
        ^i       ^j
     X  X  5  X  6  9   |   arr = 1 2 3 5 6 9 
           ^i    ^j
     X  X  X  X  6  9   |   arr = 1 2 3 5 6 9 
              ^i ^j
     X  X  X  X  X  9   |   arr = 1 2 3 5 6 9   
              ^i    ^j
     X  X  X  X  X  X   |      
              ^i       ^j

arr = 2 3 5 1 6 9 
aux = 2 3 5 1 6 9 
low = 0
high = 5
mid = 2
i = 0 
j = 3
k = 0
  arr = 1 3 5 1 6 9    // Less(aux[j], aux[i])
  j = 4
k = 1
  arr = 1 2 5 1 6 9    // else
  i = 1
k = 2
  arr = 1 2 3 1 6 9    // else
  i = 2
k = 3
  arr = 1 2 3 5 6 9    // else
  i = 3
k = 4
  arr = 1 2 3 5 6 9    // i > mid
  j = 5
k = 5
  arr = 1 2 3 5 6 9    // i > mid
  j = 6
*/