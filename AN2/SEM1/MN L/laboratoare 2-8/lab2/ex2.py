import numpy as np
import math
import matplotlib.pyplot as plt

x  = np.linspace(-np.pi, np.pi, 200)
true_f = np.sin(x)
truncate_f = np.zeros(len(x))
n=10
plt.plot(x, true_f, label="functia exacta")
for i in range(0, 3):
    num = ((-1)**i)*x**(2*i + 1)
    den = math.factorial(2*i + 1)

    term = num/den
    truncate_f = truncate_f + term
    plt.plot(x, truncate_f, label=f"Ordinul {i}")

plt.grid()
plt.xlabel('x')
plt.ylabel('f(x)')
plt.legend()
plt.show()
