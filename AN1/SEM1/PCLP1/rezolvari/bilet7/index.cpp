#include <iostream>

using namespace std;

void initializare();
void citire();
void afisare();
void verif();
void elim_coloana();
void egal_c();
void dealocare();

struct matrix
{
    int nr_linii, nr_coloane;
    double *m;
} matrice;

void initializare()
{
    matrice.nr_linii = 3;
    matrice.nr_coloane = 3;
    matrice.m = new double[matrice.nr_linii * matrice.nr_coloane];
}

// Funcție pentru citirea matricei
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

void verif(int val)
{
    bool gasit = false;
    for (int i = 0; i < matrice.nr_linii; i++)
    {
        for (int j = 0; j < matrice.nr_coloane; j++)
        {
            if (matrice.m[i * matrice.nr_coloane + j] == val)
            {
                cout << "Elementul a fost gasit la pozitia: " << i << " " << j << "\n";
                gasit = true;
            }
        }
    }
    if (!gasit)
    {
        cout << "Elementul nu se afla in matrice\n";
    }
}

void elimin_coloana(int coloana)
{
    double *new_m = new double[matrice.nr_linii * (matrice.nr_coloane - 1)];
    for (int i = 0; i < matrice.nr_linii; i++)
        for (int j = 0, k = 0; j < matrice.nr_coloane; ++j)
            {
                if (j != coloana)
                {
                    new_m[i * (matrice.nr_coloane - 1) + k++] = matrice.m[i * matrice.nr_coloane + j];
                }
            }
    cout<<"noua matrice fara coloana " << coloana << " este: " << "\n";
    for (int i = 0; i < matrice.nr_linii; i++)
    {
        for (int j = 0; j < (matrice.nr_coloane - 1); j++)
        {
            cout << new_m[i * (matrice.nr_coloane - 1) + j] << " ";
        }
        cout <<"\n";
    }
    // delete[] new_m;
}

void egal_c(int col1, int col2)
{
    bool egal = true;
    for (int i = 0; i < matrice.nr_linii; i++)
    {
        if (matrice.m[i * matrice.nr_coloane + col1] != matrice.m[i * matrice.nr_coloane + col2])
        {
            egal = false;
            break;
        }
    }

    if (egal)
    {
        cout << "Cele doua coloane sunt egale.\n";
    }
    else
    {
        cout << "Cele doua coloane nu sunt egale.\n";
    }
}

void dealocare()
{
    delete[] matrice.m;
    matrice.m = nullptr;
}

int main()
{
    initializare();
    citire();
    afisare();
    int val, col1, col2;
    cout << "Introduceti valoarea pentru verificare: ";
    cin >> val;
    verif(val);
    int elim;
    cout << "Introduceti coloana pe care doriti sa o eliminati: ";
    cin >> elim;
    elimin_coloana(elim-1);
    afisare();
    cout <<" introduceti indicii coloanelor care doriti sa fie verificate: \n";
    cout << "col1: ";
    cin >> col1;
    cout << "col2: ";
    cin >> col2;
    egal_c(col1 -1, col2-1);
    dealocare();
    cout << "matricea dupa dealocare este: \n";
    afisare();
    return 0;
}