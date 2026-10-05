x = -5:0.1:5;
f = (x.*abs(x))./(1+power(x,2));

plot(x, f);
xlabel('x');
ylabel('f(x)');
title('Plot of f(x) = (x * |x|) / (1 + x^2)');
grid on;