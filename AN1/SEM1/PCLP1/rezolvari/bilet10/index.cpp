#include <bits/stdc++.h>

using namespace std;

struct Vector
{
    int dim;
    int* vect;
};

void initializare();
void citire();
void afisare();
void verificare();
void egalitate();
void interesectie();
void reuniune();
void dealocare();

void initializare(Vector& v)
{
    v.dim = 0;
    v.vect = nullptr;
}

void citire(Vector& v)
{
    cout << "Introduceti dimensiunea vectorului: ";
    cin >> v.dim;
    cout << "Introduceti elementele vectorului: \n";
    v.vect = new int[v.dim];
    for (int i = 0; i < v.dim; i++)
    {
        cout << "Introduceti elementul " << i + 1 << ": ";
        cin >> v.vect[i];
    }
}

void afisare(Vector& v)
{
    cout << "Elementele vectorului sunt: \n";
    for (int i = 0; i < v.dim; i++)
    {
        cout << "Elementul " << i + 1 << " este: " << v.vect[i] << " \n";
    }
}

void verificare(Vector& v1, int val)
{
    bool gasit = false;
    for (int i = 0; i < v1.dim; i++)
    {
        if (v1.vect[i] == val)
        {
            cout << "Elementul a fost gasit la pozitia: " << i +1<< "\n";
            gasit = true;
        }
    }
    if (!gasit)
    {
        cout << "Elementul nu se afla in vector\n";
    }
}

void egalitate(Vector& v1, Vector& v2)
{
    if (v1.dim != v2.dim)
    {
        cout << "Cei doi vectori nu au aceeasi dimensiune, deci nu pot fi egali\n";
        return;
    }

    bool egal = true;
    for (int i = 0; i < v1.dim; i++)
    {
        if (v1.vect[i] != v2.vect[i])
        {
            cout << "Cei doi vectori au elemente diferite, deci nu pot fi egali\n";
            egal = false;
            break;
        }
    }

    if (egal)
        cout << "Cei doi vectori sunt egali";
}

void intersectie(Vector& v1, Vector& v2, Vector& v3)
{
    v3.dim = 0; // Resetăm dimensiunea vectorului rezultat v3

    cout << "Intersectia celor doua vectori este: \n";
    for (int i = 0; i < v1.dim; i++)
    {
        for (int j = 0; j < v2.dim; j++)
        {
            if (v1.vect[i] == v2.vect[j])
            {
                v3.vect[v3.dim] = v1.vect[i];
                v3.dim++;
            }
        }
    }

    // Afișăm elementele vectorului v3
    for (int i = 0; i < v3.dim; i++)
    {
        cout << v3.vect[i] << " ";
    }
    delete [] v3.vect;
}

void reuniune(Vector& v1, Vector& v2, Vector& v3)
{
    for( int i = 0; i < v1.dim; i++)
    {
        v3.vect[v3.dim] = v1.vect[i];
        v3.dim++;
    }
    for (int i = 0; i < v2.dim; i++)
    {
        v3.vect[v3.dim] = v2.vect[i];
        v3.dim++;
    }
    cout << "Reuniunea celor doua vectori este: \n";
    for (int i = 0; i < v3.dim; i++)
    {
        cout << v3.vect[i] << " ";
    }
    delete [] v3.vect;
}

void dealocare(Vector& v)
{
    delete[] v.vect;
    v.vect = nullptr;
}
int main()
{
    Vector v1, v2, v3;
    int val;
    citire(v1);
    afisare(v1);
    cout<< "Introduceti valoarea care doriti sa fie verificata: ";
    cin >> val;
    verificare(v1, val);
    cout << "Introduceti al doilea vector: \n";
    citire(v2);
    egalitate(v1, v2);
    intersectie(v1, v2, v3);
    reuniune(v1, v2, v3);
}