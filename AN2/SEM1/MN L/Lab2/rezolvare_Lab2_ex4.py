import numpy as np
import math

x_vals = np.linspace(-math.pi, math.pi, 500)
true_vals = np.sin(x_vals)

def sin_taylor(x, n_terms):
    result = 0
    for n in range(n_terms):
        result += ((-1)**n) * (x**(2*n + 1)) / math.factorial(2*n + 1)
    return result

def l2_norm(a, b):
    return np.sqrt(np.mean((a - b)**2))

tolerance = 0.03
best_order = None
best_error = None

for n_terms in range(1, 50):
    approx_vals = sin_taylor(x_vals, n_terms)
    error = l2_norm(true_vals, approx_vals)
    if error < tolerance:
        best_order = n_terms
        best_error = error
        break

print("best_order =", best_order)
print("best_error =", best_error)
