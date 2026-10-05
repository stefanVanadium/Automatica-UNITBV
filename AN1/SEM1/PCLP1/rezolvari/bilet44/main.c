#include <stdio.h>
#include <stdlib.h>
#include <ctype.h>
#include <string.h>

void citesteParola(char *parola) {
    printf("Introduceti parola: ");
    char caracter;
    int index = 0;

    while (1) {
        caracter = getch(); // Utilizăm getch() pentru a citi caracterele fără a le afișa pe ecran

        if (caracter == 13) { // Enter
            parola[index] = '\0';
            break;
        } else if (caracter == 8 && index > 0) { // Backspace
            printf("\b \b");
            index--;
        } else {
            parola[index] = caracter;
            printf("*");
            index++;
        }
    }
    printf("\n");
}

int verificaParola(char *parola) {
    int lungime = strlen(parola);
    int literaMare = 0, literaMica = 0, cifra = 0;

    if (lungime <= 8) {
        return 0; // Parola nu indeplineste conditiile
    }

    for (int i = 0; i < lungime; i++) {
        if (isupper(parola[i])) {
            literaMare = 1;
        } else if (islower(parola[i])) {
            literaMica = 1;
        } else if (isdigit(parola[i])) {
            cifra = 1;
        }
    }

    return literaMare && literaMica && cifra;
}

void criptare(char *parola, char *parolaCriptata) {
    // Implementeaza aici algoritmul de criptare
    // Exemplu simplu: Inverseaza sirul de caractere
    int lungime = strlen(parola);
    for (int i = 0; i < lungime; i++) {
        parolaCriptata[i] = parola[lungime - i - 1];
    }
    parolaCriptata[lungime] = '\0';
}

void decriptare(char *parolaCriptata, char *parolaDecriptata) {
    // Implementeaza aici algoritmul de decriptare
    // Exemplu simplu: Inverseaza sirul de caractere
    int lungime = strlen(parolaCriptata);
    for (int i = 0; i < lungime; i++) {
        parolaDecriptata[i] = parolaCriptata[lungime - i - 1];
    }
    parolaDecriptata[lungime] = '\0';
}

int main() {
    char parola[50], parolaCriptata[50], parolaIntrodusa[50], parolaDecriptata[50];
    int incercari = 3;

    // Citeste, verifica si cripteaza parola
    citesteParola(parola);
    if (verificaParola(parola)) {
        criptare(parola, parolaCriptata);
        FILE *fisier = fopen("parola.txt", "w");
        if (fisier != NULL) {
            fprintf(fisier, "%s", parolaCriptata);
            fclose(fisier);
            printf("Parola criptata a fost salvata in fisier.\n");
        } else {
            printf("Eroare la deschiderea fisierului pentru scriere.\n");
            return 1;
        }
    } else {
        printf("Parola nu indeplineste conditiile.\n");
        return 1;
    }

    // Verifica parola introdusa
    do {
        citesteParola(parolaIntrodusa);
        decriptare(parolaIntrodusa, parolaDecriptata);
        if (strcmp(parolaDecriptata, parolaCriptata) == 0) {
            printf("Parola corecta. Acces permis.\n");
            break;
        } else {
            incercari--;
            printf("Parola incorecta. Mai aveti %d incercari.\n", incercari);
        }
    } while (incercari > 0);
    printf("modifica parola:\n");
    // Solicita modificarea parolei
    if (incercari > 0) {
        citesteParola(parola);
        if (verificaParola(parola)){
        criptare(parola, parolaCriptata);
        FILE *fisier = fopen("parola.txt", "w");
        if (fisier != NULL) {
            fprintf(fisier, "%s", parolaCriptata);
            fclose(fisier);
            printf("Parola modificata a fost salvata in fisier.\n");
        } else {
            printf("Eroare la deschiderea fisierului pentru scriere.\n");
            return 1;
        }
        }else {
        printf("Parola nu indeplineste conditiile.\n");
        return 1;
    }
    } else {
        printf("Numarul maxim de incercari a fost atins. Accesul este blocat.\n");
    }

    return 0;
}
