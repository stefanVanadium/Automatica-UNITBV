import numpy as np
import math as m

A = [[1.3, 0.92, 0.42, 0.32], [0.61, 1.0, 0.002, 1.2], [0.16, 1.5, 0.2, 1.4], [0.97, 0.56, 1.63, 0.3]]
b = [0.41, 0.41, 0.89, 0.79]

result_16aA = np.shape(A)
result_16ab = np.shape(b)
print("16a) Shape of A:", result_16aA)
print("16a) Shape of b:", result_16ab)

result_16b = np.linalg.solve(A, b)
print("16b) Solution x of Ax = b:", result_16b)

def error(A, x, b):
    Ax = np.dot(A, x)
    return np.sum(np.abs(Ax - b))

result_16c = error(A, result_16b, b)
print("16c) Error ||Ax - b||_1:", result_16c)