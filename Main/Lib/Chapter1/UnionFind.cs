namespace Lib.Chapter1;

public class UnionFind : IUnionFind {
  
  // inherits fields:
  //  int[] ID
  //  int Count

  public UnionFind(int N) : base(N) {}

  override public int Find(int p) {
    return ID[p];
  }

  override public void Union(int p, int q) {
    // place p and q in the same component (equivalence class) if they are not already
    
    int pID = Find(p);
    int qID = Find(q);

    if (pID == qID) {return;}

    for (int i = 0; i < ID.Length; ++i) {
      if (ID[i] == pID) {
        ID[i] = qID;
      }
    }
    // --Count;
    // UNFINISHED
  }

  public override void InitializeNetwork(int[] input) {
    throw new NotImplementedException();
  }

}