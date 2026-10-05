import numpy as np

data_path = r"A.txt"
with open(data_path, 'r') as f:
    data = f.readlines()

A = []
for row in data:
    row = row.split(" ")[1:]
    row = [float(el) for el in row]
    A.append(row)
A = np.array(A)
print(A.shape)

data_path = r"b.txt"
with open(data_path, 'r') as f:
    data = f.readlines()
b = [float(el) for el in data]
b = np.array(b)
print(b.shape)

A0 = A
b0 = b
def gauss_elim(A, b):
    '''
    Intrări
        A - matricea coeficineților, de dimensiune n x n
        b - matricea coloană a termenilor liberi, de dimensiune n x 1
    Ieșiri
        A2 - noua matrice A, adusă la forma triunighiulară, n x n
        b2 - noul vector b, n x 1
    '''
    n = np.shape(A)[1]
    A2 = A
    b2 = b

    # se parcurg toate elementele de sub diagonala principală
    for col in range(n):
        for row in range(col + 1, n):
            # Se calculează matricea E pentru fiecare element
            # de sub diagonala principală
            E = np.eye(n)
            factor = A2[row, col] / A2[col, col]
            E[row, :] = E[row, :] - E[col, :] * factor

            # Se multiplică la stanga ambii membri ai sistemului
            # cu matricea E calculată mai sus
            A2 = np.matmul(E, A2)
            b2 = np.matmul(E, b2)

    return A2, b2

def back_subst(A, b):
    n = np.shape(A)[1]
    x = np.zeros((n))

    # ultimul element al vectorului soluție
    x[n - 1] = b[n - 1] / A[n - 1, n - 1]

    # soluțiile rămase se determină în ordine inversă
    for i in range(n - 2, -1, -1):
        x[i] = (b[i] - np.dot(A[i, (i + 1):], x[(i + 1):])) / A[i, i]

    return x


A2, b2 = gauss_elim(A0, b0)
print(A2.shape)
print(b2.shape)

x2 = back_subst(A2, b2)
print(x2[:5])
print(x2.shape)

x_vechi = np.matmul(np.linalg.inv(A0), b0)
x_numpy = np.matmul(np.linalg.inv(A), b)

#print(x_vechi[:5])
print(x_numpy[:5])


def eroare(A, b, x):
    e = np.sum(np.abs(np.matmul(A, x) - b))

    return e

e1 = eroare(A, b, x2)
print(e1)
e2 = eroare(A, b, x_numpy)
print(e2)

x_inv = np.matmul(np.linalg.inv(A), b)
print(x_inv[:5])
