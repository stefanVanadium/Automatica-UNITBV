#include <bits/stdc++.h>

using namespace std;

struct punct
{
    int x, y;
};

struct poligon
{
    int nr;
    punct* varfuri;
};

void citire();
void afisare();
void distanta();
void verificare();
void initializarePoligon();
void citirePoligon();
void afisarePoligon();
void parametruPoligon();
void verificareVarfPoligon();
void dealocare();

void citire( punct &t )
{
    cout << "Introduceti coordonatele punctului: \n";
    cout << "x = ";
    cin >> t.x;
    cout << "y = ";
    cin >> t.y;
}

void afisare( punct &t )
{
    cout << "Punctul T este T(" << t.x << ", "<< t.y << ")" << "\n";
}

void distanta( punct &t, punct &m )
{
    float a = sqrt( (t.x - m.x) * (t.x - m.x) + (t.y - m.y) * (t.y - m.y) );
    cout << "Distanta dintre punctele T(" << t.x << ", "<< t.y << ") si M(" << m.x << ", "<< m.y << ") este: " << a << "\n";
}

void verificare(punct &t, punct &m)
{
    if(t.x == m.x && t.y == m.y)
        cout << "Punctele T(" << t.x << ", "<< t.y << ") si M(" << m.x << ", "<< m.y << ") au aceeasi coordonate\n";
    else
        cout << "Punctele T(" << t.x << ", "<< t.y << ") si M(" << m.x << ", "<< m.y << ") nu au aceeasi coordonate\n";
}

void initializarePoligon( poligon &p )
{
    cout << "Introduceti numarul de varfuri ale poligonului: ";
    cin >> p.nr;
    p.varfuri = new punct[p.nr];
}

void citirePoligon( poligon &p )
{
    cout << "Introduceti coordonatele varfurilor: \n";
    for(int i = 0; i < p.nr; i++)
    {
        cout << "Varful " << i + 1 << ": \n";
        cout << "x = ";
        cin >> p.varfuri[i].x;
        cout << "y = ";
        cin >> p.varfuri[i].y;
    }
}

void afisarePoligon( poligon &p )
{
    cout << "Poligonul este: \n";
    for(int i = 0; i < p.nr; i++)
    {
        cout << "Varful " << i + 1 << " este: " << p.varfuri[i].x << ", " << p.varfuri[i].y << "\n";
    }
}

void parametruPoligon( poligon &p )
{
    for(int i = 0; i < p.nr; i++)

    cout << "Latura " << i+1 << " este: " << sqrt( (p.varfuri[i].x - p.varfuri[(i+1)%p.nr].x) * (p.varfuri[i].x - p.varfuri[(i+1)%p.nr].x) + (p.varfuri[i].y - p.varfuri[(i+1)%p.nr].y) * (p.varfuri[i].y - p.varfuri[(i+1)%p.nr].y) ) << "\n";
    int perimetru = 0;
    for(int i = 0; i < p.nr; i++)
    {
        perimetru = perimetru + sqrt( (p.varfuri[i].x - p.varfuri[(i+1)%p.nr].x) * (p.varfuri[i].x - p.varfuri[(i+1)%p.nr].x) + (p.varfuri[i].y - p.varfuri[(i+1)%p.nr].y) * (p.varfuri[i].y - p.varfuri[(i+1)%p.nr].y) );
    }
    cout << "Perimetruul poligonului este: " << perimetru << "\n";
}

void verificareVarfPoligon(punct &t, poligon &p)
{
    for (int i = 0; i < p.nr; i++)
    {
        if (t.x == p.varfuri[i].x && t.y == p.varfuri[i].y)
            cout << "Punctul T(" << t.x << ", " << t.y << ") se afla pe varful " << i + 1 << "\n";
        else
            cout << "Punctul T(" << t.x << ", " << t.y << ") nu se afla pe varful " << i + 1 << "\n";
    }
}

void dealocare( poligon &p )
{
    delete [] p.varfuri;
    p.varfuri = NULL;
    p.nr = 0;
    cout << "Memoria a fost dealocata\n";
}

int main()
{
    punct t, m;
    poligon p;
    citire(t);
    afisare(t);
    citire(m);
    distanta(t, m);
    verificare(t, m);
    initializarePoligon( p);
    citirePoligon( p);
    afisarePoligon( p);
    parametruPoligon( p);
    verificareVarfPoligon(t, p);
    dealocare( p );
    return 0;
}