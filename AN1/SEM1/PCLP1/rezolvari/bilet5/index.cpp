#include <bits/stdc++.h>

using namespace std;

void citire();
void transform();
void afisare();

void citire(char* s)
{
    cout<< "Introduceti sirul de caractere: ";
    cin.getline(s, 100);
}

void afisare(char* s)
{
    cout << "Sirul de caractere este: ";
    for (int i = 0; i < strlen(s); i++)
    {
        cout << s[i];
    }
}

long transform(char*) {
    long decimalValue = 0;

    // Loop through each character in the string
    for (int i = 0; hexString[i] != '\0'; ++i) {
        char digit = hexString[i];

        // Convert ASCII character to its numeric value
        int value;
        if (digit >= '0' && digit <= '9')
            value = digit - '0';
        else if (digit >= 'a' && digit <= 'f')
            value = digit - 'a' + 10;
        else if (digit >= 'A' && digit <= 'F')
            value = digit - 'A' + 10;
        else {
            cerr << "Error: Invalid hexadecimal character: " << digit << endl;
            return -1; // Signal an error
        }

        // Multiply the current value by 16 and add the new value
        decimalValue = decimalValue * 16 + value;
    }

    return decimalValue;
}

int main()
{
    char* s = new char[100];
    citire(s);
    afisare(s);
    transform(s);
}