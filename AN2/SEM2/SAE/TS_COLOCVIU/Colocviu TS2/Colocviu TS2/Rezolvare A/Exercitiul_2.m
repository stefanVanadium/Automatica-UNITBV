num = [1 3 12];
den = [1 3 6];
Go = tf(num,den);

[A, B, C, D] = tf2ss(num, den)

O = obsv(A,C);

if (det(O) ~= 0)
   disp("Sistemul este observabil")
end