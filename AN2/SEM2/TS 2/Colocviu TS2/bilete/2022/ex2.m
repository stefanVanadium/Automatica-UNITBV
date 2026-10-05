% L(s) = 9 / (s*(s+a)),  feedback negativ unitar

% a. verificare stare sistem pentru a=7
a = 7;

% ec. caracteristica bucla inchisa: s^2 + a*s + 9 = 0
p = roots([1 a 9]);
fprintf('poli bucla inchisa: %.4f  si  %.4f\n', p(1), p(2))
if all(real(p) < 0)
    fprintf('sistem STABIL\n')
elseif any(real(p) > 0)
    fprintf('sistem INSTABIL\n')
else
    fprintf('sistem LA LIMITA\n')
end

% locul radacinilor pt a=7 (k variaza 0->inf)
% polii reali la k=9 sunt marcati cu x
num = 1;
den = conv([1 0], [1 a]);
rlocus(num, den)
hold on
plot(real(p), imag(p), 'rx', 'MarkerSize', 12, 'LineWidth', 2)
title(sprintf('locul radacinilor, a=%g (x = polii la k=9)', a))
hold off

% -------------------------------------------------------
% b. SIMULINK - ce trebuie facut manual:
%
%    1. deschide modelul Simulink cu schema din figura
%
%    2. pentru constrangerea lui a:
%       - adauga un bloc "MATLAB Function" in model
%       - sau foloseste callback-ul modelului:
%         Model Properties > Callbacks > InitFcn si scrie:
%
%         if a < 6 || a > 8
%             error('parametrul a trebuie sa fie in intervalul [6, 8]')
%         end
%
%    3. in Workspace defineste a inainte de simulare:
%         a = 7;   % sau orice valoare din [6,8]
%
%    4. blocul Transfer Fcn din Simulink: num=[9], den=[1 a 0]
%       (den = s^2 + a*s = s*(s+a))
%
%    5. adauga bloc Step (default = treapta unitara la t=1)
%       si bloc Scope pentru a vedea raspunsul
%
%    6. ruleaza simularea (Run)
% -------------------------------------------------------

% validare a in matlab (echivalent cu ce face initFcn in simulink):
if a < 6 || a > 8
    error('parametrul a trebuie sa fie in intervalul [6, 8]')
end
fprintf('a = %g este valid\n', a)