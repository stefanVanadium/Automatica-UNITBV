import numpy as np
import math
import matplotlib.pyplot as plt

x  = np.linspace(-np.pi, np.pi, 200)
true_f = np.sin(x)
truncate_f = np.zeros(len(x))
n=10
plt.plot(x, true_f, label="functia exacta")
abs_tol = 1e-2
for i in range(0, 10):
    num = ((-1)**i)*x**(2*i + 1)
    den = math.factorial(2*i + 1)

    term = num/den
    truncate_f = truncate_f + term
    l2 = np.linalg.norm(true_f - truncate_f, 2)
    print(l2)

    if l2 <= 0.01:
        print(i)
        plt.plot(x, truncate_f, label=f"Ordinul {i}")


plt.grid()
plt.xlabel('x')
plt.ylabel('f(x)')
plt.legend()
plt.show()
