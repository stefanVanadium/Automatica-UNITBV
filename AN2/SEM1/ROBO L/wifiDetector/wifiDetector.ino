#include <Arduino.h>

// Pinii buni de ADC1 pe NodeMCU-32S (recomandate în ordinea asta):
// VP  = GPIO36 → pin fizic D0
// VN  = GPIO39 → pin fizic D1 (cel mai curat)
// GPIO34 → pin fizic D2
// GPIO35 → pin fizic D3
// GPIO32 → pin fizic D4
// GPIO33 → pin fizic D5 (merge și el perfect)

const int adcPin = 39;      // ← CEL MAI BUN ȘI MAI STABIL PIN pe NodeMCU-32S
// dacă vrei altul, schimbă cu 36, 34, 35, 32 sau 33

void setup() {
  Serial.begin(115200);
  analogReadResolution(12);   // 12 biți = 0–4095
  delay(100);
  Serial.println("AD8317 RF Detector pornit – NodeMCU-32S");
  Serial.println("Pin folosit: GPIO39 (VN)");
}

void loop() {
  int raw = analogRead(adcPin);
  float voltage = raw * 3.3 / 4095.0;

  Serial.printf("RAW: %4d   |   V: %.3f V\n", raw, voltage);
  delay(200);   // 5 citiri pe secundă, perfect
}