% filtru opreste-banda
R = 1;
L = 0.1;
C = 0.001;

w = [0: 0.1: 30];
num_g = [1 0 1/(L*C)];
den_g = [1 R/L 1/(L*C)];

bode(num_g, den_g, w)