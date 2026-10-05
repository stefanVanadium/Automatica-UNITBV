import numpy as np
import matplotlib.pyplot as plt
import math as m

def f(x):
    return 4*x**4 + 2*x**3 + 4*x**2 + 2
def i(x):
    return (4/5)*m.pow(x,5) + 0.5*m.pow(x,4) + (4/3)*m.pow(x,3) + 2*x

a = 0
b = 5
h = 0.05
k = 0.02

result_25a = f(2)
print("Result of f(2):", result_25a)

N = np.int_(((b - a) / h) + 1)
w = np.ones((1,N))*2
w[0,0] = w[0, -1] = 1
x = np.linspace(a, b, N)
y = f(x)
result_25b = (h/2) * np.dot(w, y)
result_25b = result_25b[0]
print("Result of the trapezoidal rule with h=0.05:", result_25b)

N = np.int_(((b - a) / k) + 1)
w = np.ones((1,N))*2
w[0,0] = w[0, -1] = 1
x = np.linspace(a, b, N)
y = f(x)
result_25c = (k/2) * np.dot(w, y)
result_25c = result_25c[0]
print("Result of the trapezoidal rule with k=0.02:", result_25c)

result_25d = result_25b + ( (result_25b - result_25c) / ( (k/h)**2 - 1 ) )
print("Result after Richardson extrapolation:", result_25d)

I = i(b) - i(a)
print("Exact integral result:", I)