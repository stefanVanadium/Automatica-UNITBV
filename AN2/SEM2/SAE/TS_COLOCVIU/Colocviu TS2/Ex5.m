%% Ex5

num_Gcd=[1];
den_Gcd=[1 1 0];
Gcd= tf(num_Gcd,den_Gcd)

num_Gcr=[1];
den_Gcr=[1 2];
Gcr= tf(num_Gcr,den_Gcr)

[num_G den_G]=series(num_Gcd,den_Gcd,num_Gcr,den_Gcr);

rlocus(num_G,den_G)

[k poli]=rlocfind(num_G,den_G);
 
