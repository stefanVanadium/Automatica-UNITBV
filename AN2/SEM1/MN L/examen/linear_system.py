import numpy as np

# a) Initialize variables A and b, determine dimensions
A = [[1.3, 0.92, 0.42, 0.32], 
     [0.61, 1.0, 0.002, 1.2], 
     [0.16, 1.5, 0.2, 1.4], 
     [0.97, 0.56, 1.63, 0.3]]

b = [0.41, 0.41, 0.89, 0.79]

# Convert to numpy arrays for calculations
A_np = np.array(A)
b_np = np.array(b)

# Determine dimensions
result_16aA = A_np.shape
result_16ab = b_np.shape

print(f"a) Dimensiunea matricei A: {result_16aA}")
print(f"   Dimensiunea vectorului b: {result_16ab}")
print()

# b) Solve the system Ax = b
result_16b = np.linalg.solve(A_np, b_np)
print(f"b) Soluția sistemului: {result_16b}")
print()

# c) Define function to calculate error e = sum(|Ax - b|)
def calculate_error(A, x, b):
    """
    Calculate the error as the sum of absolute values of (Ax - b)
    e = sum(|Ax - b|)
    
    Parameters:
    A: coefficient matrix
    x: solution vector
    b: right-hand side vector
    
    Returns:
    The error value
    """
    Ax = np.dot(A, x)
    error = np.sum(np.abs(Ax - b))
    return error

# Calculate error for the solution
result_16c = calculate_error(A_np, result_16b, b_np)
print(f"c) Eroarea pentru soluția determinată: {result_16c}")
print()

# Verification
print("Verificare:")
print(f"Ax = {np.dot(A_np, result_16b)}")
print(f"b  = {b_np}")
print(f"Ax - b = {np.dot(A_np, result_16b) - b_np}")
