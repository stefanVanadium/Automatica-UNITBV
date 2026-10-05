import numpy as np
import matplotlib.pyplot as plt
from sympy import symbols, log, diff, lambdify

def f(x): return np.log(x) + x

a, b = 0.05, 2.0
tol = 1e-14

# 1. Bisection
def bisection(a, b, tol):
    e = []
    while abs(f((a+b)/2)) > tol:
        c = (a + b) / 2
        if f(a) * f(c) <= 0:
            b = c
        else:
            a = c
        e.append(abs(f(c)))
    return (a + b)/2, e

x1, e1 = bisection(a, b, tol)

# 2. Secantă fixă (Newton cu derivată constantă)
def secanta_fixa(a, b, tol):
    x1, x2 = a, b
    y1, y2 = f(x1), f(x2)
    m = (y2 - y1) / (x2 - x1)
    x = x2 - y2 / m
    e = []
    while abs(f(x)) > tol:
        x = x - f(x) / m
        e.append(abs(f(x)))
    return x, e

x2, e2 = secanta_fixa(a, b, tol)

# 3. Secantă variabilă
def secanta_variabila(a, b, tol):
    x1, x2 = a, b
    y1, y2 = f(x1), f(x2)
    x = x2 - y2 * (x2 - x1) / (y2 - y1)
    e = []
    while abs(f(x)) > tol:
        y = f(x)
        m = (y2 - y) / (x2 - x)
        x = x - y / m
        x2, y2 = x, y
        e.append(abs(y))
    return x, e

x3, e3 = secanta_variabila(a, b, tol)

# 4. Newton – cu sympy
x_sym = symbols('x')
f_sym = x_sym + log(x_sym)
df_sym = diff(f_sym, x_sym)
f_num = lambdify(x_sym, f_sym, 'numpy')
df_num = lambdify(x_sym, df_sym, 'numpy')

def newton(x0, tol):
    e = []
    x = x0 - f_num(x0) / df_num(x0)
    while abs(f_num(x)) > tol:
        x = x - f_num(x) / df_num(x)
        e.append(abs(f_num(x)))
    return x, e

x4, e4 = newton(b, tol)

print(f"Bisection     → {x1:.14f}")
print(f"Secantă fixă  → {x2:.14f}")
print(f"Secantă var.  → {x3:.14f}")
print(f"Newton        → {x4:.14f}")

plt.semilogy(e1, label="Bisection")
plt.semilogy(e2, label="Secantă fixă")
plt.semilogy(e3, label="Secantă variabilă")
plt.semilogy(e4, label="Newton")
plt.xlabel("iterații")
plt.ylabel("eroare")
plt.legend()
plt.grid(True)
plt.show()