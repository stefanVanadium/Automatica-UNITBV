import numpy as np
import matplotlib.pyplot as plt
import math
from sympy import *

def f(x):
    f_val = np.log(x) + x
    return f_val

a, b = 0.05, 2
f_vals = []
x_vals = np.arange(a, b, 0.05)
for x in x_vals:
    f_val = f(x)
    f_vals.append(f_val)

#plt.plot(x_vals, f_vals)
#plt.show()

def injumatatire_interval(a, b, tol):
    e = []
    x = (a + b) / 2

    while (abs(f(x)) > tol):
        x = (a + b) / 2
        if f(a) * f(x) <= 0:
            b = x
        else:
            a = x
        e.append(abs(f(x)))

    return x, e

tol = 1e-14
x1, e1 =  injumatatire_interval(a, b, tol)
print(x1)


def secanta_fixa(a, b, tol):
    x1 = a
    x2 = b
    y1 = f(x1)
    y2 = f(x2)

    m = (y2 - y1) / (x2 - x1)
    x = x2 - y2 / m

    e = []
    while abs(f(x)) > tol:
        x = x - f(x) / m
        e.append(abs(f(x)))

    return x, e

x2, e2 =  secanta_fixa(a, b, tol)
print(x2)


def secanta_variabila(a, b, tol):
    x1 = a
    x2 = b
    y1 = f(x1)
    y2 = f(x2)

    m = (y2 - y1) / (x2 - x1)
    x = x2 - y2 / m

    e = []
    while abs(f(x)) > tol:
        m = (y2 - f(x)) / (x2 - x)
        x = x - f(x) / m
        e.append(abs(f(x)))

    return x, e

x3, e3 = secanta_variabila(a, b, tol)
print(x3)

x = symbols('x')
f = x + log(x)
df = diff(f, x)

print(f)
print(df)

f = lambdify(x, f)
df = lambdify(x, df)

def newton_raphson(x1, tol):
    y1 = f(x1)
    df1 = df(x1)

    x = x1 - y1 / df1

    e = []
    while abs(f(x)) > tol:
        x = x - f(x) / df(x)
        e.append(abs(f(x)))

    return x, e

x4, e4 = newton_raphson(b, tol)
print(x4)
print(e4)

f_vals = []
x_vals = np.arange(a, b, 0.05)
for x in x_vals:
    f_val = f(x)
    f_vals.append(f_val)

#plt.plot(x_vals, f_vals)
#plt.plot(x1, f(x1), 'r*')
#plt.show()

plt.semilogy(e1)
plt.semilogy(e2)
plt.semilogy(e3)
plt.semilogy(e4)

plt.xlabel('Nr iteratii')
plt.ylabel('Eroare')
plt.legend(['Metoda injumatatirii intervalului', 'Metoda secantei fixe', 'Metoda secantei variabilei', 'Metoda Newton'])
plt.show()