num_g = 9;
den_g = [1 3];
num_h = 1;
den_h = [1 0];

num1=conv(num_g,num_h);
den1=conv(den_g,den_h);

errortf(num1,den1);

s1=tf(num_g,den_g);
s2=tf(num_h,den_h);
g = feedback(s1,s2);


num_f=[0 9 0];
den_f=[1 3 9];
[p,z]=pzmap(num_f,den_f);
num_nou = [9 9 0];
den_nou = [1 3 9];

g_nou = tf(num_nou,den_nou);
step(g_nou)