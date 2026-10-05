import matplotlib.pyplot as plt
import numpy as np

def f(x):
    return np.log(x) + 2 * x

x = f(10)
result_12a = x
print("Result 12a:", result_12a)

def sec_var(a, b, tolerance=1e-10):
    x1 = a
    x2 = b
    f1 = f(x1)
    f2 = f(x2)

    m = (f2 - f1) / (x2 - x1)
    x = x2 - f2 / m

    e = []
    while abs(f(x)) > tolerance:
        x = x - f(x) / m
        e.append(abs(f(x)))

    return x, e

result_12bx, result_12bea = sec_var(0.02, 5)
result_12be = result_12bea[-1]
print("Result 12b x:", result_12bx)
print("Result 12b errors:", result_12be)

# Vizualizare grafica
x_vals = np.arange(0.01, 12, 0.05)
f_vals = f(x_vals)

plt.figure(figsize=(10, 6))
plt.plot(x_vals, f_vals, label='f(x) = ln(x) + 2x')
plt.plot(result_12bx, f(result_12bx), 'ro', markersize=10, label=f'Radacina: x={result_12bx:.6f}')
plt.plot(10, result_12a, 'gx', markersize=10, label=f'f(2)={result_12a:.6f}')
plt.axhline(y=0, color='k', linestyle='--', alpha=0.3)
plt.grid(True, alpha=0.3)
plt.xlabel('x')
plt.ylabel('f(x)')
plt.legend()
plt.title('Metoda Secantei Fixe')
plt.show()