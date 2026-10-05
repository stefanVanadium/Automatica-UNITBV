import numpy as np
import matplotlib.pyplot as plt
import math as m

def f(x):
    return 4*x**3 + 2*x**2 + 4*x**1 + 2
def d(x):
    return 12*x**2 + 4*x + 4

a = -10
b = 10
N = 200

result_22a = f(10)
print("Result of f(10):", result_22a)

x = np.linspace(a, b, N)
y = f(x)

dydx = np.diff(y)/np.diff(x)
dydx[:4]
result_22b = dydx[:4]

f_der = d(x)
f_der[:4]

print("First three values of numerical derivative:", result_22b)
print("First three values of analytical derivative:", f_der[:4])
