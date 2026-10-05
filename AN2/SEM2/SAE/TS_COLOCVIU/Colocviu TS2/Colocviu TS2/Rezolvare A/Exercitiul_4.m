a = 7;
num = [0 0 9];
den = [1 a 0];
G = tf(num,den);
nyquist(num,den)

%sistemul este instabil deoarece conturul nyquist cuprinde punctul (-1,
%j*0)