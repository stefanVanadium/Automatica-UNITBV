#include <bits/stdc++.h>

using namespace std;
ofstream fout("masini.txt");

void citireM();
void afisareM();
void init();
void adaug();
void elimin();
void afisare();
void ordonare1();
void ordonare2();
void afisare();

struct car
{
    char brand[50];
    char model[50];
    int year;
};

struct lista_masini
{
    int nr;
    car* masini;
}masina;

void citireM()
{
    for(int i = 0; i < masina.nr; i++)
    {
        cout << "Masina " << i + 1 << ":" << "\n";
        cout << "Intoduceti brand-ul masinii:";
        cin >>  masina.masini[i].brand;
        cout << "Intoduceti modelul masinii:";
        cin >> masina.masini[i].model;
        cout << "Intoduceti anul fabricatiei:";
        cin >> masina.masini[i].year;
        cout << "\n";
    }
}

void afisareM()
{
    for(int i = 0; i < masina.nr; i++)
    {
        cout << "\n";
        cout << "Masina " << i + 1 << ":" << "\n";
        cout << "Brand-ul masinii:" << masina.masini[i].brand << endl;
        cout << "Modelul masinii:" << masina.masini[i].model << endl;
        cout << "Anul fabricatiei:" << masina.masini[i].year << endl;
    }
}

void init()
{
    masina.nr = 0;
    masina.masini = NULL;
}

void adaug()
{
    masina.nr++;
    masina.masini = new car[masina.nr];
    cout << "Noul numar de masini este " << masina.nr << "\n";
    cout << "Intoduceti o noua masina:" << "\n";
    citireM();
    afisareM();
}

void elimin()
{
    cout << "Introduceti numarul masinii pe care doriti sa o stergeti:";
    int nr;
    cin >> nr;
    for(int i = nr - 1; i < masina.nr - 1; i++)
    {
        masina.masini[i] = masina.masini[i + 1];
    }
    masina.nr--;
    afisareM();
}

void ordonare1()
{
    //dupa marca si model
    for( int i = 0; i < masina.nr - 1; i++ )
    {
        for( int j = i + 1; j < masina.nr; j++ )
        {
            if(strcmp(masina.masini[i].brand, masina.masini[j].brand)  >0)
            {
                car aux = masina.masini[i];
                masina.masini[i] = masina.masini[j];
                masina.masini[j] = aux;
            }
            if(strcmp(masina.masini[i].brand, masina.masini[j].brand) == 0)
            {
                if(strcmp(masina.masini[i].model, masina.masini[j].model) >0)
                {
                    car aux = masina.masini[i];
                    masina.masini[i] = masina.masini[j];
                    masina.masini[j] = aux;
                }
            }
        }
    }

    cout << "Masinile ordonate dupa marca si model sunt:" << "\n";
    afisareM();
}

void ordonare2()
{
    //dupa anul fabricatiei
    for( int i = 0; i < masina.nr - 1; i++ )
    {
        for( int j = i + 1; j < masina.nr; j++ )
        {
           if((masina.masini[i].year, masina.masini[j].year) > 0 )
           {
               car aux = masina.masini[i];
               masina.masini[i] = masina.masini[j];
               masina.masini[j] = aux;
           }
        }
    }

    cout << "Masinile ordonate dupa anul fabricatiei sunt:" << "\n";
    afisareM();
}

void afisare()
{
    fout << "lista completa de masini este:" << "\n";
    for(int i = 0; i < masina.nr; i++)
        {
            fout << "\n";
            fout << "Masina " << i + 1 << ":" << "\n";
            fout << "Brand-ul masinii:" << masina.masini[i].brand << endl;
            fout << "Modelul masinii:" << masina.masini[i].model << endl;
            fout << "Anul fabricatiei:" << masina.masini[i].year << endl;
        }
}

int main()
{
    init();
    cout << "Numarul de masini este:";
    cin >> masina.nr;
    masina.masini = new car[masina.nr];
    citireM();
    afisareM();
    adaug();
    elimin();
    ordonare1();
    ordonare2();
    afisare();
    return 0;
}