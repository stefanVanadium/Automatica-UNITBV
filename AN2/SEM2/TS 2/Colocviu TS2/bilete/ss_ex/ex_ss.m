A = [-1 0 0; 0 -2 1; 0 -1 -3];
B = [1 0; 0 1; 1 -1];
C = [1 0 1; 0 1 -1];
D = zeros(2, 2);

sys = ss(A, B, C, D);

%% a) G12(s) - de la intrarea 2 la iesirea 1
G = tf(sys);
G12 = G(1, 2);
fprintf('G12(s):\n');
G12

%% b) raspuns la impuls Dirac (simulare analitica)
figure(1);
impulse(sys);
grid on;
title('Raspuns la impuls Dirac');
