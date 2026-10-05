%functia de transfer a regulatorului
num=[1 20];
den=[1 1];

%discretizarea regulatorului
[nz,dz]=c2dm(num,den,0.1,'zoh');
