namespace Lib.Chapter1;


// not tested in accepting max/min vals for each type
public class Rand {

  private static Random random = new Random(); 

  public static double Uniform(in double a, in double b) {
    // NextDouble() is in (0.0, 1.0)
    return a + random.NextDouble() * (b - a);
  }

  public static int Uniform(int N) {
    // random int in (0, N]
    return (int) (random.NextDouble() * N);
  }

  public static int Uniform(in int a, in int b) {
    // random int in [a, b)
    return a + Uniform(b - a); 
  }

  public static int Discrete(in double[] a) {
    // entries in a must sum to 1;
    // random int in drawn from discrete distribution 
    double r = random.NextDouble();
    double sum = 0.0;
    for (int i = 0; i < a.Length; ++i) {
      sum += a[i];
      if (sum >= r) {
        return i;
      } 
    }
    return -1;
  }

  public static void Shuffle(in double[] a) {
    int N = a.Length;
    for (int i = 0; i < N; ++i) {
      int r = i + random.Next(N - i); 
      double temp = a[i];
      a[i] = a[r];
      a[r] = temp;
    }
  }


}