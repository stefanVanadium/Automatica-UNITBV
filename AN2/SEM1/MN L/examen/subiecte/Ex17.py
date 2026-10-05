import numpy as np
import math as m

A = [[1.13, 0.92, 0.42, 0.32], [0.61, 1.0, 0.002, 1.2], [0.61, 1.5, 0.2, 1.4], [0.79, 0.56, 1.63, 0.31]]
b = [0.41, 0.89, 0.79, 0.79]

result_17aA = np.shape(A)
result_17ab = np.shape(b)
print("17a) Shape of A:", result_17aA)
print("17a) Shape of b:", result_17ab)

result_17b = np.linalg.solve(A, b)
print("17b) Solution x of Ax = b:", result_17b)

def error(A, x, b):
    Ax = np.dot(A, x)
    return np.sum(np.abs(Ax - b))

result_17c = error(A, result_17b, b)
print("17c) Error ||Ax - b||_1:", result_17c)