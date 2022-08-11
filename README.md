# hitager
The hitager open source project provides a GUI based Windows application for writing and reading 125kHz automotive RFID key transponders commonly used in car keys. It uses an Arduino (software also provided in this project) as interface between a PCF7991 base station IC (ABIC) and a Windows PC running the AESHitager GUI.
Additional infos can be found at the homepage of the project initiator's [website](https://kivijakola.fi/projektit/2021/01/27/hitag-open-source-tool/).

## Main Features:
- Supported Protocols:
  - Hitag2, Hitag2+EE, Hitag2 Extended, Hitag2 BMW EE Extention
  - Hitag3
  - Hitag AES
  - Hitag Pro
- Special Devices:
  - VVDI Super Chip
  - BMW Key (e.g. PCF7944, PCF7945, PCF7953)

## Hardware:
### Hardware Setup:
AESHitager PC <-------> Arduino <-------> PCF7991 IC <- - - - -> Key Transponder

### Required Hardware
1. Arduino Nano / Arduino Mega2560
2. Board with PCF7991 Advanced Base Station IC (ABIC) (e.g. IPROG RFID Adapter, Key reader from Car, Hitag2 v3.1, ZedBull Mini)

### How to Build your own Hitager  

1. **Arduino**  
  - Download the latest Hitaguino release from the Github page
  - **Flash Arduino (Option 1):**   
    Use Avrdudess (https://github.com/ZakKemble/AVRDUDESS, ~2MB) for uploading the .hex file only (Select "Arduino" as Programmer, Select proper COM Port, Baud Rate "115200", select .hex file in "Flash" section, click Go, wait until programming finished)
 
   - **Flash Arduino (Option 2):**   
   Open the .ino file in your arduino IDE, compile & upload it to the board  
     
      **Hint:** It might be necessary to press and release the reset button on the araduino board shortly before upload process starts.

2. **RFID Reader**  
   It is possible to use any available PCB containing a PCF7991 base station IC (ABIC). The cheapest solution seems to be IPROG RFID Adapter (available for ~ 15$)
   
   | Arduino Nano Pin  | PCF7991 Pin Nr. | PCF7991 Pin Name | IPROG D-SUB PIN |
   | :------------: | :----------: | :-----------: | :-------------: |
   |        D2      |      10      |       DOUT    |         5       |
   |        D7      |       9      |       DIN     |         3       |
   |        D6      |       8      |       CLK     |         4       |
   |  D3 / D9* (optional) |       6      |      XTAL1    |        20       |
   | GND (optional) |  (see Hint)  |   (see Hint)  |        36       |
   |   VCC / +5V    |      -       |        -      |        32       |
   
   \* : For Arduino Mega 2560
   
   <img src="/documentation/PCF7991_Footprint.JPG" width=30% height=30%>
   
   **Hint 1:**  
   Connecting D3 is only required if the ABIC is not supplied with clock source (e.g. Crystal Oscillator) on the PCB. In this case, Arduino's clock output can be used.  
   **Hint 2:**  
   Connecting GND is only required if not connected via USB. In this case connect Arduino GND to PCB GND (not directly at ABIC GND pin)
   
   **Hardware Variants:**
    - **Hitag2 v3.1, ZedBull Mini** (and others boards with on-board crystal oscillator and µC):  
      - Connect Arduino according to table
      - Do not connect D3, as clock source is already present at the PCB
      - In order to stop the µC interfering with the ABIC, it must be held in Reset. This can be done by connecting µC's reset pin to GND
      - Connect the tool via USB in order to power it (wiring GND not necessary as it is provided by USB port)
    - **IPROG RFID Adapter**
      - The adapter can be used without any modification on the PCB
      - Connect with arduino according to table column "IPROG  D-Sub Pin"   <br>
      - Below the schematic of the Iprog PCB:
      <img src="https://user-images.githubusercontent.com/82545992/183724661-752b45e0-bc28-4f21-9efb-90c9170f3230.png" width=30% height=30%>

