import numpy as np
import matplotlib.pyplot as plt

np.random.seed(42)

def generate_matrix(ele, disc):
    mat = np.random.randint(30, 101, size=(ele, disc))
    return mat

result_14ag = generate_matrix(10, 6)
print("Result of Ex14a:")
print(result_14ag)
result_14a = np.shape(result_14ag)
print("Shape of the matrix:", result_14a)

result_14ag[:,-1] += 10
result_14ag[:2,1:3] += 15
result_14ag[-2:,:] += 20

result_14b50 = 0
result_14b100 = 0
for i in range(result_14ag.shape[0]):
    passed = True
    isMaxed = True
    for j in range(result_14ag.shape[1]):
        if result_14ag[i,j] > 100:
            result_14ag[i,j] = 100
        
        if result_14ag[i,j] < 50:
            passed = False
        if result_14ag[i,j] < 100:
            isMaxed = False
    
    if passed:
        result_14b50 += 1
    if isMaxed:
        result_14b100 += 1

print("\nResult of Ex14b (after modifications):")
print(result_14ag)
print("Number of students passing all subjects (>=50):", result_14b50)
print("Number of students with perfect scores (100):", result_14b100)