#include <bits/stdc++.h>
#include <string.h>

using namespace std;

struct carte
{
    char titlu[30];
    char autor[30];
    int nr_buc;
};

struct lista_carti
{
    int nr_carti;
    carte* lista;
}l;

void initializare()
{
    l.nr_carti = 0;
    l.lista = nullptr;
}

void citire(lista_carti& l)
{
    cout << "Introduceti numarul de carti: ";
    cin >> l.nr_carti;
    cin.ignore();
    l.lista = new carte[l.nr_carti];
    for (int i = 0; i < l.nr_carti; i++)
    {
        cout << "Introduceti datele pentru cartea " << i + 1 << ":\n";
        cout << "Introduceti titlul: ";
        cin.getline(l.lista[i].titlu, 30);

        cout << "Introduceti autorul: ";
        cin.getline(l.lista[i].autor, 30);

        cout << "Introduceti numarul de bucuri: ";
        cin >> l.lista[i].nr_buc;
        cin.ignore();
    }
}


void afisare(lista_carti l)
{
    cout << "Cartile introduse sunt: \n";
    for(int i = 0; i < l.nr_carti; i++)
    {
        cout << '"' << l.lista[i].titlu << '"' << " ";
        cout << "- " << l.lista[i].autor << " ";
        cout << l.lista[i].nr_buc << " \n";
    }
}

void adaugareCarte(lista_carti& l)
{
    cout<< "Introduceti datele cartii pe care vreti sa o aduagati: \n";
    citire(l);
    for(int i = 0; i < l.nr_carti; i++)
    {
        if(strcmp)
    }
}

int main()
{
    initializare();
    citire(l);
    afisare(l);
    return 0;
}