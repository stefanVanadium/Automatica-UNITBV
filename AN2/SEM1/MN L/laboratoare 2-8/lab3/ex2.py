import numpy as np
import matplotlib.pyplot as plt
A_zero = np.ones((7, 7))
A_zero[1, [2, 3, 4]] = 0
A_zero[-2, [2, 3, 4]] = 0
A_zero[1:-1, [2, 4]] = 0

[n, m] = A_zero.shape
print(A_zero)



for (i, j), val in np.ndenumerate(A_zero):
    if val == 0:
        A_zero[i, j] = 1

A_zero[:, 3] = 0

plt.imshow(A_zero, 'gray')
plt.axis('off')
plt.show()
print(A_zero)

