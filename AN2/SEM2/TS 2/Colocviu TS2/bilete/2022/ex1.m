% L(s) = k / (s*(s+6))  =>  ec. caracteristica: s^2 + 6s + k = 0

num = 1;
den = conv([1 0], [1 6]);

% a. locul radacinilor
rlocus(num, den)
title('locul radacinilor')

% b. poli bucla inchisa in functie de k
fprintf('%-8s  %-20s  %-20s  %s\n', 'k', 'pol 1', 'pol 2', 'stabil?')
for k = [-5 -1 0 1 5 10]
    p = roots([1 6 k]);
    stabil = 'DA';
    if any(real(p) > 0), stabil = 'NU - instabil'; end
    if any(real(p) == 0), stabil = 'NU - marginal'; end
    fprintf('%-8g  %-20.4f  %-20.4f  %s\n', k, p(1), p(2), stabil)
end
