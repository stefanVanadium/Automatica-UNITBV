import numpy as np

def create_matrix(studenti, materii):
    return np.random.randint(0, 11, size=(studenti, materii))

note = create_matrix(12, 6)
print("Note inițiale:\n", note)

note[:, 0] += 1
note[:5, [2,3]] += 2
note[:-1, :] += 1

print("\nNote modificate:\n", note)

for i, rand in enumerate(note):
    if np.all(rand >= 5):
        print(f"Student {i+1:2d} → trecut")
    else:
        print(f"Student {i+1:2d} → repetent")