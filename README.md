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
### Hardware Architecture:
AESHitager PC <-------> Arduino <-------> PCF7991 IC <- - - - -> Key Transponder

### Required Hardware
1. Arduino Nano / Arduino Mega2560
2. Board with PCF7991 Advanced Base Station IC (ABIC) (e.g. IPROG RFID Adapter, Key reader from Car, Hitag2 v3.1, ZedBull Mini)

### Build your own Hitager
Detailed information on how to build the required hardware can be found in the project's [**Wiki**](https://github.com/kivijakola/hitager/wiki/Building-your-own-hitager-hardware)
