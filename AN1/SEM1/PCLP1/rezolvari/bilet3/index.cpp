#include <bits/stdc++.h>

using namespace std;

struct matrix
{
    int nr_linii, nr_coloane;
    double *m;
} matrice;

// Declarare funcții
void citire();
void meniu();

void initializare(int nrLinii, int nrColoane)
{
    matrice.nr_linii = nrLinii;
    matrice.nr_coloane = nrColoane;
    matrice.m = new double[matrice.nr_linii * matrice.nr_coloane];
}

void citire()
{
    cout << "Introduceti elementele matricei:\n";
    for (int i = 0; i < matrice.nr_linii; i++)
    {
        for (int j = 0; j < matrice.nr_coloane; j++)
        {
            cin >> matrice.m[i * matrice.nr_coloane + j];
        }
    }
}

void afisare()
{
    cout << "Elementele matricei sunt:\n";
    for (int i = 0; i < matrice.nr_linii; i++)
    {
        for (int j = 0; j < matrice.nr_coloane; j++)
        {
            cout << matrice.m[i * matrice.nr_coloane + j] << " ";
        }
        cout << "\n";
    }
}

void afisareLinie(int linie)
{
    cout << "Elementele liniei " << linie << " sunt:\n";
    if (linie < 1 || linie > matrice.nr_linii)
    {
        cout << "Linia nu exista in matrice!\n";
        return;
    }

    for (int j = 0; j < matrice.nr_coloane; j++)
    {
        cout << matrice.m[(linie - 1) * matrice.nr_coloane + j] << " ";
    }
    cout << "\n";
}

bool liniiEgale()
{
    int elim[matrice.nr_linii];
    for (int i = 0; i < matrice.nr_linii - 1; i++)
    {
        if (!elim[i]) // Dacă linia i nu a fost deja marcată pentru eliminare
        {
            for (int j = i + 1; j < matrice.nr_linii; j++)
            {
                bool suntEgale = true;
                for (int k = 0; k < matrice.nr_coloane; k++)
                {
                    if (matrice.m[i * matrice.nr_coloane + k] != matrice.m[j * matrice.nr_coloane + k])
                    {
                        suntEgale = false;
                        break;
                    }
                }
                if (suntEgale)
                {
                    elim[j] = true;
                }
            }
        }
    }
}
void meniu()
{
    int optiune;
    do
    {
        cout << "Selectati o optiune:\n";
        cout << "1. Initializare\n";
        cout << "2. Citire\n";
        cout << "3. Afisare\n";
        cout << "4. Afisare linie\n";
        cout << "0. Iesire\n";
        cin >> optiune;

        switch (optiune)
        {
        case 1:
            cout << "Introduceti dimensiunile matricei: \n";
            int nrLinii, nrColoane;
            cin >> nrLinii >> nrColoane;
            initializare(nrLinii, nrColoane);
            break;
        case 2:
            citire();
            break;
        case 3:
            afisare();
            break;
        case 4:
            cout << "Introduceti linia: \n";
            int linie;
            cin >> linie;
            afisareLinie(linie);
            break;
        case 5:
            liniiEgale();
            break;
        case 0:
            cout << "Programul se inchide.\n";
            break;
        default:
            cout << "Optiunea nu exista!\n";
            break;
        }
    } while (optiune != 0);
}

int main()
{
    meniu(); // Apelul meniului
    return 0;
}