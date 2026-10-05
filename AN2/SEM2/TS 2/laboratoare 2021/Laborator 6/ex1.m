num=[1 5];
den=[1 3.6 0 0];
rlocus(num,den)

% portiunea de pe axa reala care apartine locului radacinilor este [-5,-3.6]

% 2 ramuri tind spre infinit

% 2 puncte de ramificatie: -6.55 si -2.74

[k poli]=rlocfind(num,den)
%% 
num=[1 6 8];
den=[1 3.6 0 0];
rlocus(num,den)

% portiunea care apartine locului radacinilor [-4.03;-3.6] reunit cu [-2;0)

% o ramura tinde la infinit

% nu avem puncte de ramificatie (solutia reala, -6, nu apartine locului radacinilor)

[k poli]=rlocfind(num,den)
%% 
num=[1];
den=[1 8 19 12];
rlocus(num,den)

% portiunea care apartine locului radacinilor

% (-infinit;-4] reunit cu [-2.96;-1.06]

% 3 ramuri tind la infinit

% un punct de ramificatie: -1.78

[k poli]=rlocfind(num,den)
%% 
num=[1];
den=[1 7 16 10];
rlocus(num,den)

% portiunea care apartine locului radacinilor (-infinit;-1]

% 3 ramuri tind la infinit

% 2 puncte de ramificatie: -2 si -2.66

[k poli]=rlocfind(num,den)