#include <bits/stdc++.h>

using namespace std;

struct Vector
{
    int dim;
    int* vect;
};

void intializare(); //da
void citire(); //da
void afisare(); //da
void verificare(); //da
void adaugare();
void eliminare();
void eliminareDubluri();
void egalitate();
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

    v.vect = new int[v.dim];
    cout << "Introduceti elementele vectorului: \n";
    for (int i = 0; i < v.dim; i++) {
        cout << "Introduceti elementul " << i + 1 << ": ";
        cin >> v.vect[i];
    }
}

void afisare(const Vector& v) {
    cout << "Vectorul introdus este: ";
    for (int i = 0; i < v.dim; i++)
        cout << "v[" << i << "] = " << v.vect[i] << "; \n";
    cout << endl;
}

void verificare(const Vector& v, int val)
{
    bool gasit = false;
    for (int i = 0; i < v.dim; i++) {
        if (v.vect[i] == val) {
            cout << "Elementul " << val << " a fost gasit in vector la pozitia " << i << endl;
            gasit = true;
            break;
        }
    }

    if (!gasit)
        cout << "Elementul " << val << " nu se afla in vector" << endl;
}

void adaugare(Vector& v, int val1, int poz)
{
    if( poz < 0)
        cout << "Pozitia nu poate fi mai mica decat 0.";
    if(poz > v.dim)
        cout << "Pozitia nu poate fi mai mare decat dimensiunea vectorului.";
    int* aux = new int[v.dim + 1];
    for(int i = 0; i < poz; i++)
        aux[i] = v.vect[i];
    for (int i = v.dim; i > poz; i--)
        aux[i] = v.vect[i - 1];

    aux[poz] = val1;

    v.dim++;
    v.vect = aux;
    cout<< "Vectorul dupa adaugarea elementului " << val1 << " la pozitia " << poz << " este: ";
    for (int i = 0; i < v.dim; i++)
        cout << v.vect[i] << " ";
}

void eliminare(Vector& v, int poz) {
    if (poz < 0) {
        cout << "Pozitia nu poate fi mai mica decat 0." << endl;
        return;
    }
    if (poz >= v.dim) {
        cout << "Pozitia nu poate fi mai mare decat sau egala cu dimensiunea vectorului." << endl;
        return;
    }

    int* aux = new int[v.dim - 1];
    for (int i = 0; i < poz; i++)
        aux[i] = v.vect[i];
    for (int i = poz; i < v.dim - 1; i++)
        aux[i] = v.vect[i + 1];

    delete[] v.vect; // Eliberăm memoria alocată inițial pentru vectorul original
    v.dim--;
    v.vect = aux;

    cout << "Vectorul dupa eliminarea elementului de la pozitia " << poz << " este: ";
    for (int i = 0; i < v.dim; i++)
        cout << v.vect[i] << " ";
    cout << endl;
}

void eliminareDubluri(Vector& v) {
    for (int i = 0; i < v.dim - 1; i++) {
        for (int j = i + 1; j < v.dim;) {
            if (v.vect[i] == v.vect[j]) {
                for (int k = j; k < v.dim - 1; k++)
                    v.vect[k] = v.vect[k + 1];
                v.dim--;
            } else {
                j++;
            }
        }
    }

    cout << "Vectorul dupa eliminarea dublurilor este: ";
    for (int i = 0; i < v.dim; i++)
        cout << v.vect[i] << " ";
    cout << "\n";
}

void egalitate( Vector& v, Vector& v1 )
{
    bool ok = true;
    if (v.dim == v1.dim)
    {
        for(int i = 0; i< v.dim; i++)
        {
            if(v.vect[i] != v1.vect[i])
            {
                ok = false;
                return;
            }
            else if(ok)
                cout << "Vectorii au elemente egale." << "\n";
        }
    }
    else
        cout << "Vectorii nu au aceeasi dimensiune." << "\n";
}

void dealocare(Vector& v)
{
    delete[] v.vect;
    v.vect = nullptr;
}

int main() {
    Vector v, v1;
    int val, val1, poz;
    initializare(v);
    citire(v);
    afisare(v);
    cout << "Introduceti valoarea pentru verificare: ";
    cin >> val;
    verificare(v, val);
    cout << "Introduceti elementul si pozitia care doriti sa le adaugati in vector ";
    cin >> val1 >> poz;
    adaugare(v, val1, poz);
    cout << "Introduceti pozitia elementului pe care doriti sa il eliminati ";
    cin >> poz;
    eliminare(v, poz);
    eliminareDubluri(v);
    cout << "Introduceti vectorul pe care doriti sa il verificati ";
    initializare(v1);
    citire(v1);
    egalitate(v, v1);
    dealocare(v);
    return 0;
}
