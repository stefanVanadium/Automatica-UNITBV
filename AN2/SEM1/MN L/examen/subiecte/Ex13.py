import matplotlib.pyplot as plt
import numpy as np

def f(x):
    return np.log(x) - np.sin(x)

x = f(2)
result_13a = x
print("Result 13a:", result_13a)

def inj_int(a, b, tol=1e-14):
    e = []
    x = (a+b)/2
    
    while (abs(f(x)) > tol):
        x = (a+b)/2
        if f(a)*f(x) <= 0:
            b = x
        else:
            a = x
        e.append(abs(f(x)))
        
    return x, e

result_13bx, result_13bea = inj_int(1, 2*np.pi)
result_13be = result_13bea[-1] if result_13bea else 0
print("Result 13b x:", result_13bx)
print("Result 13b errors:", result_13be)
print("Number of iterations:", len(result_13bea))

# Vizualizare grafica
x_vals = np.arange(0.01, 10, 0.05)
f_vals = f(x_vals)

plt.figure(figsize=(10, 6))
plt.plot(x_vals, f_vals, label='f(x) = ln(x) - sin(x)')
plt.plot(result_13bx, f(result_13bx), 'ro', markersize=10, label=f'Radacina: x={result_13bx:.6f}')
plt.plot(2, result_13a, 'gx', markersize=10, label=f'f(2)={result_13a:.6f}')
plt.axhline(y=0, color='k', linestyle='--', alpha=0.3)
plt.grid(True, alpha=0.3)
plt.xlabel('x')
plt.ylabel('f(x)')
plt.legend()
plt.title('Metoda Injumatatirii Intervalului')
plt.show()