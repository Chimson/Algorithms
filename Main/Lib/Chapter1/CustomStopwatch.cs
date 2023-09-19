namespace Lib.Chapter1;

public class CustomStopwatch {
  // see C#'s System.Diagnostics.Stopwatch class for its own version
  // example of usage in Chapter1Tests > Stopwatch0 unit test
  
  public long Start {get; private set;}
  public const long TPM = TimeSpan.TicksPerMillisecond; 

  public CustomStopwatch() {
    Start = System.DateTime.Now.Ticks / TPM;  // in milliseconds
  }

  public double ElapsedTime() {
    // return time in seconds
    long now = System.DateTime.Now.Ticks / TPM;
    return (now - Start) / 1000.0;
  } 



}