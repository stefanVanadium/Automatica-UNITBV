
% Load data (assumes variables t and x in the file)
S = load('Laborator1_Semnal1.mat');
t = S.t;
x = S.x;

% Sampling parameters
dt = mean(diff(t));        % time step (assumed uniform)
Fs = 1/dt;                 % sampling frequency (Hz)
L = length(x);             % signal length

% FFT and single-sided spectrum
nfft = 2^nextpow2(L);      % zero-pad to next 2^N (optional)
Y = fft(x, nfft);
P2 = abs(Y)/L;             % two-sided spectrum (scaled)
P1 = P2(1:nfft/2+1);       % keep positive side
P1(2:end-1) = 2*P1(2:end-1);

% frequency vector
f = Fs*(0:(nfft/2))/nfft;

% Plot amplitude spectrum
figure;
plot(f, P1, 'LineWidth', 1.2);
xlim([0 Fs/2]);
xlabel('Frequency (Hz)');
ylabel('Amplitude');
title('Fourier Spectrum (single-sided) of the signal');
grid on;
