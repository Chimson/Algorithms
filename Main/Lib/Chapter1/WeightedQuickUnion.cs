namespace Lib.Chapter1;

public class WeightedQuickUnion : IUnionFind {
  
  // inherits fields and methods:
  //  int[] ID
  //  bool Connected(int, p, int q)

  private int[] SZ;   // keeps track of the tree size (num of leaves) at root
  private int count;
  
  public WeightedQuickUnion(int N) : base(N) {
    count = N;
    SZ = new int[N];
    for (int i = 0; i < N; ++i) {
      SZ[i] = 1;
    }
  }

  // num of components (trees)
  override public int Count() => count;

  override public int Find(int p) {
    // follows a link, until a link is itself (root)
    while (p != ID[p]) {
      p = ID[p];
    }
    return p;
  }

  override public void Union(int p, int q) {
    int rp = Find(p);
    int rq = Find(q);

    if (rp == rq) {
      return;
    }

    // make the smaller root point to the larger one
    if (SZ[rp] < SZ[rq]) {
      ID[rp] = rq;    // attaches root of tree containing p as a child to root containing q
      SZ[rq] += SZ[rp];
    }
    else {
      ID[rq] = rp;
      SZ[rp] += SZ[rq];
    }
    
    --count;
  }
}

/*
ID: 0 1 2 3 4 5 6 7 8 9
SZ: 1 1 1 1 1 1 1 1 1 1 
union(4,3)
  ip = 4
  iq = 3
ID: 0 1 2 4 4 5 6 7 8 9
SZ: 1 1 1 1 2 1 1 1 1 1 
union(3,8)
  ip = 4
  iq = 8
ID: 0 1 2 4 4 5 6 7 4 9
SZ: 1 1 1 1 3 1 1 1 1 1 
union(6,5)
  ip = 6
  iq = 5
ID: 0 1 2 4 4 6 6 7 4 9
SZ: 1 1 1 1 3 1 2 1 1 1 
*/