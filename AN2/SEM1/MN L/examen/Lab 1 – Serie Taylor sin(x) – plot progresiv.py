import numpy as np
import math
import matplotlib.pyplot as plt

x = np.linspace(-np.pi, np.pi, 200)
true_f = np.sin(x)
approx = np.zeros_like(x)

plt.plot(x, true_f, label="sin(x) exact")

for i in range(3):
    term = ((-1)**i * x**(2*i + 1)) / math.factorial(2*i + 1)
    approx += term
    plt.plot(x, approx, label=f"ordin {i+1}")

plt.grid(True)
plt.xlabel('x')
plt.ylabel('f(x)')
plt.legend()
plt.show()