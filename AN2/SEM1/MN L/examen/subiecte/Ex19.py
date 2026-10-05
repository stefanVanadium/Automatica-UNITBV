import numpy as np
import matplotlib.pyplot as plt
import math as m

with open('data.txt', 'r') as file:
    data = file.readlines()

data_matrix = []
for row in data:
    row = row.strip().split(';')
    row = [float(i) for i in row]
    data_matrix.append(row)

data_matrix = np.array(data_matrix)

result_18X = data_matrix[:, :len(data_matrix[0]) - 1]
result_18y = data_matrix[:, -1]

result_18S = np.cov(data_matrix.T)
print("18a) Shape of X:", np.shape(result_18X))
print("18a) Shape of y:", np.shape(result_18y))
print("18a) Shape of S:", np.shape(result_18S))

L, V = np.linalg.eig(result_18S)
print(L)
result_18Vp = V[:, :2]

result_18Xpca = np.matmul(data_matrix, result_18Vp)
print("18b) Shape of Xpca:", np.shape(result_18Xpca))

result_18X0 = np.matmul(result_18Xpca, result_18Vp.T)
print("18c) Shape of X0:", np.shape(result_18X0))

result_18e = np.sum(abs(data_matrix - result_18X0))/np.sum(abs(data_matrix)) * 100
print("18d) Percentage error:", result_18e)