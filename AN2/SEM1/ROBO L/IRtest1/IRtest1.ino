#include <QTRSensors.h>

QTRSensors qtr;

// Pinii pe care vrei să-i folosești pe NodeMCU-32S (ESP32)
// Atenție: ESP32 NU are PA0, PA1 etc. – aceia sunt pentru Nucleo/STM32!
// Folosim GPIO-urile tale: 6, 7, 8, 15, 2, 0, 4, 16
const uint8_t sensorPins[] = {13, 12, 14, 27, 26, 25, 33, 32};
const uint8_t sensorCount = 8;

// Pinul pentru emitere IR (LED ON pin) – alege unul liber
// Poți folosi oricare GPIO care nu e deja folosit. Eu recomand GPIO 5 sau 17
#define EMITTER_PIN 5     // ← schimbă dacă vrei altul (ex: 17, 18, 19 etc.)

uint16_t sensorValues[8];

void setup() {
  Serial.begin(115200);
  delay(500);

  // Configurare senzori
  qtr.setTypeAnalog();                    // pentru QTR-8A
  // qtr.setTypeRC();                      // decomentati dacă ai QTR-8RC
  qtr.setSensorPins(sensorPins, sensorCount);
  qtr.setEmitterPin(EMITTER_PIN);         // control emitere IR

  pinMode(LED_BUILTIN, OUTPUT);
  digitalWrite(LED_BUILTIN, HIGH);        // LED aprins = setup în desfășurare

  Serial.println("=====================================");
  Serial.println("Calibrare QTR-8A pe NodeMCU-32S");
  Serial.println("Mișcă robotul 10-15 secunde peste linie alb-negru!");
  Serial.println("=====================================");

  delay(500);

  // Calibrare ~10-12 secunde
  for (uint16_t i = 0; i < 400; i++) {
    qtr.calibrate();
    delay(20);
  }

  digitalWrite(LED_BUILTIN, LOW);
  Serial.println("Calibrare terminată!");

  // Afișăm valorile min/max calibrate (util pentru debug)
  Serial.print("Min: ");
  for (uint8_t i = 0; i < sensorCount; i++) {
    Serial.print(qtr.calibrationOn.minimum[i]);
    Serial.print(' ');
  }
  Serial.println();

  Serial.print("Max: ");
  for (uint8_t i = 0; i < sensorCount; i++) {
    Serial.print(qtr.calibrationOn.maximum[i]);
    Serial.print(' ');
  }
  Serial.println();
  Serial.println();
}

void loop() {
  // Citește poziția liniei (0 = complet stânga, 7000 = complet dreapta)
  uint16_t position = qtr.readLineBlack(sensorValues);  // pentru linie NEAGRĂ
  // uint16_t position = qtr.readLineWhite(sensorValues); // dacă linia e albă

  Serial.print("Poziție: ");
  Serial.print(position);

  // Afișăm toate valorile brute ale senzorilor
  for (uint8_t i = 0; i < sensorCount; i++) {
    Serial.print("\t");
    Serial.print(sensorValues[i]);
  }
  Serial.println();

  delay(100);
}