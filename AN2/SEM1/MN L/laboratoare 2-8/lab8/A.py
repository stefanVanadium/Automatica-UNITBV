#lab 8 pct A
import numpy as np
import matplotlib.pyplot as plt

x_exp = [0, 1, 2, 3, 4, 5];
y_exp = [3, 4, 7, 24, 59, 118];

print(x_exp)
print(y_exp)
print(type(x_exp))

x_many_aprox = np.linspace(0, 5, 100)
y_many_aprox = np.interp(x_many_aprox, x_exp, y_exp)

#plt.plot(x_many_aprox, y_many_aprox, 'r')
#plt.show()

px = x_exp[0:4]
py = y_exp[0:4]

print(px)
print(py)

V = [np.pow(px, 3), np.pow(px, 2), np.pow(px, 1), np.pow(px, 0)]
Vt = np.transpose(V)

coefs = np.matmul(np.linalg.inv(Vt), py)
print(coefs)

xm = np.linspace(x_exp[0], x_exp[3], 100)
#rezolvăm polinomul în fiecare punct de mai sus
ym = np.polyval(coefs, xm)

plt.plot(xm, ym, 'r')
plt.show()