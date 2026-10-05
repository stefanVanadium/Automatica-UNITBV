t = -2:0.01:2;
x = cos(2*pi*t);
y = sin(2*pi*t);

[X,Y] = meshgrid(x,y);

contour3()
title('Cosine and Sine Waves');