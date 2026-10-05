#include <bits/stdc++.h>

using namespace std;

ifstream fin("seturi.txt");

struct Set
{
    int nr_elem;
    double* elem;
};

void initializare();
void citire();
void afisare();
void reuniune();
void cautare();
void dealocare();

void initializare( Set &s1, Set &s2, Set &s3 )
{
    //se aloca memorie pt tablouri
    s1.nr_elem = 5;
    s2.nr_elem = 7;
    s2.elem = new double[s2.nr_elem];
    s1.elem = new double[s1.nr_elem];
    s3.nr_elem = s1.nr_elem + s2.nr_elem;
    s3.elem = new double[s3.nr_elem];
}

void citire(Set &s1, Set &s2)
{
    for (int i = 0; i < s1.nr_elem; i++)
    {
        fin >> s1.elem[i];
    }
    for (int i = 0; i < s2.nr_elem; i++)
    {
        fin >> s2.elem[i];
    }
}

void afisare(Set &s1, Set &s2)
{
    cout << "\nAfisare: \n";
    cout << "Elementele setului 1: \n";
    for (int i = 0; i < s1.nr_elem; i++)
    {
        cout << "Elementul " << i + 1 << ": " << s1.elem[i] << "\n";
    }
    cout << "\nElementele setului 2: \n";
    for (int i = 0; i < s2.nr_elem; i++)
    {
        cout << "Elementul " << i + 1 << ": " << s2.elem[i] << "\n";
    }
}

void reuniune(Set &s1, Set &s2, Set &s3)
{
    for(int i = 0; i < s1.nr_elem; i++)
    {
        s3.elem[i] = s1.elem[i];
    }
    for(int i = 0; i < s2.nr_elem; i++)
    {
        s3.elem[i + s1.nr_elem] = s2.elem[i];
    }
    for( int i = 0; i < s3.nr_elem -1; i++ )
        for(int j = i; j < s3.nr_elem; j++)
            if( s3.elem[i] > s3.elem[j] )
            {
                double aux = s3.elem[i];
                s3.elem[i] = s3.elem[j];
                s3.elem[j] = aux;
            }
    cout << "\nReuniunea seturilor: \n";
    for(int i = 0; i < s3.nr_elem; i++)
    {
        cout << "Elementul " << i + 1 << ": " << s3.elem[i] << "\n";
    }
}
int cautare( Set &s3, double val, int left, int right)
{
    bool gasit = false;
    for( int i = 0; i < s3.nr_elem; i++ )
    {
        if( s3.elem[i] == val )
        {
            cout << "Elementul se afla pe pozitia " << i + 1 << "\n";
            gasit = true;
        }
        if(gasit == 0 && i == s3.nr_elem-1)
            cout << "Elementul nu a fost gasit\n";
    }
    return -1;
}

void dealocare(Set &s1, Set &s2, Set &s3)
{
    delete[] s1.elem;
    delete[] s2.elem;
    delete[] s3.elem;
    cout << "Memoria a fost dealocata\n";
}
int main()
{
    Set s1, s2, s3;
    double val;
    initializare(s1, s2, s3);
    citire(s1, s2);
    afisare(s1, s2);
    reuniune(s1, s2 , s3);
    cout << "Introduceti valoarea pentru cautare: ";
    cin >> val;
    cautare(s3, val, 0, s3.nr_elem - 1);
    dealocare(s1, s2, s3);
}