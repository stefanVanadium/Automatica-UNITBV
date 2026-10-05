import math

x = math.pi
print("Ex2: a) Aproximarea pentru x =", x)
n_termene = 15

aprox = 0
for n in range(n_termene):
    termen = (-1)**n * x**(2*n + 1) / math.factorial(2*n + 1)
    aprox += termen

print("Ex2: b) Valoarea aproximativa este: ", aprox)