
% Case 1
w = 0:0.1:30;

p = [-10+5j -10-5j];
z = [-2+1j -2-1j];

p = p(:);   % make column
z = z(:);

k = prod(p)/prod(z);

[num,den] = zp2tf(z,p,k);

sys = tf(num,den);
[mag,ph,ww] = bode(sys,w);   % mag is 1x1xN
mag = squeeze(mag);
plot(ww,mag)
xlabel('Frequency (rad/s)')
ylabel('Magnitude')
grid on

%%
% Case 2 (swapped poles/zeros)
w = 0:0.1:30;

p = [-2+1j -2-1j];
z = [-10+5j -10-5j];

p = p(:);
z = z(:);

k = prod(p)/prod(z);

[num,den] = zp2tf(z,p,k);

sys = tf(num,den);
[mag,ph,ww] = bode(sys,w);
mag = squeeze(mag);
plot(ww,mag)
xlabel('Frequency (rad/s)')
ylabel('Magnitude')
grid on

%%

% Compare magnitude responses for two pole/zero arrangements
w = 0:0.1:30;   % frequency vector (rad/s)

% Case 1
p1 = [-10+5j; -10-5j];
z1 = [-2+1j; -2-1j];
k1 = prod(p1)/prod(z1);
[b1,a1] = zp2tf(z1,p1,k1);
sys1 = tf(b1,a1);

% Case 2 (swapped poles/zeros)
p2 = [-2+1j; -2-1j];
z2 = [-10+5j; -10-5j];
k2 = prod(p2)/prod(z2);
[b2,a2] = zp2tf(z2,p2,k2);
sys2 = tf(b2,a2);

% Get magnitude (linear) at specified frequencies
[mag1,~,ww] = bode(sys1,w);
mag1 = squeeze(mag1);
[mag2,~,~] = bode(sys2,w);
mag2 = squeeze(mag2);

% Plot both responses
figure;
plot(ww,mag1,'b-','LineWidth',1.5); hold on;
plot(ww,mag2,'r--','LineWidth',1.5);
xlabel('Frequency (rad/s)');
ylabel('Magnitude (linear)');
legend('Case 1: poles at -10±5j, zeros at -2±1j','Case 2: swapped','Location','Best');
grid on;
title('Magnitude Response Comparison');
hold off;