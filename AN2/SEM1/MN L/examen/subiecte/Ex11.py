from math import factorial
import numpy as np

def func(x):
    return np.sin(x)

x = np.pi / 2
result_11a = func(x)
print(result_11a)

truncated_func = 0.0
truncated_values = []

for i in range(0, 15):
    term = ((-1)**i) * (x**(2*i + 1)) / factorial(2*i + 1)
    truncated_func += term
    truncated_values.append(truncated_func)

result_11b = truncated_func
print(result_11b)