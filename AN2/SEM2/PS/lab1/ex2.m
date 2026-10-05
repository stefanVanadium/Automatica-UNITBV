
% Example parameters (set these if not already)
fs = 1000;                % sampling frequency (Hz)
t  = 0:1/fs:1-1/fs;       % time vector (1 s)
a  = 1;                   % amplitude
pulseFrequency = 30;      % Hz
pulseSignal = a * square(2*pi*pulseFrequency.*t); % 50% duty

% FFT
L = length(pulseSignal);
nfft = 2^nextpow2(L);     % zero-pad to next pow2 (optional)
Y = fft(pulseSignal, nfft);
P2 = abs(Y)/L;            % two-sided spectrum (scaled)
P1 = P2(1:nfft/2+1);      % single-sided
P1(2:end-1) = 2*P1(2:end-1);

% Frequency vector
f = fs*(0:(nfft/2))/nfft;

% Plot single-sided amplitude spectrum
figure;
plot(f, P1, 'LineWidth', 1.2);
xlim([0 fs/2]);
xlabel('Frequency (Hz)');
ylabel('Amplitude');
title('Single-Sided Amplitude Spectrum (FFT)');
grid on;