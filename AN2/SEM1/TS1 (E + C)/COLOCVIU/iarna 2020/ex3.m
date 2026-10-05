
numR=[19 20];
denR=[1 0]
Gr = tf(numR,denR);
numP=[0 0 9];
denP=[1 3 9];
Gp=tf(numP,denP);
[p z]=pzmap(Gp)
%pzmap(Gp)

%b
z=1/2
w=3
num=[w^2]; 
den=[1 2*z*w w^2];
t = [0:0.1:10];
lsim(num,den,t,t)

%c
[nums,dens] = series(numR,denR,numP,denP);
[numG0,denG0] =cloop(nums,dens);
G0 = tf(numG0,denG0);
t = [0:0.1:10];
% step(numG0,denG0,t)
%d
% errortf(numG,denG)

%e
%pzmap(G0)
% s=tf('s')
% G01= (171*s + 180)/((s^3 + 3*s^2 + 180*s + 180)*(s/0.6+1))
% step(G0)
% hold on
% step(G01)


