%%Ex2
num_Gs=[1 3 12];
den_Gs=[1 3 6];
Gs=tf(num_Gs,den_Gs)

[A,B,C,D]=tf2ss(num_Gs,den_Gs)
obsv(A,C)

