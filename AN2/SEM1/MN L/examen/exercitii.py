import numpy as np
import math as m
import matplotlib.pyplot as plt
from math import factorial

# ================= EX 1 =================

validCard = True
age = 22
result_1 = "Welcome to XYZ!" if validCard and age >= 25 else "Membership and age restrictions apply."
print("Ex1:", result_1)

# ================= EX 2 =================

validCard = True
age = 25
result_2 = "Welcome to XYZ!" if validCard and age >= 20 else "Membership and age restrictions apply."
print("Ex2:", result_2)

# ================= EX 3 =================

hasLicense = False
age = 25
result_3 = "Great! You can drive!" if hasLicense and age >= 20 else "You don't meet the criteria."
print("Ex3:", result_3)

# ================= EX 4 =================

hasLicense = True
age = 25
result_4 = "Great! You can drive!" if hasLicense and age >= 30 else "You don't meet the criteria."
print("Ex4:", result_4)

# ================= EX 5 =================

hasLicense = True
age = 25
result_5 = "Great! You can drive!" if hasLicense and age >= 18 else "You don't meet the criteria."
print("Ex5:", result_5)

# ================= EX 6 =================

matrix1 = [[1,2], [5,6]]
matrix2 = [[3,4], [7,8]]
result_6 = np.subtract(matrix1, matrix2)
print("Ex6:\n", result_6)

# ================= EX 7 =================

result_7 = np.add(matrix1, matrix2)
print("Ex7:\n", result_7)

# ================= EX 8 =================

matrix1 = [[1,3], [5,7]]
matrix2 = [[3,4], [7,8]]
result_8 = np.subtract(matrix1, matrix2)
print("Ex8:\n", result_8)

# ================= EX 9 =================

matrix1 = [[1,3,5], [5,7,9]]
matrix2 = [[3,4], [7,8]]
result_9 = 0 if np.shape(matrix1) != np.shape(matrix2) else np.subtract(matrix1, matrix2)
print("Ex9:\n", result_9)

# ================= EX 10 =================

x = np.pi
sin_real = np.sin(x)
sin_taylor = 0.0
for i in range(5):
sin_taylor += ((-1)**i) * (x**(2*i + 1)) / factorial(2*i + 1)
print("Ex10:", sin_real, sin_taylor)

# ================= EX 11 =================

x = np.pi / 2
sin_real = np.sin(x)
sin_taylor = 0.0
for i in range(15):
sin_taylor += ((-1)**i) * (x**(2*i + 1)) / factorial(2*i + 1)
print("Ex11:", sin_real, sin_taylor)

# ================= EX 12 =================

def f12(x):
return np.log(x) + 2*x

x_val = f12(10)
print("Ex12a:", x_val)

def secant(a, b, tol=1e-10):
x1, x2 = a, b
m = (f12(x2) - f12(x1)) / (x2 - x1)
x = x2 - f12(x2) / m
while abs(f12(x)) > tol:
x = x - f12(x) / m
return x

root12 = secant(0.02, 5)
print("Ex12b root:", root12)

# ================= EX 13 =================

def f13(x):
return np.log(x) - np.sin(x)

def bisection(a, b, tol=1e-14):
x = (a + b) / 2
while abs(f13(x)) > tol:
if f13(a) * f13(x) <= 0:
b = x
else:
a = x
x = (a + b) / 2
return x

root13 = bisection(1, 2*np.pi)
print("Ex13 root:", root13)

# ================= EX 14 =================

np.random.seed(42)
mat14 = np.random.randint(30, 101, (10,6))
mat14[:,-1] += 10
mat14[:2,1:3] += 15
mat14[-2:,:] += 20
mat14 = np.clip(mat14, 0, 100)

passed = np.sum(np.all(mat14 >= 50, axis=1))
perfect = np.sum(np.all(mat14 == 100, axis=1))
print("Ex14 passed:", passed, "perfect:", perfect)

# ================= EX 15 =================

mat15 = np.random.randint(0, 11, (11,5))
mat15[:,-1] -= 1
mat15[:3,1:3] -= 2
mat15[-2:,:] -= 1
mat15 = np.clip(mat15, 0, None)

