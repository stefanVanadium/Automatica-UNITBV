import numpy as np
import matplotlib.pyplot as plt

np.random.seed(42)

def generate_matrix(a, b):
    mat = np.random.randint(0, 11, size=(a, b))
    return mat

result_15ag = generate_matrix(11, 5)
print("Result of Ex15a:")
print(result_15ag)
result_15a = np.shape(result_15ag)
print("Shape of the matrix:", result_15a)

result_15ag[:,-1] -= 1
result_15ag[:3,1:3] -= 2
result_15ag[-2:,:] -= 1

result_15b50 = 0
result_15b100 = 0
for i in range(result_15ag.shape[0]):
    passed = True
    noDose = True
    for j in range(result_15ag.shape[1]):
        if result_15ag[i,j] < 0:
            result_15ag[i,j] = 0
        
        if result_15ag[i,j] >= 2:
            passed = False
        if result_15ag[i,j] > 0:
            noDose = False
    
    if passed:
        result_15b50 += 1
    if noDose:
        result_15b100 += 1

print("\nResult of Ex15b (after modifications):")
print(result_15ag)
print("Number of patients with all scores >= 2:", result_15b50)
print("Number of patients with no doses:", result_15b100)