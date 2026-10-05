#include <bits/stdc++.h>
#include <conio.h>

using namespace std;

ofstream fout("parola.txt");

void citire(char *s)
{
    cout << "Introduceti parola: ";
    char caracter;
    int index = 0;
    //pe masura ce citim parola, afisam *
    while (true)
    {
        caracter = getch();
        if (caracter == 13)
            break;
        else if (caracter == 8 && index > 0)
        {
            cout << "\b \b";
            index--;
        }
        else
        {
            cout << "*";
            s[index] = caracter;
            index++;
        }
    }
    s[index] = '\0';
}

void afisare(char *s)
{
    cout << "\nParola ta este: ";
    fout << "\nParola ta este: ";
    for (int i = 0; i < strlen(s); i++)
    {
        cout << s[i];
        fout << s[i];
    }
}

void verif(char *s)
{
    bool numar = false;
    bool upper = false;
    bool lower = false;

    if (strlen(s) < 8)
    {
        cout << "\nParola trebuie sa fie de cel putin 8 caractere.";
        return;
    }
    for(int i = 0; i < strlen(s); i++)
        {
            if(isdigit(s[i]))
                numar = true;
            else if(isupper(s[i]))
                upper = true;
            else if(islower(s[i]))
                lower = true;
        }
     if (!numar)
    {
        cout << "\nParola trebuie sa contina cel putin o cifra.";
        return;
    }
    if (!upper)
    {
        cout << "\nParola trebuie sa contina cel putin o litera mare.";
        return;
    }
    if (!lower)
    {
        cout << "\nParola trebuie sa contina cel putin o litera mica.";
        return;
    }

    cout << "\nParola este valida.";
}

void criptare(char *s)
{
    char XOR = 'X';

    char *copie = s;
    while (*s != '\0')
    {
        *s = *s ^ XOR;
        s++;
    }

    cout << "\nParola criptata este: ";
    fout << "\nParola criptata este: ";
    while (*copie != '\0')
    {
        cout << *copie;
        fout << *copie;
        copie++;
    }
}

void decriptare(char *s)
{
    char XOR = 'X';
    char *copie = s;

    while (*s != '\0')
    {
        *s = *s ^ XOR;
        s++;
    }

    cout << "\nParola decriptata este: " << copie << "\n";
    fout << "\nParola decriptata este: " << copie << "\n";
}

void verif1(char *s, char *s1)
{
    int incercari = 3;
    while (incercari > 0)
    {
        cout << "Introduceti parola din nou: ";
        citire(s1);

        if (strcmp(s, s1) == 0)
        {
            cout << "\nParolele coincid";
            return;
        }
        else
        {
            cout << "\nParolele nu coincid. Mai aveti " << incercari - 1 << " incercari.\n";
            incercari--;
            if (incercari == 0)
            {
                cout << "\nNu mai aveti incercari disponibile.";
                break;
            }
        }
    }
}

void modificare(char *s)
{
    cout<<"Parola modificata este: ";
    fout<<"Parola modificata este: ";
    citire(s);
    afisare(s);

}

int main()
{
    char s[100], s1[100];
    citire(s);
    afisare(s);
    verif(s);
    criptare(s);
    decriptare(s);
    verif1(s,s1);
    modificare(s);
    fout.close();

    return 0;
}