passed = np.sum(np.all(mat15 < 2, axis=1))
noDose = np.sum(np.all(mat15 == 0, axis=1))
print("Ex15 passed:", passed, "noDose:", noDose)

# ================= EX 16 =================

A = np.array([[1.3,0.92,0.42,0.32],
[0.61,1.0,0.002,1.2],
[0.16,1.5,0.2,1.4],
[0.97,0.56,1.63,0.3]])
b = np.array([0.41,0.41,0.89,0.79])
x = np.linalg.solve(A,b)
err = np.sum(np.abs(A@x - b))
print("Ex16:", x, err)

# ================= EX 17 =================

A = np.array([[1.13,0.92,0.42,0.32],
[0.61,1.0,0.002,1.2],
[0.61,1.5,0.2,1.4],
[0.79,0.56,1.63,0.31]])
b = np.array([0.41,0.89,0.79,0.79])
x = np.linalg.solve(A,b)
err = np.sum(np.abs(A@x - b))
print("Ex17:", x, err)

# ================= EX 18 + 19 =================

data = np.loadtxt("data.txt", delimiter=";")
S = np.cov(data.T)
L, V = np.linalg.eig(S)
Vp = V[:,:2]
Xpca = data @ Vp
X0 = Xpca @ Vp.T
err = np.sum(np.abs(data - X0)) / np.sum(np.abs(data)) * 100
print("Ex18-19 error:", err)

# ================= EX 20 =================

x20 = np.array([0,2,4,8,10,12,14,16])
y20 = np.array([0,2,3,7,8,15,16,17])
coef20 = np.polyfit(x20[:5], y20[:5], 4)
print("Ex20 coef:", coef20)

# ================= EX 21 =================

x21 = np.array([0,2,8,10,12,16])
y21 = np.array([0,2,7,8,15,17])
coef21 = np.polyfit(x21[-4:], y21[-4:], 3)
print("Ex21 coef:", coef21)

# ================= EX 22 =================

def f22(x): return 4*x**3 + 2*x**2 + 4*x + 2
def d22(x): return 12*x**2 + 4*x + 4
x = np.linspace(-10,10,200)
num = np.diff(f22(x)) / np.diff(x)
print("Ex22 num:", num[:3], "analitic:", d22(x)[:3])

# ================= EX 23 =================

def f23(x): return 4*x**4 + 2*x**3 + 4*x**2 + 2
def d23(x): return 16*x**3 + 6*x**2 + 8*x
x = np.linspace(-5,5,100)
num = np.diff(f23(x)) / np.diff(x)
print("Ex23 num:", num[:3], "analitic:", d23(x)[:3])

# ================= EX 24 =================

def f24(x): return 4*x**3 + 2*x**2 + 4*x + 2
def i24(x): return x**4 + (2/3)*x**3 + 2*x**2 + 2*x

a,b = 0,10
h,k = 0.06,0.03

def trapz(f,a,b,h):
x = np.arange(a,b+h,h)
y = f(x)
return (h/2)*(y[0] + 2*np.sum(y[1:-1]) + y[-1])

T1 = trapz(f24,a,b,h)
T2 = trapz(f24,a,b,k)
R = T1 + (T1 - T2)/((k/h)**2 - 1)
print("Ex24:", T1, T2, R, i24(b)-i24(a))

# ================= EX 25 =================

def f25(x): return 4*x**4 + 2*x**3 + 4*x**2 + 2
def i25(x): return (4/5)*x**5 + 0.5*x**4 + (4/3)*x**3 + 2*x

a,b = 0,5
h,k = 0.05,0.02
T1 = trapz(f25,a,b,h)
T2 = trapz(f25,a,b,k)
R = T1 + (T1 - T2)/((k/h)**2 - 1)
print("Ex25:", T1, T2, R, i25(b)-i25(a))

# ================= EX 26 =================

m1 = np.array([[1,3,5],[5,7,9]])
m2 = np.array([[3,4,4],[7,8,8]])
result_26 = m1 - m2
print("Ex26:\n", result_26)