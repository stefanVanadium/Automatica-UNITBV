%% a)

num_g = 10;
den_g = [1 10];

% constanta de timp: 1

%% b)

t = (0 : 0.1 : 10);
[a,f,w] = bode(num_g,den_g);
y = 3*a.*sin(2*w*t+f);
plot(y)