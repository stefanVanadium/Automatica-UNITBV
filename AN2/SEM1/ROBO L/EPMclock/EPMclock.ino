#define ENABLE_GxEPD2_GFX 0
#include <GxEPD2_BW.h>
#include <Fonts/FreeMonoBold9pt7b.h>
#include <Fonts/FreeMonoBold18pt7b.h>
#include <Fonts/FreeMonoBold24pt7b.h>   // pentru ora mare

#include <WiFi.h>
#include <WiFiUdp.h>
#include <TimeLib.h>

// ESP8266 CS(SS)=15,SCL(SCK)=14,SDA(MOSI)=13,BUSY=16,RES(RST)=5,DC=4

// pinii tăi (WeAct style)
#define CS_PIN    7
#define DC_PIN    1
#define RES_PIN   2
#define BUSY_PIN  3

// display-ul tău 1.54" 200x200
GxEPD2_BW<GxEPD2_154_D67, GxEPD2_154_D67::HEIGHT> display(
  GxEPD2_154_D67(CS_PIN, DC_PIN, RES_PIN, BUSY_PIN)
);

// WiFi
const char* ssid     = "gooncave";
const char* password = "g34nJipa69";

// NTP
const char* ntpServer = "ro.pool.ntp.org";   // mai aproape
const long  gmtOffset_sec = 2 * 3600;        // România → UTC+2 (fără DST acum)
const int   daylightOffset_sec = 3600;       // +1h vara (dacă vrei DST automat)

WiFiUDP ntpUDP;

String lastDate = "";
String timeStr  = "";

void setup() {
  Serial.begin(115200);
  delay(200);

  Serial.println("Start...");

  // conectare WiFi
  WiFi.begin(ssid, password);
  while (WiFi.status() != WL_CONNECTED) {
    delay(500);
    Serial.print(".");
  }
  Serial.println("\nConectat! IP: " + WiFi.localIP().toString());

  // NTP
  configTime(gmtOffset_sec, daylightOffset_sec, ntpServer);

  // e-paper
  display.init(115200, true, 50, false);   // serial debug, reset duration, spi freq
  display.setRotation(1);                  // landscape (200 lățime × 200 înălțime)

  display.setTextColor(GxEPD_BLACK);
  display.setFont(&FreeMonoBold9pt7b);

  // prima afișare completă
  updateFullScreen();
  lastDate = getDateStr();

  display.hibernate();   // economie curent
}

void loop() {
  timeStr = getTimeStr();

  // schimbare dată → refresh full
  String currentDate = getDateStr();
  if (currentDate != lastDate) {
    updateFullScreen();
    lastDate = currentDate;
    delay(2000);
  }
  // altfel doar partial pe zona cu ora
  else {
    updateTimePartial();
  }

  delay(1000);   // verifică la fiecare secundă
}

String getDateStr() {
  time_t now;
  time(&now);
  struct tm timeinfo;
  localtime_r(&now, &timeinfo);

  char buf[12];
  strftime(buf, sizeof(buf), "%Y-%m-%d", &timeinfo);
  return String(buf);
}

String getTimeStr() {
  time_t now;
  time(&now);
  struct tm timeinfo;
  localtime_r(&now, &timeinfo);

  char buf[9];
  strftime(buf, sizeof(buf), "%H:%M:%S", &timeinfo);
  return String(buf);
}

void updateFullScreen() {
  display.setFullWindow();
  display.firstPage();
  do {
    display.fillScreen(GxEPD_WHITE);

    // Dată sus
    display.setFont(&FreeMonoBold9pt7b);
    display.setCursor(10, 25);
    display.print("Data: " + getDateStr());

    // Oră mare centrată
    display.setFont(&FreeMonoBold18pt7b);
    int16_t tbx, tby; uint16_t tbw, tbh;
    display.getTextBounds(timeStr, 0, 0, &tbx, &tby, &tbw, &tbh);
    uint16_t x = (200 - tbw) / 2 - tbx;
    uint16_t y = 110 - tby;
    display.setCursor(x, y);
    display.print(timeStr);

  } while (display.nextPage());
}

void updateTimePartial() {
  // zona aproximativă cu ora (ajustează dacă e nevoie)
  uint16_t x = 10;
  uint16_t y = 60;
  uint16_t w = 180;
  uint16_t h = 60;

  display.setPartialWindow(x, y, w, h);
  display.firstPage();
  do {
    display.fillRect(x, y, w, h, GxEPD_WHITE);

    display.setFont(&FreeMonoBold18pt7b);
    int16_t tbx, tby; uint16_t tbw, tbh;
    display.getTextBounds(timeStr, 0, 0, &tbx, &tby, &tbw, &tbh);
    uint16_t cx = x + (w - tbw) / 2 - tbx;
    uint16_t cy = y + (h - tbh) / 2 + tbh - 5;   // centrare verticală
    display.setCursor(cx, cy);
    display.print(timeStr);

  } while (display.nextPage());
}