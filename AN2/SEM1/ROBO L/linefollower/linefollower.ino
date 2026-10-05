#include <SparkFun_TB6612.h>

// Motor pins
#define AIN1 18
#define AIN2 19
#define PWMA 20

#define BIN1 10
#define BIN2 9
#define PWMB 8

#define STBY 30

constexpr int OFFSET_A = 1;
constexpr int OFFSET_B = 1;

Motor motorStg(AIN1, AIN2, PWMA, OFFSET_A, STBY);  // left motor
Motor motorDrp(BIN1, BIN2, PWMB, OFFSET_B, STBY);  // right motor

// Sensors
constexpr uint8_t SENZOR_STANGA = 2;
constexpr uint8_t SENZOR_DREAPTA = 5;

// Speeds (0–255)
constexpr int8_t V_CRUISE = 80;
constexpr int8_t V_SEARCH = 55;
constexpr int8_t V_TURN = 0;
constexpr int8_t V_CORRECT = 25;

unsigned long lastCorrection = millis();        // last correction time
constexpr unsigned long TIMEOUT_PIERDUT = 250;  // lost timeout in ms

void setup() {
  Serial.begin(115200);
  delay(800);  // boot stabilization

  pinMode(SENZOR_STANGA, INPUT);
  pinMode(SENZOR_DREAPTA, INPUT);

  Serial.println("Line follower ESP32-C3 started");
}

void loop() {
  bool L = digitalRead(SENZOR_STANGA);  // 1 = black line
  bool R = digitalRead(SENZOR_DREAPTA);

  int8_t vitezaStg, vitezaDrp;

  if (!L && !R) {  // 00 both white
    if (millis() - lastCorrection > TIMEOUT_PIERDUT) {
      // line lost, search
      vitezaStg = V_SEARCH;
      vitezaDrp = -V_SEARCH;
    } else {
      // go straight
      vitezaStg = V_CRUISE;
      vitezaDrp = V_CRUISE;
    }
  } else if (L && !R) {  // 10 line on left
    vitezaStg = V_CORRECT;
    vitezaDrp = V_TURN;
    lastCorrection = millis();  // update timer
  } else if (!L && R) {         // 01 line on right
    vitezaStg = V_TURN;
    vitezaDrp = V_CORRECT;
    lastCorrection = millis();  // update timer
  } else {                      // 11 both black
    vitezaStg = 0;              // short stop
    vitezaDrp = 0;
    delay(50);
  }

  motorStg.drive(vitezaStg);
  motorDrp.drive(vitezaDrp);

  // Debug only
  // static uint32_t t = 0;
  // if (millis() - t > 120) {
  //   Serial.printf("%d%d  %4d  %4d\n", L, R, vitezaStg, vitezaDrp);
  //   t = millis();
  // }
}
