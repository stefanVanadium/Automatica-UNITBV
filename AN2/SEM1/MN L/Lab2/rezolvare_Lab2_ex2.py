import math
import matplotlib.pyplot as plt

x = math.pi
true_f = math.sin(x)

truncated_f = []
approx = 0

for n in range(11):
    term = ((-1) ** n) * (x ** (2 * n + 1)) / math.factorial(2 * n + 1)
    approx += term
    truncated_f.append(approx)

aprox_solution = truncated_f[-1]

print("true_f =", true_f)
print("aprox_solution =", aprox_solution)
print("Intermediate values:", truncated_f)

plt.figure()
plt.axhline(true_f, color='r', linestyle='--', label='True sin(x)')
plt.plot(range(1, 12), truncated_f, 'o-', label='Taylor partial sums')
plt.title("Taylor Approximation of sin(x) at x = pi")
plt.xlabel("Number of terms")
plt.ylabel("Approximation value")
plt.legend()
plt.show()
