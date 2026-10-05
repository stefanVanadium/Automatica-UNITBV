#include <bits/stdc++.h>

using namespace std;

struct nrtelefon
{
    char prefix[6]; //ex Ro +40, Finlanda +358
    char numar[7];
};

struct persoana
{
    char nume[20], prenume[20];
    nrtelefon telefon;
};

void citireTelefon(nrtelefon &t)
{
    cout << "Introduceti prefixul: ";
    cin >> t.prefix;
    if(t.prefix[0] != '+' )
    {
        cout <<"Prefixul nu este valid. Reintroduceti prefixul\n";
        cin >> t.prefix;
    }
    cout << "Introduceti numarul de telefon: ";
    cin >> t.numar;
    if(strlen(t.numar) != 9)
    {
        cout <<"Numarul nu este valid. Reintroduceti numarul\n";
        cin >> t.numar;
    }
}

void comparare(nrtelefon &t, nrtelefon &t1)
{
    bool egalitate = true;

    // Comparăm prefixul
    for (int i = 0; t.prefix[i] != '\0' && t1.prefix[i] != '\0'; i++) {
        if (t.prefix[i] != t1.prefix[i]) {
            egalitate = false;
            break;
        }
    }

    // Comparăm numărul de telefon
    for (int i = 0; t.numar[i] != '\0' && t1.numar[i] != '\0'; i++) {
        if (t.numar[i] != t1.numar[i]) {
            egalitate = false;
            break;
        }
    }

    if (egalitate)
        cout << "Numerele sunt egale\n";
    else
        cout << "Numerele nu sunt egale\n";
}
// 743905266


void afisareTelefon(nrtelefon &t)
{
    cout << "Numarul de telefon introdus este ";
    for(int i = 0; i < strlen(t.prefix); i++)
    {
        cout << t.prefix[i];
    }
    for(int i = 0; i < strlen(t.numar); i++)
    {
        cout << t.numar[i];
    }
}

void citirePersoana(persoana &p, int nr)
{
    for(int i = 0; i < nr; i++ )
    {
        cout << "Personalul numarul " << i + 1 << ": \n";
        cout << "Introduceti numele: ";
        cin >> p.nume;
        cout << "Introduceti prenumele: ";
        cin >> p.prenume;
        cout << "Introduceti numarul de telefon: \n";
        citireTelefon(p.telefon);
    }
}

int main()
{
    nrtelefon t, t1;
    int nr;
    persoana* p = new persoana[nr];
    citireTelefon(t);
    afisareTelefon(t);
    cout << "\nIntroduceti al doilea numar de telefon:";
    citireTelefon(t1);
    comparare(t, t1);

    cout << "Introduceti numarul persoanelor: ";
    cin >> nr;
    citirePersoana(*p, nr);
}