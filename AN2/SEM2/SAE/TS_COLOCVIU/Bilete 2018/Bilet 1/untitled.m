%==============================================================================
% APROXIMAREA FUNCTIEI DE AUTOCORELATIE A RASPUNSULUI PONDERE 
% PROCESUL HIDRAULIC
%==============================================================================
clc;%sterge continutul consolei
clear();
close("all");%inchide toate ferestrele active
%------------------------------------------------------------------------------
dTe=5;%perioada de esantionare in secunde
aH=[8.593;8.687;8.797;8.890;9.000;9.125;9.218;9.343;9.453;9.547;9.656;9.765;9.859;9.968];%esantioanele inaltimii coloanei de apa

aTimp=(linspace(0,(size(aH,1)-1)*dTe,size(aH,1)))';%variabila timp

aHCorr=xcorr(aH,'biased');%estimeaza functia de autocorelatie a raspunsului procesului

for k1=1:size(aHCorr,1)
    aTau(k1,1)=(k1-1);%esantioanele variabilei tau
end

for k1=1:fix(size(aHCorr,1)/2+1)
    X(k1,1)=aTau(k1,1);%matricea X prima linie
    X(k1,2)=1;%matricea X a doua linie
    aTau1(k1,1)=aTau(k1,1);%matrice tau1
end

Y=aHCorr(1:fix(size(aHCorr,1)/2+1),1);%matricea Y

Theta=(inv(X'*X))*X'*Y;%estimatorul celor mai mici patrate
a=Theta(1,1);%panta dreptei de aproximare
b=Theta(2,1);%ordonata la origine a dreptei de aproximare
aHCorrEst=a*aTau1+b;%valorile estimate ale dreptei de aproximare
dTf=max(aTau1(:,1))-b/a;%constanta de timp a procesului, valoare estimata
%------------------------------------------------------------------------
% Reprezentari grafice
%------------------------------------------------------------------------
subplot(211)
plot(aTimp,aH)%inaltimea coloanei de apa in functie de timp
grid on
title('H(t)')
xlabel(['Timp'])
%------------------------------------------------------------------------
subplot(212)
plot(aTau1,Y)%functia de autocorelatie in functie de tau
plot(aTau1,aHCorrEst)%functia de autocorelatie estimata in functie e tau
grid on
title('Functia de autocorelatie')
xlabel(['Tau' 'dTf=' string(dTf)])
%==============================================================================
% REMARCA:
% zgomotul este atenuat in esantioanele functiei de autocorelatie in comparatie cu
% esantioanele secventei prelevate din proces.
%==============================================================================