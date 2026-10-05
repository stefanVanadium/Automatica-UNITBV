 num = [1 1];
 den = [1 10];

 % k = 10 la puterea -1

 %%
 t=[0:0.1:10];
 r = 3 * sin(2*t);
 bode(num, den, r)