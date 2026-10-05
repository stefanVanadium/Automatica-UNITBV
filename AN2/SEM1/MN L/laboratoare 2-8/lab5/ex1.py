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

# 2a. Implementare functie de forward_substitution,
# care determina solutiile prin inlocuire incepand cu primul element.
def LU_decomp(A):
    n = A.shape[0]
    L = np.eye(n)
    U = A
    I = np.eye(n)

    # Se parcurge fiecare element de sub diagonala principală
    for col in range(n):
        for row in range(col + 1, n):
            # Se calculează matricea elementară pentru reducerea
            # elementului curent de sub diagonala principală
            E_tmp = np.eye(n)
            factor = U[row, col] / U[col, col]
            E_tmp[row, :] = E_tmp[row, :] - E_tmp[col, :] * factor

            # Se calculează matricele L și U
            U = np.matmul(E_tmp, U)
            L = np.matmul(L, (-E_tmp + 2 * I))
    return L, U

def forward_substitution(A, b):
    n = A.shape[0]
    x = np.zeros((n))

    # soluția x_0
    x[0] = b[0] / A[0, 0]

    # soluțiile rămase
    for i in range(1, n):
        x[i] = (b[i] - np.dot(A[i, :i], x[:i])) / A[i, i]

    return x


def back_substitution(A, b):
    n = np.shape(A)[1]
    x = np.zeros((n))

    # ultimul element al vectorului solutie
    x[n - 1] = b[n - 1] / A[n - 1, n - 1]

    # solutiile ramase in ordine inversa
    for i in range(n - 2, -1, -1):
        x[i] = (b[i] - np.dot(A[i, (i + 1):], x[(i + 1):])) / A[i, i]

    return x


# 2b. Implementare SolveLU
def solve_LU(A, b):
    L, U = LU_decomp(A)
    d = forward_substitution(L, b)
    x = back_substitution(U, d)

    return x


x = solve_LU(A, b)
print(x[:5])

def eroare_ex3(A, b, x):
    [n, m] = A.shape
    e = 0.0
    for i in range(n):
        for j in range(m):
            e+= abs(A[i, j]*x[i] - b[i])

    return e


def eroare(A, b, x):
    e = np.sum(np.abs(np.matmul(A, x) - b))

    return e

e = np.linalg.norm(A@x - b, 1)
e1 = eroare(A, b, x)
print(e)
print(e1)

def inv_LU(A):
    n = np.shape(A)[1]
    A_inv = np.zeros((n, n))
    I = np.eye(n)

    L, U = LU_decomp(A)

    for i in range(n):
        d = forward_substitution(L, I[:, i])
        A_inv[:, i] = back_substitution(U, d)

    return A_inv


A_inv = inv_LU(A)

I = np.eye(np.shape(A)[1])
e = np.linalg.norm(A_inv@A - I, 1)
print(e)


