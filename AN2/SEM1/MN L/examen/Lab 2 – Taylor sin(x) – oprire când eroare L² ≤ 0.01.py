import numpy as np
import math
import matplotlib.pyplot as plt

x = np.linspace(-np.pi, np.pi, 200)
true_f = np.sin(x)
approx = np.zeros_like(x)

plt.plot(x, true_f, label="sin(x) exact")

for i in range(10):
    term = ((-1)**i * x**(2*i + 1)) / math.factorial(2*i + 1)
    approx += term
    err_l2 = np.linalg.norm(true_f - approx, 2)
    print(f"ordin {i+1} → eroare L2 = {err_l2:.6f}")
    
    if err_l2 <= 0.01:
        plt.plot(x, approx, label=f"ordin {i+1} (ajunge sub 0.01)")
        break

plt.grid(True)
plt.xlabel('x')
plt.ylabel('f(x)')
plt.legend()
plt.show()