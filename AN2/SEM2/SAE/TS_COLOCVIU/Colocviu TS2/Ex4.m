%% Ex4
num_Gcd=[9];
den_Gcd=[1 7 0];

[A,B,C,D]=tf2ss(num_Gcd,den_Gcd)

nyquist(num_Gcd,den_Gcd)

%sistem stabil