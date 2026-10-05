num = [120 120];
den = conv([1 3], [1 4]);

G = tf(num, den);

% Print values
fprintf('Percent overshoot = %.3f %%\n', Mp);
fprintf('Rise time = %.4g s\n', tr);
fprintf('Peak time = %.4g s\n', tp);
fprintf('Settling time = %.4g s\n', ts);

% Calculează limitele la s -> 0
s = 0;
G0 = evalfr(G, s);                % Kp = G(0)
sG0 = evalfr(series(tf([1 0],1), G), s);   % Kv = lim s*G(s)
s2G0 = evalfr(series(tf([1 0 0],1), G), s);% Ka = lim s^2*G(s)

% Redu la valori reale dacă părțile imaginare sunt neglijabile
tol = 1e-12;
if abs(imag(G0)) < tol, G0 = real(G0); end
if abs(imag(sG0)) < tol, sG0 = real(sG0); end
if abs(imag(s2G0)) < tol, s2G0 = real(s2G0); end

Kp = G0;
Kv = sG0;
Ka = s2G0;

% Calculează erorile staționare
% Step: ess = 1/(1+Kp)
if isnan(Kp)
    ess_step = NaN;
elseif isinf(Kp)
    ess_step = 0;
else
    ess_step = 1 / (1 + Kp);
end

% Ramp: ess = 1/Kv
if isnan(Kv)
    ess_ramp = NaN;
elseif Kv == 0
    ess_ramp = Inf;
elseif isinf(Kv)
    ess_ramp = 0;
else
    ess_ramp = 1 / Kv;
end

% Parabola: ess = 1/Ka
if isnan(Ka)
    ess_parabola = NaN;
elseif Ka == 0
    ess_parabola = Inf;
elseif isinf(Ka)
    ess_parabola = 0;
else
    ess_parabola = 1 / Ka;
end

% Afișare rezultate
fprintf('Kp = %g\n', Kp);
fprintf('Kv = %g\n', Kv);
fprintf('Ka = %g\n', Ka);
fprintf('ess_step = %g\n', ess_step);
fprintf('ess_ramp = %g\n', ess_ramp);
fprintf('ess_parabola = %g\n', ess_parabola);

%% 2


% Given plant
num = [120 120];
den = conv([1 3], [1 4]); % (s+3)*(s+4)
s = tf('s');
G = tf(num, den);

% Unity-feedback closed-loop (no compensator)
T0 = feedback(G, 1);
info0 = stepinfo(T0);

fprintf('No compensator: Overshoot = %.3f%%, RiseTime = %.4g s, SettlingTime = %.4g s\n', ...
    info0.Overshoot, info0.RiseTime, info0.SettlingTime);

% 1) Add a pole (lag) at -1: C_lag = 1/(s+1)
C_lag = 1/(s + 1);        % compensator with pole at -1
T_lag = feedback(C_lag * G, 1);
info_lag = stepinfo(T_lag);
fprintf('With lag (pole at -1): Overshoot = %.3f%%, RiseTime = %.4g s, SettlingTime = %.4g s\n', ...
    info_lag.Overshoot, info_lag.RiseTime, info_lag.SettlingTime);

% 2) Recommended: lead compensator to reduce overshoot: C_lead = (s+1)/(s+10)
C_lead = (s + 1)/(s + 10); % zero at -1, pole at -10 (lead behaviour)
T_lead = feedback(C_lead * G, 1);
info_lead = stepinfo(T_lead);
fprintf('With lead (zero -1, pole -10): Overshoot = %.3f%%, RiseTime = %.4g s, SettlingTime = %.4g s\n', ...
    info_lead.Overshoot, info_lead.RiseTime, info_lead.SettlingTime);

% Plot comparison
tfinal = 5; % adjust if needed
figure;
step(T0, T_lag, T_lead, 0:0.001:tfinal);
legend('No comp','Lag (pole -1)','Lead (z=-1,p=-10)','Location','Best');
grid on;
title('Closed-loop step responses');