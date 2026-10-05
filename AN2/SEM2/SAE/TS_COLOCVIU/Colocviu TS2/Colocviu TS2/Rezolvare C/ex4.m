%% a)

k = 1;
num_gcd = k;
den_gcd = [1 4 0 0];
rlocus(num_gcd,den_gcd);

[k,p] = rlocfind(num_gcd,den_gcd)
% In punctul selectat (-11.5672 + 4.5409i) polii sistemului sunt: p1 = -12.5932, p2,3 = 4.2966 +/- 9.4739i (sistemul este instabil).
% Valoarea factorului de amplificare in acest caz este k = 1.3628 * 10^3

