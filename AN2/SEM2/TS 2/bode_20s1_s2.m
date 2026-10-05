% ============================================================
% Subiect 2 (sectiunea 20 din Rezumat_Examen_TS2.tex)
% G(s) = 20(s+1)/(s+2), reactie unitara, sistem TIP 0
% Bode (modul + faza) + eroare stationara la treapta
% ============================================================

close all; clear; clc;

%% 1) Functia de transfer
num = [20 20];   % 20*(s+1) = 20s + 20
den = [1 2];     % s+2
G = tf(num, den);

disp('G(s) ='); G

%% 2) Diagrama Bode exacta (MATLAB)
figure('Name', 'Bode G(s) = 20(s+1)/(s+2)');
w = logspace(-2, 3, 1000);   % 0.01 -> 1000 rad/s, ca sa vezi ambele asimptote orizontale
bode(G, w);
grid on;

%% 3) Suprapunere asimptote (aproximarea liniara pe bucati, vezi sectiunea 7)
% forma standard: G(jw) = 10 * (1+jw) / (1+jw/2)  => K=10 (20dB), wf1=1 (zero), wf2=2 (pol)
K_dB = 20*log10(10);          % 20 dB, platou de joasa frecventa
wf1 = 1;  % frecventa de frangere a zero-ului (s+1)
wf2 = 2;  % frecventa de frangere a polului  (s+2)

w_asym = logspace(-2, 3, 500);
mag_asym_dB = zeros(size(w_asym));
for k = 1:numel(w_asym)
    wk = w_asym(k);
    m = K_dB;
    if wk > wf1
        m = m + 20*log10(wk/wf1);   % +20dB/dec dupa zero
    end
    if wk > wf2
        m = m - 20*log10(wk/wf2);   % -20dB/dec dupa pol (se aduna la panta de mai sus)
    end
    mag_asym_dB(k) = m;
end

phase_asym_deg = atand(w_asym/1) - atand(w_asym/2);  % faza exacta a formei standard (nu aprox. pe 3 drepte)

figure('Name', 'Modul si faza: exact vs asimptotic');
subplot(2,1,1);
semilogx(w_asym, mag_asym_dB, 'r--', 'LineWidth', 1.3); hold on;
[mag, ~, wexact] = bode(G, w);
semilogx(wexact, 20*log10(squeeze(mag)), 'b', 'LineWidth', 1.3);
grid on; xlabel('\omega [rad/s]'); ylabel('|G(j\omega)| [dB]');
legend('asimptotic', 'exact', 'Location', 'best');
title('Caracteristica modul-pulsatie');
xline(wf1, 'k:'); xline(wf2, 'k:');

subplot(2,1,2);
[~, phase] = bode(G, w);
semilogx(w, squeeze(phase), 'b', 'LineWidth', 1.3); hold on;
semilogx(w_asym, phase_asym_deg, 'r--', 'LineWidth', 1.3);
grid on; xlabel('\omega [rad/s]'); ylabel('faza [grade]');
legend('exact', 'exact (aceeasi formula)', 'Location', 'best');
title('Caracteristica faza-pulsatie');
xline(wf1, 'k:'); xline(wf2, 'k:');

%% 4) Eroare stationara la treapta (sistem TIP 0 -> se foloseste Kp, nu Kv)
Kp = dcgain(G);   % G(0)
e_ss_treapta = 1/(1+Kp);
fprintf('\nKp = G(0) = %.4f\n', Kp);
fprintf('e_ss (treapta unitara, reactie unitara) = 1/(1+Kp) = %.4f\n', e_ss_treapta);

%% 5) Verificare: raspunsul la treapta al sistemului in bucla inchisa
Gcl = feedback(G, 1);
figure('Name', 'Raspuns la treapta unitara (bucla inchisa)');
step(Gcl); grid on;
yline(1 - e_ss_treapta, 'r--', sprintf('1 - e_{ss} = %.3f', 1 - e_ss_treapta));
title('Raspunsul la treapta al sistemului cu reactie unitara');
