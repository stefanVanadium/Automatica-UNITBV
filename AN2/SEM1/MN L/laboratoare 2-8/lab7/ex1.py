#ex 1 lab 7
import numpy as np
import matplotlib.pyplot as plt

def f(x):
    return 2*x**3 + 7*x**2 + x + 1

def d(x):
    return 6*x**2 + 14*x + 1

print(f(5), d(5))

N = 100
a = -10
b = 10

x = np.linspace(a, b, N)
y = f(x)

dydx = np.diff(y)/np.diff(x)
print(y[:5], dydx[:5])

f_der = d(x)

print(f_der[:5])


plt.plot(x, f_der)
plt.plot(x[:-1]+((b-a)/(N-1))/2, dydx)
plt.legend(['Exact', 'Numeric'])
plt.show()