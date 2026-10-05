
w = 0:0.1:30;

p = [-10+5j -10-5j];
z = [-2+1j -2-1j];

p = p(:);    % ensure column vector
z = z(:);    % ensure column vector

k = prod(p)/prod(z);        % real because conjugate pairs

[num,den] = zp2tf(z,p,k);

sys = tf(num,den);          
[mag,ph,ww] = bode(sys,w);  % mag is 1x1xN
mag = squeeze(mag);         % make it a vector

plot(ww,mag)
xlabel('Frequency (rad/s)')
ylabel('Magnitude')
grid on

%% ai

% Parametri
w = logspace(-1,2,1000);   % frecvență (rad/s), folosit semilog pentru Bode
p = [-10+5j, -10-5j];
z = [-2+1j, -2-1j];

p = p(:); z = z(:);        % asigură vector coloană
k = prod(p)/prod(z);       % câștig care păstrează k real pentru perechi conjugate

% Funcția inițială (fără zerouri adiționale) — doar poli p
[num0, den0] = zp2tf([], p, 1);   % sistem de referință cu câștig 1
sys0 = tf(num0, den0);

% Sistemul cu zerourile introduse (câștig ales pentru aceeași scara)
[num1, den1] = zp2tf(z, p, k);
sys1 = tf(num1, den1);

% Calcul bode (magnitudine)
[mag0,~,ww] = bode(sys0, w); mag0 = squeeze(mag0);
[mag1,~,~ ] = bode(sys1, w); mag1 = squeeze(mag1);

% Convertire în dB
mag0dB = 20*log10(mag0);
mag1dB = 20*log10(mag1);

% Plotează
figure
semilogx(ww, mag0dB, 'b-', ww, mag1dB, 'r--', 'LineWidth', 1.2)
grid on
xlabel('Frecvența (rad/s)')
ylabel('Magnitudine (dB)')
legend('Înainte (numitor cu p)','După (adăugat zerouri)', 'Location','best')
title('Efectul introducerii perechii de zerouri asupra caracteristicii de amplitudine')

% Marcaje verticale la valorile părților imaginare (pozitive)
im_p = abs(imag(p(1)));   % =5
im_z = abs(imag(z(1)));   % =1
yl = ylim;
hold on
xline(im_p, 'k:', 'LineWidth',1);      % linie pentru poli (Im(p) = 5 rad/s)
xline(im_z, 'm:', 'LineWidth',1);      % linie pentru zerouri (Im(z) = 1 rad/s)

% Etichete lângă linii (poziționează puțin deasupra limitei inferioare)
text(im_p*1.05, yl(1)+0.05*(yl(2)-yl(1)), sprintf('|Im(p)|=%.2g', im_p), 'Color','k')
text(im_z*1.05, yl(1)+0.15*(yl(2)-yl(1)), sprintf('|Im(z)|=%.2g', im_z), 'Color','m')
hold off

% Opțional: afișare hartă poli-zerouri
figure
pzplot(tf(num1,den1))
title('Hartă poli-zerouri (sistem cu zerouri adăugate)')
grid on
