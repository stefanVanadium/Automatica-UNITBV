#include <bits/stdc++.h>

using namespace std;

struct temp
{
    int nr_temp;
    float* valori_C;
};

void initializare(temp& t)
{
    t.nr_temp = 0;
    t.valori_C = new float[24]; // Am schimbat dimensiunea alocată pentru a corespunde cu 24 de ore dintr-o zi
}

void citire(temp& t) {
    cout << "Introduceti numarul de temperaturi: ";
    cin >> t.nr_temp;

    // Verificăm dacă numărul de temperaturi este mai mare decât dimensiunea alocată
    if (t.nr_temp > 24) {
        cout << "Numarul de temperaturi este prea mare pentru o zi!" << endl;
        return;
    }

    cout << "Introduceti valorile temperaturilor: \n";
    t.valori_C = new float[t.nr_temp];
    for (int i = 0; i < t.nr_temp; ++i) {
        cout << "Temperatura masurata la ora " << i + 1 << ": ";
        cin >> t.valori_C[i];
    }
}

void afisareCelsius(temp* t, int zile)
{
    for(int j = 0; j < zile; j++)
    {
        cout << "Temperaturile in grade Celsius din ziua " << j + 1 << " sunt: \n";
        for (int i = 0; i < t[j].nr_temp; ++i)
        {
            cout << t[j].valori_C[i] << " ";
        }
        cout << "\n";
    }
}

void afisareFahrenheit(temp* t, int zile)
{

    for(int j = 0; j < zile; j++)
    {
        cout << "Temperaturile in grade Fahrenheit din ziua " << j + 1 << " sunt: \n";
        for (int i = 0; i < t[j].nr_temp; ++i)
        {
            cout << 9*t[j].valori_C[i]/5 + 32 << " ";
        }
        cout << "\n";
    }
}

void maxima(temp* t, int zile) {
    for(int j = 0; j < zile; j++)
    {
        cout << "Temperatura maxima din ziua " << j + 1 << " este: \n";

        float temperatura_maxima = t[j].valori_C[0];

        for (int i = 1; i < t[j].nr_temp; ++i) {
            if (t[j].valori_C[i] > temperatura_maxima) {
                temperatura_maxima = t[j].valori_C[i];
            }
        }
        cout << temperatura_maxima << " \n\n";
    }
}



void dealocare(temp* t, int zile)
{
    for (int i = 0; i < zile; i++) {
        delete[] t[i].valori_C;
    }
    delete[] t;
}

int main() {
    int zile;
    cout << "Introduceti numarul de zile: ";
    cin >> zile;

    temp* t = new temp[zile];
    for (int i = 0; i < zile; i++) {
        initializare(t[i]);
        cout << "Ziua " << i + 1 << ":" << "\n";
        citire(t[i]);
    }
    afisareCelsius(t, zile);
    afisareFahrenheit(t, zile);
    dealocare(t, zile);
    maxima(t, zile);
    return 0;
}