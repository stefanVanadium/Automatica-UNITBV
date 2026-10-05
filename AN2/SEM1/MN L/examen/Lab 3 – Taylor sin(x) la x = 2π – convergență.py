import numpy as np
import matplotlib.pyplot as plt

x = 2 * np.pi
true = np.sin(x)
approx = 0.0
vals = []

for i in range(15):
    term = ((-1)**i * x**(2*i + 1)) / math.factorial(2*i + 1)
    approx += term
    vals.append(approx)
    print(f"{i+1:2d}  {approx:18.10f}   (diff = {abs(approx - true):.2e})")

plt.semilogy(range(1, len(vals)+1), [abs(v - true) for v in vals], '.-')
plt.xlabel("număr termeni")
plt.ylabel("eroare absolută")
plt.grid(True)
plt.show()