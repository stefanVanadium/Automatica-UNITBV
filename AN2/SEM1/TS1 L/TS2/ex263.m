f = [4 0 -2 0 3 -1 4]

g = [2 5 -16]

s = f + g;
d = f - g;
fprintf('The sum of f and g is: %f\n', s);
fprintf('The difference of f and g is: %f\n', d);

a = polyval(f,3) - polyval(g,7);
fprintf('The value of a is: %f\n', a);
b = [1 3 4 9]
f_b_values = polyval(f, b);
fprintf('The values of f(b) are: %f\n', f_b_values);
g_b_values = polyval(g, b);
fprintf('The values of g(b) are: %f\n', g_b_values);

p = conv(f, g);
q = deconv(f, g);
fprintf('The * of f and g is: %f\n', p);
fprintf('The / of f and g is: %f\n', q);

dp = polyder(p);
dq = polyder(f, g);
fprintf('The derivative of p is: %f\n', dp);
fprintf('The derivative of q is: %f\n', dq);

r_f = roots(f);
r_g = roots(g);
fprintf('The roots of f are: %f\n', r_f);
fprintf('The roots of g are: %f\n', r_g);