import numpy as np

outdir = "/home/stefan/Documents/ANU2/SEM2/PS/figdata/"

# --- Butterworth normalized, |G(jw)| = 1/sqrt(1+w^(2n)), wc=1 ---
w = np.linspace(0, 3, 300)
for n in [1, 2, 4, 8]:
    mag = 1.0 / np.sqrt(1 + w**(2*n))
    with open(f"{outdir}butter_n{n}.dat", "w") as f:
        f.write("w mag\n")
        for wi, mi in zip(w, mag):
            f.write(f"{wi:.5f} {mi:.6f}\n")

# --- Chebyshev normalized, n=4, ripple r=2dB ---
n = 4
r_db = 2.0
eps2 = 10**(r_db/10) - 1
eps = np.sqrt(eps2)

def Cn(n, w):
    w = np.asarray(w, dtype=float)
    out = np.empty_like(w)
    mask = np.abs(w) <= 1
    out[mask] = np.cos(n * np.arccos(w[mask]))
    out[~mask] = np.cosh(n * np.arccosh(w[~mask]))
    return out

w = np.linspace(0, 2, 400)
cn = Cn(n, w)
mag = 1.0 / np.sqrt(1 + eps2 * cn**2)
with open(f"{outdir}cheby_n4.dat", "w") as f:
    f.write("w mag\n")
    for wi, mi in zip(w, mag):
        f.write(f"{wi:.5f} {mi:.6f}\n")

# --- RLC second-order standard forms, L=C=R=1 (w0=1, R/L=1) ---
w = np.linspace(0.001, 5, 400)
s = 1j * w
H_TJ = (1) / (s**2 + s + 1)
H_TS = (s**2) / (s**2 + s + 1)
H_TB = (s) / (s**2 + s + 1)
H_OB = (s**2 + 1) / (s**2 + s + 1)

for name, H in [("rlc_tj", H_TJ), ("rlc_ts", H_TS), ("rlc_tb", H_TB), ("rlc_ob", H_OB)]:
    mag = np.abs(H)
    with open(f"{outdir}{name}.dat", "w") as f:
        f.write("w mag\n")
        for wi, mi in zip(w, mag):
            f.write(f"{wi:.5f} {mi:.6f}\n")

print("done")
