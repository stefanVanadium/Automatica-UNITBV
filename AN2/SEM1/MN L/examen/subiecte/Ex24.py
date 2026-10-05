import numpy as np
import matplotlib.pyplot as plt
import math as m

def f(x):
    return 4*x**3 + 2*x**2 + 4*x + 2
def i(x):
    return x**4 + (2/3)*x**3 + 2*x**2 + 2*x

a = 0
b = 10
h = 0.06
k = 0.03

result_24a = f(1)
print("Result of f(1):", result_24a)

N = np.int_(((b - a) / h) + 1)
w = np.ones((1,N))*2
w[0,0] = w[0, -1] = 1
x = np.linspace(a, b, N)
y = f(x)
result_24b = (h/2) * np.dot(w, y)
result_24b = result_24b[0]
print("Result of the trapezoidal rule with h=0.06:", result_24b)

N = np.int_(((b - a) / k) + 1)
w = np.ones((1,N))*2
w[0,0] = w[0, -1] = 1
x = np.linspace(a, b, N)
y = f(x)
result_24c = (k/2) * np.dot(w, y)
result_24c = result_24c[0]
print("Result of the trapezoidal rule with k=0.03:", result_24c)

result_24d = result_24b + ( (result_24b - result_24c) / ( (k/h)**2 - 1 ) )
print("Result after Richardson extrapolation:", result_24d)

I = i(b) - i(a)
print("Exact integral result:", I)