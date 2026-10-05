#C

import numpy as np
import matplotlib.pyplot as plt
import math
data = np.genfromtxt("data_regresie.csv")
x = data[:,0]
y = data[:,1]

#1
V1 = np.column_stack([x, x**0])
#ecuatia 4
c1 = np.linalg.inv(V1.T@V1)@V1.T@y.T
e1 = np.linalg.norm(y - (c1[0]*x + c1[1]),2)
print(e1)

#2
V2 = np.column_stack([x**2, x, x**0])
#ecuatia 4
c2 = np.linalg.inv(V2.T@V2)@V2.T@y.T
e2 = np.linalg.norm(y - (c2[0]*x**2 + c2[1]*x + c2[2]),2)
print(e2)

#3
V3 = np.column_stack([x**3, x**2, x, x**0])
#ecuatia 4
c3 = np.linalg.inv(V3.T@V3)@V3.T@y.T
e3 = np.linalg.norm(y - (c3[0]*x**3 + c3[1]*x**2 + c3[2]*x + c3[3]),2)
print(e3)

#4
V4 = np.column_stack([x**3, np.log(x), x**0])
#ecuatia 4
c4 = np.linalg.inv(V4.T@V4)@V4.T@y.T
e4 = np.linalg.norm(y - (c4[0]*x**3 + c4[1]*np.log(x) + c3[2]),2)
print(e4)


#5
V5 = np.column_stack([1/x**2, np.exp(x)])
#ecuatia 4
c5 = np.linalg.inv(V5.T@V5)@V5.T@y.T
e5 = np.linalg.norm(y - (c5[0]*1/x**2 + c5[1] * np.exp(x)),2)
print(e5)

