%%EX1

num = [1 3 12]
den = [1 3 6]

[A, B, C, D] = tf2ss(num, den)

impulse(A, B, C, D)

obsv(A, C) %Este observabil

%%
%%Ex3
a = 3; %sistemul este stabil
num1 = 9;
den1 = [1 a 0];

rlocus(num1, den1)
nyquist(num1, den1) %la limita de stabilitate

%%
%%Ex4
numa = [1];
dena = [1 1];
Ga = tf(numa, dena);

numb = [1];
denb = [1 2];
Gb = tf(numb, denb)

[num0, den0] = series(numa, dena, numb, denb);
rlocus(num0, den0)
[k, poli] = rlocfind(num0, den0)

[numg, deng] = feedback(numa, dena, numb, denb)
%%pentru k <0  sistemul este instabil.

%%
%%Exercitiul 5

n1 = 0.5;
d1 = 1;

n2 = 4;
d2 = [1 4];

n3 = 1;
d3 = [1 2];
 
n4 = 3;
d4 = [1 3];

nblocks = 4;
blkbuild;

q = [1 -5 -6 -7; 
    2 1 0 0; 
    3 2 0 0; 
    4 3 0 0]
[A, B, C, D] = connect(a, b, c, d, q, 1, 2); 
[num, den] = ss2tf(A, B, C, D, 1);
G = tf(num, den);

