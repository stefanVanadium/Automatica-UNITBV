
S = load('Laborator1_Semnal1.mat')
t = S.t(:)
x = S.x(:)

assert(numel(t) == numel(x), 'Time and signal length mismatch')

dt = mean(diff(t))
Fs = 1 / dt
L = numel(x)

x = double(x)
x = x - mean(x)

w = hann(L, 'periodic')
coherent_gain = sum(w) / L
xw = x .* w

nfft = 2^nextpow2(L * 4)

X = fft(xw, nfft)

scale_amp = 1 / (L * coherent_gain)
scale_pow = 1 / (Fs * L * coherent_gain^2)

P2_amp = abs(X) * scale_amp
P1_amp = P2_amp(1:nfft/2 + 1)
P1_amp(2:end-1) = 2 * P1_amp(2:end-1)

P2_psd = (abs(X).^2) * scale_pow
P1_psd = P2_psd(1:nfft/2 + 1)
P1_psd(2:end-1) = 2 * P1_psd(2:end-1)

f = Fs * (0:nfft/2)' / nfft
df = Fs / nfft

signal_energy_time = sum(x.^2) * dt
signal_energy_freq = sum(P2_psd) * df
energy_error = abs(signal_energy_time - signal_energy_freq) / signal_energy_time

figure
plot(f, P1_amp, 'LineWidth', 1.4)
xlim([0 Fs/2])
xlabel('Frequency (Hz)')
ylabel('Amplitude')
title('Single-sided amplitude spectrum')
grid on

figure
plot(f, 10*log10(P1_psd), 'LineWidth', 1.4)
xlim([0 Fs/2])
xlabel('Frequency (Hz)')
ylabel('Power spectral density (dB/Hz)')
title('Single-sided PSD')
grid on

disp(['Frequency resolution = ' num2str(df) ' Hz'])
disp(['Relative energy error = ' num2str(energy_error)])
