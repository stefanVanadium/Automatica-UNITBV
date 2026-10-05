#lab 8 ex 2 sau B
import numpy as np
import matplotlib.pyplot as plt
import scipy

points = ((0, 1, 2),
          (0, 1, 2))
values = [[3, 4, 5], [5,7, 9], [9, 12, 15]]

#plt.imshow(values)
#plt.axis('off')
#plt.show()

f_interp = scipy.interpolate.RegularGridInterpolator(points, values, method='linear')

xp = np.linspace(0, 2, 250)
yp = np.linspace(0, 2, 250)
X, Y = np.meshgrid(xp, yp, indexing='ij') #Se construiește un grid din cele două liste

fp = f_interp((X, Y))
plt.imshow(fp)
plt.axis('off')
plt.show()