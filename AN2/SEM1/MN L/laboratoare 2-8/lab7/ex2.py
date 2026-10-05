#lab 7 ex 2
import numpy as np
import matplotlib.pyplot as plt

def f(x):
    return np.sin(x) + 1

def i(x):
    return x - np.cos(x)

print(f(0), i(0))

I_exact = i(2*np.pi) - i(0)
print(I_exact)

h = 0.08
k = 0.04
a = 0
b = 2*np.pi

Nh = (b - a + h)/h
Nh = int(Nh)
print(Nh)

wh = np.ones((1,Nh))*2
wh[0, 0]=wh[0, -1]=1

xh = np.linspace(a, b, Nh)
yh = f(xh)

Ih = h/2*np.dot(wh, yh)[0]
print(Ih)

Nk = (b - a + k)/k
Nk = int(Nk)
print(Nk)

wk = np.ones((1,Nk))*2
wk[0, 0]=wk[0, -1]=1

xk = np.linspace(a, b, Nk)
yk = f(xk)

Ik = k/2*np.dot(wk, yk)[0]
print(Ik)

I_numeric = Ih + (Ih - Ik)/(k**2/(h**2)-1)
print(I_numeric)

e_h = abs(Ih - I_exact)
e_k = abs(Ik - I_exact)
e_numeric = abs(I_numeric - I_exact)
print(e_h)
print(e_k)
print(e_numeric)