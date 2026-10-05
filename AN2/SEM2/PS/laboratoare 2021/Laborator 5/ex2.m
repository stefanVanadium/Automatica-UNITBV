% filtru trece-sus
R = 1;
L = 0.1;
C = 0.001;

w = [0: 0.1: 60];
num_g = [1 0 0];
den_g = [1 R/L 1/(L*C)];

gw = bode(num_g, den_g, w);

%plot(w, gw);
step(num_g, den_g);