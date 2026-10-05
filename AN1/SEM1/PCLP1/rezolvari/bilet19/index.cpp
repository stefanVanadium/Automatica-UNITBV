#include <bits/stdc++.h>

using namespace std;

struct data
{
    unsigned int zi, luna, an;
};

void citire();
void afisare();
void compar();
void diferenta();
struct angajat
{
    char nume[30];
    data start, end; // prima si ultima zi de concediu
};

void citire(data* d, int dim)
{
    for (int i = 0; i < dim; i++)
    {
        cout << "Data " << i +1 << "\n";
        cout << "Introduceti ziua: ";
        cin >> d[i].zi;
        if(d[i].zi < 0 || d[i].zi > 31)
        {
            cout << "Ziua nu exista. Introduceti o zi valida.\n";
            break;
        }
        cout << "Introduceti luna: ";
        cin >> d[i].luna;
        if(d[i].luna < 0 || d[i].luna > 12)
        {
            cout << "Luna nu exista. Introduceti o luna valida.\n";
            break;
        }
        cout << "Introduceti anul: ";
        cin >> d[i].an;
    }
}

void afisare(data* d, int dim)
{
    for (int i = 0; i < dim; i++)
    {
        cout << d[i].zi;
        switch(d[i].luna)
        {
            case 1:
                cout <<(" ianuarie ");
                break;
            case 2:
                cout <<(" februarie ");
                break;
            case 3:
                cout <<(" martie ");
                break;
            case 4:
                cout <<(" aprilie ");
                break;
            case 5:
                cout <<(" mai ");
                break;
            case 6:
                cout <<(" iunie ");
                break;
            case 7:
                cout <<(" iulie ");
                break;
            case 8:
                cout <<(" august ");
                break;
            case 9:
                cout <<(" septembrie ");
                break;
            case 10:
                cout <<(" octombrie ");
                break;
            case 11:
                cout <<(" noiembrie ");
                break;
            case 12:
                cout <<(" decembrie ");
                break;
        }
        cout << d[i].an << "\n";
    }
}

void diferenta(data* d, int dim, int val)
{
    cout << "\nSuma de " << val << " zile este: \n";
    for(int i = 0; i < dim; i++)
    {
        if(val + d[i].zi < 31)
        {
            d[i].zi = val + d[i].zi;
        }
        else
        {
            d[i].zi = val + d[i].zi - 31;
            d[i].luna = d[i].luna + 1;
        }
    }
    afisare(d, dim);
}

void diferenta(data* d, int dim, data* d1)
{
    cout << "\nDiferenta de zile este: \n";
    data* d3 = new data[dim];
    for(int i = 0; i < dim; i++)
    {
        d3[i].zi = d[i].zi - d1[i].zi;
        d3[i].luna = d[i].luna - d1[i].luna;
        d3[i].an = d[i].an - d1[i].an;
        afisare(d3, dim);
    }
}

int main()
{
    int dim;
    angajat* lista = new angajat[dim];
    data* d = new data[dim];
    citire(d, dim);
    afisare(d, dim);
    return 0;
}