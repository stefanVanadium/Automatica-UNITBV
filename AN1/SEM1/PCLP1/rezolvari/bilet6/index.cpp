#include <bits/stdc++.h>

using namespace std;

struct stiva
{
    int nrmax, varf;
    double* tab;
};

void initializare(stiva& a, int nrmax)
{
    a.nrmax = nrmax;
    a.varf = -1; // Inițializăm vârful stivei cu -1
    a.tab = new double[nrmax];
}

bool stivaPlina(const stiva& a)
{
    return a.varf == a.nrmax - 1;
}

bool stivaVida(const stiva& a)
{
    return a.varf == -1;
}

void push(stiva& a, double x)
{
    if (!stivaPlina(a))
    {
        a.tab[++a.varf] = x;
    }
    else
        cout << "Stiva este plina, nu s-a putut adauga elementul " << x << ".\n";
}

void afisare(const stiva& a)
{
    cout << "Stiva este: ";
    for (int i = 0; i <= a.varf; i++)
        cout << a.tab[i] << " ";
    cout << "\n";
}

void copiere(const stiva& a, stiva& b)
{
    if (a.varf >= b.nrmax)
    {
        cout << "Stiva a nu poate fi copiata in stiva b, deoarece stiva b nu are suficient spatiu.\n";
        return;
    }

    b.varf = a.varf; // Copiem vârful stivei a în vârful stivei b

    for (int i = 0; i <= a.varf; i++)
        b.tab[i] = a.tab[i];
    cout <<"stiva b este: ";
    afisare(b);
    cout << "stiva a este:";
    afisare(a);
}

void stergeUltimDoua(stiva& a)
{
    if (a.varf < 1)
    {
        cout << "Stiva contine mai putin de doua elemente, nu se pot sterge ultimele doua elemente.\n";
        return;
    }

    double element1 = a.tab[a.varf--];
    double element2 = a.tab[a.varf--];

    cout << "Au fost sterse ultimele doua elemente din stiva: " << element2 << " si " << element1 << ".\n";
    cout << "Stiva dupa stergerea ultimelor doua elemente este: ";
    afisare(a);
}

void stergereStiva(stiva& a)
{
    if (stivaVida(a))
    {
        cout << "Stiva este vida.\n";
        return;
    }

    while (a.varf >= 0)
    {
        cout << "Elementul " << a.tab[a.varf] << " a fost sters din stiva.\n";
        a.varf--; // Decrementăm vârful stivei pentru a "șterge" elementul
    }

    cout << "Stiva a fost stearsa.\n";
}

void dealocare(stiva& a)
{
    delete[] a.tab;
    a.tab = nullptr;
    a.varf = -1;
    a.nrmax = 0;
}

int main()
{
    stiva a, b;
    int nrmax;
    cout << "Introduceti dimensiunea maxima a stivei a: ";
    cin >> nrmax;
    initializare(a, nrmax);
    initializare(b, nrmax);
    cout << "Introduceti cele "<< nrmax << " valori in stiva: ";
    for (int i = 0; i < nrmax; i++)
    {
        cout << "Elementul " << i + 1 << ": ";
        double x;
        cin >> x;
        push(a, x);
    }
    afisare(a);
    copiere(a, b);
    stergeUltimDoua(a);
    stergereStiva(a);
    dealocare(a);
    dealocare(b);

    return 0;
}