% G0(s) = (s^2 + 7s + 18) / (s^2 + 7s + 9)  - bucla inchisa

num0 = [1 7 18];
den0 = [1 7 9];
G0 = tf(num0, den0);

% a. spatiu de stare pentru S-function (vezi G0sfun.m)
%    in Simulink: bloc S-Function cu Name='G0sfun', Parameters=''
%                 conectat la bloc Impulse (Signal Builder) si Scope
[A, B, C, D] = tf2ss(num0, den0);

% verificare rapida - raspuns impuls direct din tf
figure(1)
impulse(G0)
title('raspuns impuls G0')

% b. observabilitate
sys = ss(A, B, C, D);

fprintf('A = \n'); disp(A)
fprintf('B = \n'); disp(B)
fprintf('C = \n'); disp(C)
fprintf('D = %g\n', D)

M_obs = obsv(A, C);
fprintf('\nmatricea de observabilitate:\n'); disp(M_obs)
fprintf('det(obsv) = %.4f\n', det(M_obs))

if det(M_obs) ~= 0
    fprintf('sistemul este OBSERVABIL\n')
else
    fprintf('sistemul NU este observabil\n')
end
