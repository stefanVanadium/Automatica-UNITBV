num_G0=[750];
den_G0=[1 36 205 750];
G0=tf(num_G0,den_G0)

%polii sistemului
p=roots(den_G0)

%reducerea ordinului modelului
r=[p(2) p(3)]
num_G0_red=750/30;
den_G0_red=poly(r);
G0_red= tf(num_G0_red,den_G0_red)

%raspunsul la treapta unitara
subplot(2,1,1)
step(G0)
subplot(2,1,2)
step(G0_red)

% determinarea erorii stationare finite-model simplificat
%  circuit deschis
% se poate observa ca valoarea finita este la o marime treapta unitara
