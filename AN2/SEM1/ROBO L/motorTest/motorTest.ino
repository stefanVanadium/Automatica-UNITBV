#define PWMA 4   // PWM pentru motor A
#define AIN1 16
#define AIN2 17

#define PWMB 5   // PWM pentru motor B
#define BIN1 18
#define BIN2 19

// Definim canalele PWM
const int canalA = 0;
const int canalB = 1;
const int frecventa = 5000;  // 5 kHz e ok pentru TB6612
const int rezolutie = 8;     // 8 biți → valori de la 0 la 255

void setup() {
  // Setăm pinii de direcție
  pinMode(AIN1, OUTPUT);
  pinMode(AIN2, OUTPUT);
  pinMode(BIN1, OUTPUT);
  pinMode(BIN2, OUTPUT);

  // Configurăm canalele PWM (noua metodă)
  ledcAttach(PWMA, frecventa, rezolutie);  // atașăm direct pinul
  ledcAttach(PWMB, frecventa, rezolutie);

  // sau dacă vrei să folosești canale separate (recomandat):
  // ledcSetup(canalA, frecventa, rezolutie);
  // ledcSetup(canalB, frecventa, rezolutie);
  // ledcAttachPin(PWMA, canalA);
  // ledcAttachPin(PWMB, canalB);

  // Direcție înainte pentru ambele motoare
  digitalWrite(AIN1, HIGH);
  digitalWrite(AIN2, LOW);
  digitalWrite(BIN1, HIGH);
  digitalWrite(BIN2, LOW);
}

void loop() {
  // Motor A → full speed (255 din 255)
  ledcWrite(PWMA, 255);

  // Motor B → aprox. jumătate (128 din 255 e exact 50%)
  // Tu ai pus 51 → e doar ~20%, de aia merge foarte încet
  ledcWrite(PWMB, 128);   // 50% din viteză
  // sau dacă vrei 20-25%: ledcWrite(PWMB, 64);
}