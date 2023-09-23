namespace Lib.Chapter1;

public class QuickFind : IUnionFind {
  
  // inherits fields and methods:
  //  int[] ID
  //  bool Connected(int, p, int q)

  private int count;  // easier to place this here rather than IUnionFind abstract class

  public QuickFind(int N) : base(N) {
    count = N;
  }
  
  override public int Count() => count;

  override public int Find(int p) {
    return ID[p];
  }

  override public void Union(int p, int q) {
    // place p and q in the same component (like an equivalence class or set) if they are not already
    
    int pID = Find(p);
    int qID = Find(q);

    if (pID == qID) {return;}

    for (int i = 0; i < ID.Length; ++i) {
      if (ID[i] == pID) {
        ID[i] = qID;
      }
    }
    --count;
  }
}

