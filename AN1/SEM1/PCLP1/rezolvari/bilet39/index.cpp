#include <iostream>

using namespace std;

struct rational
{
    int p, q;
};

void citire(int *v, int *k, int &n) {
    cout << "Introduceti dimensiunea vectorului: ";
    cin >> n;
    for (int i = 0; i < n; i++) {
        cout << "introduceti elementul: " << i + 1 << ": ";
        cin >> v[i];
        cout << "/";
        cin >> k[i];
  }
}

void afisare(int *v, int *k, int &n) {
  for (int i = 0; i < n; i++) {
    cout <<"elementul " << i+1 << " este: " << v[i] << "/" << k[i] << " ";
  }
  cout << endl;
}


void simplificare(int *v, int *k, int &n) {
  for( int i = 0; i< n; i++ )
    if(k[i] != 0)
    {
      if( v[i] % 2 == 0 && k[i] % 2 == 0 )
      {
        if( v[i] > k[i] )

      }
    }

}

int main() {
  int *v, *k, n;
  v = new int[n];
  k = new int[n];
  citire(v, k, n);
  afisare(v,k, n);

  delete[] v;

  return 0;
}
