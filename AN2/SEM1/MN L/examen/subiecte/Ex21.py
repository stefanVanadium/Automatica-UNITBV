import numpy as np
import matplotlib.pyplot as plt
import math as m

result_21x = np.array([0, 2, 8, 10, 12, 16])
result_21y = np.array([0, 2, 7, 8, 15, 17])

print("21x:", result_21x)
print("21y:", result_21y)  

result_21b = np.polyfit(result_21x[-4:], result_21y[-4:], 3)
print("21b:", result_21b)

plt.scatter(result_21x, result_21y, color='blue', label='Data Points')
x_fit = np.linspace(min(result_21x), max(result_21x), 100)
y_fit = np.polyval(result_21b, x_fit)
plt.plot(x_fit, y_fit, color='red', label='Cubic Fit')

plt.show()