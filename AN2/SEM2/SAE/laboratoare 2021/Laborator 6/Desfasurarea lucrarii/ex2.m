%functia de transfer a regulatorului
num_Gr=[1 1];
den_Gr=[1 5];

%functia de transfer a procesului
num_Gp=[2];
den_Gp=[1 2 0 0];

%perioada de esantionare
Te=0.1

%functia de transfer a caii directe=pe circuit deschis in variabila s
[num_Gcd,den_Gcd]=series(num_Gp,den_Gp,num_Gr,den_Gr);

%dicretizarea functiei de transfer pe circuit deschis
[num_Gz,den_Gz]=c2dm(num_Gcd,den_Gcd,Te,'zoh');

%studiul stabilitatii folosind criteriul Nyquist
dnyquist(num_Gz,den_Gz,Te)
% rlocus(nz,dz)