import numpy as np

matrix1 = [[1,2], [5,6]]
matrix2 = [[3,4], [7,8]]

def matrix_operation(matrix1, matrix2):
    if len(matrix1) != len(matrix2) or len(matrix1[0]) != len(matrix2[0]):
        return None

    result = np.zeros((len(matrix1), len(matrix1[0])))

    for i in range(len(matrix1)):
        for j in range(len(matrix1[0])):
            result[i][j] = matrix1[i][j] + matrix2[i][j]

    return result

result_7 = matrix_operation(matrix1, matrix2)
print(result_7)