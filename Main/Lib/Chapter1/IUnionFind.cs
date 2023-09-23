namespace Lib.Chapter1;

abstract public class IUnionFind {
  public int[] ID {get; private set;} 

  public IUnionFind(int N) {
    ID = new int[N];
    for (int i = 0; i < N; ++i) {
      ID[i] = i;
    }
  } 

  abstract public int Find(int p);
  abstract public void Union(int p, int q);
  abstract public int Count();

  public bool Connected(int p, int q) => 
    Find(p) == Find(q);


}