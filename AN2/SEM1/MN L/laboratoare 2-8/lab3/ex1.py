import numpy as np

def create_matrix(num_students, num_mat):
    return np.random.randint(0, 11, size = [num_students, num_mat])

a = create_matrix(12, 6)
[n, m] = a.shape

print(a)

a[:, 0]+=1
a[:5, [2, 3]]+=2
a[:-1, :]+=1
print(a)

for i, j in enumerate(a):
    conditions = np.all(j >=5 )
    if conditions:
        print(f"Studntul {i} a trecut")
    else:
        print(f"Studntul {i} este repetent")