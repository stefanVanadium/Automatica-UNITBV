import numpy as np
import math
import matplotlib.pyplot as plt

x = 2 * np.pi
true_f = np.sin(x)
truncate_f = 0.0
truncate_vals = []
n = 10
for i in range(0, n):
    num = ((-1)**i)*x**(2*i + 1)
    den = math.factorial(2*i + 1)

    term = num/den
    truncate_f = truncate_f + term
    print(truncate_f, true_f, term)
    truncate_vals.append(truncate_f)


plt.semilogx([true_f] * n, label = "Valaore exacta")
plt.semilogx(truncate_vals, label = 'Valoarea aproximata')
plt.xlabel('Nr de termeni din serie')
plt.legend()
plt.show()


