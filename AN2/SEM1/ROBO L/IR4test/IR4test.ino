#define SENSOR_PIN 

void setup() {
  Serial.begin(115200);
}

void loop() {
  int sensorValue = analogRead(SENSOR_PIN); // 0-4095
  Serial.println(sensorValue);               // valoare pe linie noua
  delay(500);
}
