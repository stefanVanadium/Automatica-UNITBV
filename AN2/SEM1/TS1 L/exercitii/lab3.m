%% 1
t = 0:0.001:0.02;
f = sin(2*pi*50*t);
g = f + 0.2;
plot(f, 'g:')      % green dotted line for f (x = 1:numel(f))
hold on
plot(g, 'r*')      % red star markers for g (x = 1:numel(g))
hold off

%% 2
x = 0:0.1:10;
y = 10.^x;
semilogy(x, y);

%% 3
t = 0:0.01:2*pi;
f = sin(2.*t) .* cos(2.*t);
polar(t,f);

%% 4 
n = 0:20;
f = sin(2*pi*n/10);
stem(n, f);

%% 5
x = 0:0.2:6;
y = sin(x);
stairs(x, y);

%% 6
x = -5:0.1:5;
f = x .* abs(x) ./ (1 + x.^2);
plot(f);

%% 7
t = -2:0.01:2;
x = cos(2*pi*t);
y = sin(2*pi*t);

plot3(x, y, t, 'b-', 'LineWidth', 1.5);

%% 8
x = -2:0.01:2;
y = -2:0.01:2;
[X, Y] = meshgrid(x,y);
Z = X.^2 - Y.^2;
mesh(Z);
