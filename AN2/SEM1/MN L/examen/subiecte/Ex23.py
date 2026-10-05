import numpy as np
import matplotlib.pyplot as plt
import math as m

def f(x):
    return 4*x**4 + 2*x**3 + 4*x**2 + 2
def d(x):
    return 16*x**3 + 6*x**2 + 8*x

a = -5
b = 5
N = 100

result_23a = f(1)
print("Result of f(1):", result_23a)

x = np.linspace(a, b, N)
y = f(x)

dydx = np.diff(y)/np.diff(x)
dydx[:3]
result_23b = dydx[:3]

f_der = d(x)
f_der[:3]

print("First three values of numerical derivative:", result_23b)
print("First three values of analytical derivative:", f_der[:3])

