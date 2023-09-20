namespace Lib.Chapter1;

using System.Diagnostics;

public delegate int ThreeSumFunc(in int[] a);

public class DoublingRatioThreeSum {

  public static double TimeTrial(int arr_size, ThreeSumFunc TSF) {
    // create test input array
    int max = 1000000;   // val range
    int[] a = new int[arr_size];
    for (int i = 0; i < arr_size; ++i) {
      a[i] = Rand.Uniform(-max, max);
    }

    // set up the timer and time it
    Stopwatch watch = new Stopwatch(); 
    watch.Start();
    int count = TSF(a);
    watch.Stop();
    return watch.Elapsed.TotalSeconds;
  }

  public static void Ratio(ThreeSumFunc TSF) {
    // the ratio approaches 8 as N increases, for ArrayAlgs.ThreeSum
    // runtime of ThreeSum is O(N^3)
    // (2N)^3 / (N^3) = 8
    // using the doubling ratio, you can predict the runtime: around 8 is likely N^3, since 2^3 = 8
    // similiarly 4 indicates N^2, 2 indicates N or NLogN 
    // In General, for T(N) running time of a program:
    //   Assume T(N) is in O((N^b) * LogN)
    //   T(2N)/T(N) is in O(2^b), b indicating the exponent on the size of N    

    double prev = TimeTrial(125, TSF);
    int max_input_size = 2000; 
    string msg = $"{"N",-6} {"time",-6} {"ratio",-6}\n";
    for (int N = 250; N <= max_input_size; N += N) {
      double time = TimeTrial(N, TSF);
      msg += $"{N,-6} {time,-6:F4} {time/prev,-6:F4}\n";
      prev = time;
    }
    msg = msg.TrimEnd('\n');
    Console.Write(msg);
  }


}