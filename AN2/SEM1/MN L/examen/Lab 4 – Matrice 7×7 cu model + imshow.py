import numpy as np
import matplotlib.pyplot as plt

A = np.ones((7, 7))
A[1, [2,3,4]] = 0
A[-2, [2,3,4]] = 0
A[1:-1, [2,4]] = 0

print(A)

# umplem zerourile cu 1
A[A == 0] = 1
A[:, 3] = 0   # coloana 3 devine neagră

plt.imshow(A, cmap='gray')
plt.axis('off')
plt.show()

print(A)