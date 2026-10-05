% filtru trece-banda
R = 1;
L = 0.1;
C = 0.001;

w = [0: 0.1: 30];
num_g = [R/L 0];
den_g = [1 R/L 1/(L*C)];

%gw = bode(num_g, den_g, w);

% plot(w, gw);
%step(num_g, den_g);
bode(num_g, den_g, w)