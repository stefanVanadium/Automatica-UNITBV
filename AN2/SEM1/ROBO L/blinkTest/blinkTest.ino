// Pinii pentru motoare (rămân neschimbați)
#define PWMA 4
#define AIN1 16
#define AIN2 17
#define PWMB 5
#define BIN1 18
#define BIN2 19

// Pinul D1 de la modulul cu 8 senzori line follower
#define SENSOR_D1 13   // schimbă aici dacă folosești alt GPIO

void setup() {
  Serial.begin(115200);
  
  // Motoare – la fel ca înainte
  pinMode(AIN1, OUTPUT);
  pinMode(AIN2, OUTPUT);
  pinMode(BIN1, OUTPUT);
  pinMode(BIN2, OUTPUT);
  digitalWrite(AIN1, HIGH);
  digitalWrite(AIN2, LOW);
  digitalWrite(BIN1, HIGH);
  digitalWrite(BIN2, LOW);
  ledcAttach(PWMA, 5000, 8);
  ledcAttach(PWMB, 5000, 8);
  ledcWrite(PWMA, 255);
  ledcWrite(PWMB, 128);

  // Configurăm senzorul D1
  pinMode(SENSOR_D1, INPUT);        // NU mai e nevoie de PULLUP la TCRT5000
  // (el are deja rezistențe pull-up pe modul)

  Serial.println("==================================");
  Serial.println("Test senzor line follower - D1");
  Serial.println("Trece cu senzorul peste negru și alb");
  Serial.println("==================================");
  delay(2000);
}

void loop() {
  int valoare = digitalRead(SENSOR_D1);

  if (valoare == LOW) {
    Serial.println("D1 → NEGRU  █████████");
  } else {
    Serial.println("D1 → ALB    ░░░░░░░░░");
  }

  delay(100);   // ca să nu inunde monitorul prea tare
}