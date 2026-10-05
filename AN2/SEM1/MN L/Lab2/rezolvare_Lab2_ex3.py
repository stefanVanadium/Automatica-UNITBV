import numpy as np
import matplotlib.pyplot as plt
import math

x_vals = np.linspace(-math.pi, math.pi, 146)
true_vals = np.sin(x_vals)

def sin_taylor_3(x):
    return x - (x**3)/math.factorial(3) + (x**5)/math.factorial(5)

truncated_f_ex3 = sin_taylor_3(x_vals)

plt.figure()
plt.plot(x_vals, true_vals, label='True sin(x)')
plt.plot(x_vals, truncated_f_ex3, '--', label='Taylor 3-term approx')
plt.title("sin(x) vs 3-term Taylor Approximation")
plt.legend()
plt.show()
