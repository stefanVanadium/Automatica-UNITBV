% sa se incarce semnalul si sa se reprezinte grafic inclusiv spectrul
% Fourier
load ex1.mat;
Te = 0.01;

N = length(x);
fe = 1 / Te;
X = fft(x);
Xabs = abs(X) / (N/2);
magX = Xabs(1, 1:N/2 + 1);
f = [0: N/2] * fe / N;

subplot(2, 1, 1); plot(t, x); title('Semnalul x');
subplot(2, 1, 2); plot(f, magX); title('Spectrul Fourier'); 