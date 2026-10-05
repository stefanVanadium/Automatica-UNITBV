t = 0:0.001:0.02;
f = sin(2*pi*50*t);
g = f + 0.2;

plot(t, f, 'g--')
hold on
plot(t, g, 'r*')
hold off

xlabel('t')
ylabel('Amplitude')
