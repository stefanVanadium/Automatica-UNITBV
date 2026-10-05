num=[1 5];
den=[1 3.6 0 0];

[nz,dz]=c2dm(num,den,0.1,'zoh');

rlocus(nz,dz)

zgrid
%% 
num=[1 6 8];
den=[1 3.6 0 0];

[nz,dz]=c2dm(num,den,0.1,'zoh');
rlocus(nz,dz)
zgrid
%% 
num=[1];
den=[1 8 19 12];

[nz,dz]=c2dm(num,den,0.1,'zoh');
rlocus(nz,dz)
zgrid
%% 
num=[1];
den=[1 7 16 10];

[nz,dz]=c2dm(num,den,0.1,'zoh');
rlocus(nz,dz)
zgrid
%%
num=[9];
den=[1 6 0];

[nz,dz]=c2dm(num,den,0.1,'zoh');
rlocus(nz,dz)
zgrid;