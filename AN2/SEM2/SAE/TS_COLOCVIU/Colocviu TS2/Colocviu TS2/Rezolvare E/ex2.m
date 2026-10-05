%% a
num = [1 1];
den = [1 10];
G = tf(num,den)

%T1 = 1; T2 = 1/10
%% b
t=[0:0.1:10];
u = 3.*sin(2.*t)
bode(num,den,u)