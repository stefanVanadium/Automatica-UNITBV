def matrix_subtraction(matrix1, matrix2):
    """
    Calculates the difference between two matrices.
    
    Parameters:
    matrix1: First matrix (list of lists)
    matrix2: Second matrix (list of lists)
    
    Returns:
    The difference matrix if dimensions match, None otherwise
    """
    # Check if matrices have the same dimensions
    if len(matrix1) != len(matrix2):
        return None
    
    if len(matrix1) > 0 and len(matrix1[0]) != len(matrix2[0]):
        return None
    
    # Calculate the difference
    result = []
    for i in range(len(matrix1)):
        row = []
        for j in range(len(matrix1[i])):
            row.append(matrix1[i][j] - matrix2[i][j])
        result.append(row)
    
    return result


# Test with the given matrices
matrix1 = [[1, 2], [5, 6]]
matrix2 = [[3, 4], [7, 8]]
result_6 = matrix_subtraction(matrix1, matrix2)

print(f"matrix1: {matrix1}")
print(f"matrix2: {matrix2}")
print(f"result_6: {result_6}")
