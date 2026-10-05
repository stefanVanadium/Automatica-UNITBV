% Proces R*C

R=10000;
C=10^(-4);

%functia de transfer
den_Gp=[R*C];
num_Gp=[1 (R*C)];
Gp=tf(den_Gp,num_Gp);

%stabilitatea
roots(num_Gp); % o singura radacina "-1" - sistem stabil



