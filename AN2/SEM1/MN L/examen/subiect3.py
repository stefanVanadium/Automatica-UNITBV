import numpy as np

A = np.array([
    [1.30, 0.92, 0.42, 0.23],
    [0.61, 1.00, 0.002, 1.20],
    [0.16, 1.50, 0.20, 1.04],
    [0.97, 0.56, 1.63, 0.30]
])
b = np.array([0.41, 0.41, 0.98, 0.79])

suma_A = np.sum(A)
suma_b = np.sum(b)

print("Ex3: a)")
print("Suma elementelor lui A =", suma_A)
print("Suma elementelor lui b =", suma_b)
print()

x = np.linalg.solve(A, b)

print("Ex3: b)")
print("Soluția sistemului x =", x)
print()

print("Ex3: c)")
eroare = np.sum(np.abs(A @ x - b))
print("eroare =", eroare)