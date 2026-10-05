
% Parameters
fs = 1000;                 % sampling rate (Hz)
t  = 0:1/fs:1-1/fs;        % 1 second time vector
a  = 1;                    % amplitude

% Sum of 5 sinusoids
frequencies = [5,10,15,20,25]; % Hz
signalSum = zeros(size(t));
for i = 1:length(frequencies)
    w_i = 2*pi*frequencies(i);
    signalSum = signalSum + a*sin(w_i.*t);
end

figure;
plot(t, signalSum);
title('Sum of 5 Sinusoids');
xlabel('Time (s)');
ylabel('Amplitude');

% Rectangular pulse train at 30 Hz
pulseFrequency = 30; % Hz
pulseSignal = a * square(2*pi*pulseFrequency.*t); % default duty 50%
figure;
plot(t, pulseSignal);
title('Rectangular Pulse Train at 30 Hz');
xlabel('Time (s)');
ylabel('Amplitude');