# hitager
This open source project provides a GUI based Windows application for programming and reading automotive 125kHz RFID key transponders commonly used in car keys. It uses an Arduino (software also provided in this project) as interface to a PCF7991 base station IC.

## Main Features:
- Supported Protocols:
  - Hitag2, Hitag2+EE, Hitag2 Extended, Hitag2 BMW Extention
  - Hitag3
  - Hitag AES
- Special Devices:
  - VVDI Super Chip
  - BMW Key (e.g. PCF7944, PCF7945, PCF7953)

## Hardware:
### Hardware Setup:
AESHitager PC <-------> Arduino <-------> PCF7991 IC <- - - - -> Key Transponder

### Required Hardware
1. Arduino Nano / Arduino Mega2560
2. Board with PCF7991 ABIC (IPROG RFID Adapter, Key reader from Car, Hitag2 v3.1, ZedBull Mini)

### How to Build your own Hitager  

1. **Arduino**  
  - Download the newest Hitaguino release from this page
  - **Option 1:**   
    Use Avrdudess (https://github.com/ZakKemble/AVRDUDESS) for uploading the .hex file only (Select "Arduino" as Programmer, Select proper COM Port, Baud Rate "115200", select .hex file in "Flash" section, click Go, wait until programming finished)
 
   - **Option 2:**   
   Open the .ino file in your arduino IDE, compile & upload it to the boar
   Hint: It might be necessary to press and release the reset button on the araduino board shortly before upload process starts.

2. **RFID Reader**  
   It is possible to use any available PCB containing a PCF7991 base station IC (ABIC). The cheapest solution seems to be IPROG RFID Adapter (available for ~ 15$)
   
   | Arduino Pin Nr | ABIC Pin Nr. | ABIC Pin Name | IPROG D-SUB PIN |
   | -------------- | ------------ | ------------- | --------------- |
   |        D2      |      10      |       DOUT    |        11       |
   |        D7      |       9      |       DIN     |        13       |
   |        D6      |       8      |       CLK     |        12       |
   |  D3 (optional) |       6      |      XTAL1    |        26       |
   | GND (optional) |  (see Hint)  |   (see Hint)  |        39       |
   |   VCC / +5V    |      -       |        -      |        43       |
   
   
   **Hint 1:**  
   Connecting D3 is only required if the ABIC is not supplied with clock source (e.g. Crystal Oscillator) on the PCB. In this case, Arduino's clock output can be used.  
   **Hint 1:**  
   Connecting GND is only required if not connected via USB. In this case connect Arduino GND to PCB GND (not directly at ABIC GND pin)
   
    - Hitag2 v3.1, ZedBull Mini (and others boards with Crystal Oscillator and containing a µC):  
      - Connect Arduino according to table
      - Do not connect D3, as clock source is already present at the PCB
      - In order to stop the µC interfering with the ABIC, it must be held in Reset. This can be done by connecting µC's reset pin to GND
      - Connect the tool via USB in order to power it (wiring GND not necessary as it is provided by USB port)
    - IPROG RFID Adapter
      - The adapter can be used without any modification on the PCB
      - Connect with arduino according to table column "IPROG  D-Sub Pin"
