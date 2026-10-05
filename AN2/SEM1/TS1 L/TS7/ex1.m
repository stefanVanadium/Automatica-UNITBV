
num = 120 * [1 1];
den = conv([1 3], [1 4]);

errortf(num, den);

%[z, p, k] = tf2zp(num, den);
%errortf(z, p, k);