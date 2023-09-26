namespace Lib.Chapter1;

// forest of trees implementation
// p and q are connected if they have the same root, in the same tree
// worst case for Find() is O(n), but may be faster than QuickFind depending on input
// worst case for many unions is when they are all connected, could be quadratic

public class QuickUnion : IUnionFind {

  // inherits fields and methods:
  //  int[] ID
  //  bool Connected(int, p, int q)

  private int count;

  public QuickUnion(int N) : base(N) {
    count = N;
  } 

  override public int Count() => count;

  override public int Find(int p) {
    // follows a link, until a link is itself (root)

    while (p != ID[p]) {
      p = ID[p];
    }
    return p;
  }

  override public void Union(int p, int q) {
    int p_root = Find(p);
    int q_root = Find(q);
    if (p_root == q_root) {
      return;
    }
    ID[p_root] = q_root;
    --count;
  }

}


