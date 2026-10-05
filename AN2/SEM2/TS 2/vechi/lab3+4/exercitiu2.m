%% parametri sistem
M = 1; B = 2; K = 1;

num_p = [1];
den_p = [M, B, K];

U = 0.4;
w = 1;
t = 0:0.01:20;
u_in = U * sin(w * t);


%% definire regulatoare
num_R = {[10, 5], [2, 10, 5]};
den_R = {[1, 0], [0.01, 1, 0]};
nume = {'pi', 'pid'};

y = cell(1,2);
num_open = cell(1,2);
den_open = cell(1,2);


%% calcul pentru ambele
for i = 1:2
    
    num_open{i} = conv(num_R{i}, num_p);
    den_open{i} = conv(den_R{i}, den_p);

    num_cl = num_open{i};
    den_cl = den_open{i} + [zeros(1, length(den_open{i})-length(num_open{i})), num_open{i}];

    [mag, phase] = bode(num_cl, den_cl, w);
    y{i} = U * mag * sin(w*t + deg2rad(phase));

    fprintf('=== %s ===\n', nume{i})
    fprintf('|g_cl(j1)| = %.4f\n', mag)
    fprintf('faza       = %.2f grade\n', phase)
    fprintf('y(t)       = %.4f * sin(t + %.4f rad)\n\n', U*mag, deg2rad(phase))
end


%% grafice
figure(1)

subplot(2,1,1)
plot(t, u_in, 'b--', t, y{1}, 'r')
legend('intrare u(t)', 'iesire y(t) - pi')
title('sistem cu pi')
grid on

subplot(2,1,2)
plot(t, u_in, 'b--', t, y{2}, 'r')
legend('intrare u(t)', 'iesire y(t) - pid')
title('sistem cu pid')
grid on


%% bode
figure(2)

subplot(1,2,1)
margin(num_open{1}, den_open{1})
title('bode - pi')

subplot(1,2,2)
margin(num_open{2}, den_open{2})
title('bode - pid')


%% nyquist
figure(3)

subplot(1,2,1)
nyquist(num_open{1}, den_open{1})
title('nyquist - pi')

subplot(1,2,2)
nyquist(num_open{2}, den_open{2})
title('nyquist - pid')