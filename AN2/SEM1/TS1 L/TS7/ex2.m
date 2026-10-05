
num = 750;
den = conv([9 18 0], 1);

errortf(num, den);

% sistem original
num = 750;
den = [9 18 0];
Gd = tf(num, den);
G = feedback(Gd, 1);

[y, t] = step(G);
overshoot = (max(y) - 1) * 100;
disp(['Suprareglaj original: ', num2str(overshoot), '%']);

% cu compensator PD: C(s) = 1 + 0.5 s
num_pd = [0.5 1];
den_pd = 1;
Gd_new = series(tf(num_pd, den_pd), Gd);
G_new = feedback(Gd_new, 1);

[y_new, t_new] = step(G_new);
overshoot_new = (max(y_new) - 1) * 100;
disp(['Suprareglaj nou: ', num2str(overshoot_new), '%']);

figure; step(G, 'b', G_new, 'r'); legend('Original', 'Cu PD');