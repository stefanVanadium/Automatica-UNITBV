import numpy as np
import matplotlib.pyplot as plt
import math as m

result_20x = np.array([0, 2, 4, 8, 10, 12, 14 , 16])
result_20y = np.array([0, 2, 3, 7, 8, 15, 16, 17])

print("20x:", result_20x)
print("20y:", result_20y)  

result_20b = np.polyfit(result_20x[:5], result_20y[:5], 4)
print("20b:", result_20b)

plt.scatter(result_20x, result_20y, color='blue', label='Data Points')
x_fit = np.linspace(min(result_20x), max(result_20x), 100)
y_fit = np.polyval(result_20b, x_fit)
plt.plot(x_fit, y_fit, color='red', label='Cubic Fit')

plt.show()