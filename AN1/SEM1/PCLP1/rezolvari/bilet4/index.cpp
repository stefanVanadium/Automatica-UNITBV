#include <bits/stdc++.h>

using namespace std;

struct punct
{
    float x, y;
};

struct triunghi
{
    punct a, b,c;
};

void citire_p(triunghi &t)
{
    cout << "a.x = ";
    cin >> t.a.x;
    cout << "a.y = ";
    cin >> t.a.y;
    cout << "b.x = ";
    cin >> t.b.x;
    cout << "b.y = ";
    cin >> t.b.y;
    cout << "c.x = ";
    cin >> t.c.x;
    cout << "c.y = ";
    cin >> t.c.y;
}

void afisare(triunghi t)
{
    cout << "Triunghiul are cooronatele:";
    cout << "A(" << t.a.x << ", " << t.a.y << "), B(" << t.b.x << ", " << t.b.y << "), C(" << t.c.x << ", " << t.c.y << ")\n";
}

void distanta(triunghi t)
{
    float a = sqrt((t.a.x - t.b.x) * (t.a.x - t.b.x) + (t.a.y - t.b.y) * (t.a.y - t.b.y));
    float b = sqrt((t.b.x - t.c.x) * (t.b.x - t.c.x) + (t.b.y - t.c.y) * (t.b.y - t.c.y));
    float c = sqrt((t.c.x - t.a.x) * (t.c.x - t.a.x) + (t.c.y - t.a.y) * (t.c.y - t.a.y));
    cout << "Distanta dintre punctele A(" << a << ")"<< "\n";
    cout << "Distanta dintre punctele B(" << b << ")"<< "\n";
    cout << "Distanta dintre punctele C(" << c << ")"<< "\n";
}
void verificareEgalitate(triunghi t)
{
    if (t.a.x == t.b.x && t.a.y == t.b.y)
        cout << "Punctele A(" << t.a.x << "," << t.a.y << ") si B(" << t.b.x << "," << t.b.y << ") au coordonate identice\n";
    else if (t.b.x == t.c.x && t.b.y == t.c.y)
        cout << "Punctele B(" << t.b.x << "," << t.b.y << ") si C(" << t.c.x << "," << t.c.y << ") au coordonate identice\n";
    else if (t.c.x == t.a.x && t.c.y == t.a.y)
        cout << "Punctele C(" << t.c.x << "," << t.c.y << ") si A(" << t.a.x << "," << t.a.y << ") au coordonate identice\n";
    else
        cout << "Nici o pereche de puncte nu are coordonate identice\n";
}

void arie(triunghi t)
{
    float a = sqrt((t.a.x - t.b.x) * (t.a.x - t.b.x) + (t.a.y - t.b.y) * (t.a.y - t.b.y));
    float b = sqrt((t.b.x - t.c.x) * (t.b.x - t.c.x) + (t.b.y - t.c.y) * (t.b.y - t.c.y));
    float c = sqrt((t.c.x - t.a.x) * (t.c.x - t.a.x) + (t.c.y - t.a.y) * (t.c.y - t.a.y));
    float p = (a + b + c) / 2;
    float s = sqrt(p * (p - a) * (p - b) * (p - c));
    cout << "Aria triunghiului este: " << s;
}

int main()
{
    //se aloca dinamic un tablou de obiecte triunghi
    triunghi *t;
    t = new triunghi;
    citire_p(*t);
    afisare(*t);
    distanta(*t);
    verificareEgalitate(*t);
    arie(*t);
}