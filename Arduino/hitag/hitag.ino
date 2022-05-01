/*
 * (c) Janne Kivijakola
 * janne@kivijakola.fi
 */


#include <avr/io.h>
#include <util/delay.h>

//#define F_CPU 16000000UL

const int SCK_pin = 6;
const int dout_pin = 7;
//const int din_pin = 21; // Arduino Mega2560 original value 21 Mega2560 can also use 2 
const int din_pin = 2; //Use with Arduino Nano
//Note: din_pin must have external interrupt feature!

const int hitagerVersion = 2;


#define START_TIMER TCCR1B |= (1 << CS10)
#define STOP_TIMER TCCR1B &= (0 << CS10)

byte sampcont=0x17;

int isrtimes[400];
int *isrtimes_ptr = isrtimes;
volatile int bitsCnt=0;
volatile int isrCnt=0;
volatile int capturedone=0;
unsigned long starttime=0;
int rfoffset = 2;
int gain = 1;
int debug = 0;
int decodemode = 0;
int delay_1 = 20;
int delay_0 = 14;
int delay_p = 5;
int hysteresis =1;
//volatile unsigned long vvdiDelay = 7768;
volatile unsigned long vvdiDelay = 6982;

void setup()
{
  TIMSK0=0;
  pinMode(SCK_pin, OUTPUT);
  pinMode(dout_pin, OUTPUT);
  pinMode(din_pin, INPUT);
  digitalWrite(SCK_pin, HIGH);
  digitalWrite(dout_pin, HIGH);
  digitalWrite(din_pin, HIGH); 
  Serial.begin(115200); 
  Serial.println("Init done");


  writePCF7991Reg(0x40,8);//wake up
  writePCF7991Reg(0x50,8);//rf on
  byte readval = 0;
  for(int i = 2;i<9;i++)
  {
    readval = readPCF7991Reg(i);
    printRegister(i,readval);
  }

  Serial.println("set sampling time\n");
  int samplingT = (1<<7)|(0x3f&sampcont);
  readval = readPCF7991Reg(samplingT);
  printRegister(samplingT,readval);

  Serial.println("done registers\n");

}
void loop()
{
  while (Serial.available() < 1)
  {
    _delay_ms(1);
  }
  byte command = Serial.read();
  switch(command)
  {
    case 'a':
    {
      Serial.print("adapt offset\n");
      
      rfoffset = serialToByte();
      Serial.print("RESP:\n");
      Serial.print(rfoffset,HEX);
      Serial.print("\nEOF\n");
      
      break;
    }
    
    case 'b':
    {
      Serial.print("decoding mode\n");
      
      decodemode = serialToByte();
      Serial.print("RESP:\n");
      Serial.print(decodemode,HEX);
      Serial.print("\nEOF\n");
      
      break;
    }

    case 'c':
    {
      Serial.print("Pulse width delay adjust\n");
      
      delay_p = serialToByte() & 0xff;
      Serial.print("RESP:\n");
      Serial.print(delay_p,HEX);
      Serial.print("\nEOF\n");
      
      break;
    }
    
    case 'd':
    {
      Serial.print("debug mode\n");
      
      debug = serialToByte();
      Serial.print("RESP:\n");
      Serial.print(debug,HEX);
      Serial.print("\nEOF\n");
      
      break;
    }

    case 'f':
    {
      writePCF7991Reg(0x51,8);//rf off
      Serial.print("RFOFF\n");
      break;
    }
    
    case 'g':
    {
      Serial.print("Gain adjust\n");
      
      gain = serialToByte() & 0x3;
      Serial.print("RESP:\n");
      Serial.print(gain,HEX);
      Serial.print("\nEOF\n");
      
      break;
    }
    case 'h':
    {
      Serial.print("Hysteresis\n");
      
      hysteresis = serialToByte() & 0x1;
      Serial.print("RESP:\n");
      Serial.print(hysteresis,HEX);
      Serial.print("\nEOF\n");
      
      break;
    }
    
    case 'i':
    {
      Serial.print("transfer\n");
      
      byte cmdlength = serialToByte();
      
      //adapt();
      byte  authcmd[300] = {0};
  
      if(cmdlength > 1 && cmdlength < 200)
      for(int i = 0; i<(cmdlength+7)/8;i++)
      {
        authcmd[i] = serialToByte();
      }

      communicateTag(authcmd, cmdlength );
      Serial.print("EOF\n");
      break;
    }
    
    case 'o':
    {
      writePCF7991Reg(0x40 | (gain<<2) | 0x02, 8);
      writePCF7991Reg(0x50 | (hysteresis &0x1) <<1,8);//rf on
      adapt(rfoffset);
      Serial.print("RFON\n");
      break;
    }
    
    case 'q':
    {
      Serial.print("Super chip init\n");
      writePCF7991Reg(0x50 | (hysteresis &0x1) <<1,8);//rf on
      _delay_us(350);
      _delay_us(2500);  
      superInit(); 
      break;
    }

    case 'r':
    {
      byte cmdlength = serialToByte();
      byte  cmd[300] = {0};
  
      if(cmdlength > 1 && cmdlength < 200)
      for(int i = 0; i<(cmdlength*2+3);i++)
      {
        cmd[i] = serialToByte();
      }
      writePCF7991Reg(0x51,8);//rf off
      _delay_us(1000);
      writePCF7991Reg(0x50 | (hysteresis &0x1) <<1,8);//rf on
      _delay_us(350);
        
      digitalWrite(SCK_pin, LOW);
      writePCF7991Reg(0xe0,3);
           
      unsigned int startDelay = cmd[0];
      startDelay<<=8;
      startDelay |= cmd[1];
      
      for(unsigned int d = 0; d<startDelay;d++)
      {
          _delay_us(100);    
      }
      digitalWrite(SCK_pin, HIGH); 
      _delay_us(70);
      digitalWrite(SCK_pin, LOW);
      writePCF7991Reg(0x10,8);

      for(int i = 0; i<(cmdlength);i++)
      {
          digitalWrite(dout_pin, HIGH);
          for(int d = 0; d<cmd[i*2 +2];d++)
          {
              _delay_us(9);    
          }
          digitalWrite(dout_pin, LOW);
          for(int d = 0; d<cmd[i*2+3];d++)
          {
              _delay_us(9);    
          }
      }
      
      digitalWrite(dout_pin, HIGH);
      for(int d = 0; d<cmd[cmdlength*2+2];d++)
      {
          _delay_us(9);    
      }
      digitalWrite(dout_pin, LOW);
      _delay_us(3000);
      
      readTagResp();
      processManchester();
      
      Serial.print("\nEOF\n");
    }
    
    case 't':
    {
      tester();
      Serial.print("\nEOF\n");
      break;
    }
    
    case 'v':
    {
      Serial.print("Hitager version:");
      Serial.print(hitagerVersion,HEX);
      Serial.print("\nEOF\n");
      break;
    }

    case 'w':
    {
      Serial.print("Set VVDI delay");
      byte  delays[3] = {0};
      
      for(int i = 1; i>=0;i--)
      {
        delays[i] = serialToByte();
      }
      int mydelay= ((int *)delays)[0];
      Serial.print(mydelay);
      Serial.print("\n");

      vvdiDelay+=mydelay;
      Serial.print(vvdiDelay);
      Serial.print("\nEOF\n");
      break;
    }

    case 'x':
    {
      Serial.print("Pulse 1 delay adjust\n");
      
      delay_1 = serialToByte() & 0xff;
      Serial.print("RESP:\n");
      Serial.print(delay_1,HEX);
      Serial.print("\nEOF\n");
      
      break;
    }
    
    case 'z':
    {
      Serial.print("Pulse 0 delay adjust\n");
      
      delay_0 = serialToByte() & 0xff;
      Serial.print("RESP:\n");
      Serial.print(delay_0,HEX);
      Serial.print("\nEOF\n");
      
      break;
    }
    
  }
  while (Serial.available() > 0)
  {
    byte dummyread = Serial.read();
  }
}

void superInit()
{
  byte  authcmd[] = {0x58 ,0x48 ,0x4F ,0x52 ,0x53 ,0x45};
  byte  authcmd2[] = {0x07, 0x2F};
  byte  authcmd3[] = {0x73, 0x72};
  unsigned long adjust = 0;
  
  writeToTag(authcmd, 0x30 );
  writePCF7991Reg(0xe0,3);
  _delay_us(20000);
  digitalWrite(SCK_pin, HIGH); 
  writeToTag(authcmd2, 0x10 );
  writePCF7991Reg(0xe0,3);
  
  for(unsigned long d = 0; d < vvdiDelay; d++)
    _delay_us(2);
  
  digitalWrite(SCK_pin, HIGH); 
  communicateTag(authcmd3, 0x10 );
  Serial.print("\nEOF\n");    
}

byte serialToByte()
{
  byte retval = 0;

  while (Serial.available() < 2)
  {
    
  }

  for(int i = 0; i<2; i++)
  {
    retval<<=4;
    byte raw = Serial.read();
    if(raw >= '0' && raw <= '9')
      retval |= raw-'0';
    else if(raw >= 'A' && raw <= 'F')
      retval |= raw-'A'+10;
    else if(raw >= 'a' && raw <= 'f')
      retval |= raw-'a'+10;
      
  }
  return retval;
}

void printRegister(byte addr, byte val)
{
  Serial.print("Read addr 0x");
  Serial.print(addr,HEX);
  Serial.print(" vslue 0x");
  Serial.print(val,HEX);
  Serial.println("");
}

void tester()
{
  isrCnt=0;
  START_TIMER;
  attachInterrupt(digitalPinToInterrupt(din_pin) , pin_ISR, CHANGE );

  byte target= readPCF7991Reg(0x08);
  
  
  STOP_TIMER;
  Serial.print("adapt target:");
  Serial.println(target,HEX);
  Serial.print("ISRcnt:");
  Serial.println(isrCnt,HEX);
}

byte readPCF7991Reg(byte addr)
{
  byte readval = 0;
  writePCF7991Reg(addr,8);
  _delay_us(500);
  readval = readPCF991Response();
  return readval;
}

void adapt(int offset)
{
  byte target= readPCF7991Reg(0x08);
  Serial.print("adapt target:");
  Serial.println(target,HEX);
  byte samplingT = (1<<7)|(0x3f&(2*target+offset));
  Serial.print("adapt samplingT:");
  Serial.println(samplingT,HEX);
  byte readval = readPCF7991Reg(samplingT);
  Serial.print("adapt readval:");
  Serial.println(readval,HEX);

}

byte readPCF991Response()  
{
  byte _receive = 0;
  
  for(int i=0; i<8; i++)  
  {

    digitalWrite(SCK_pin, HIGH);   
    _delay_us(50);
    bitWrite(_receive, 7-i, digitalRead(din_pin)); 
    digitalWrite(SCK_pin, LOW);   
    _delay_us(50);
  }
  
  return _receive;
}

void writeToTag(byte *data, int bits)
{
  int bytes =bits/8;
  int rembits = bits%8;
  int bytBits = 8;
  
  digitalWrite(SCK_pin, LOW);
  
  writePCF7991Reg(0x19,8);
  //writePCF7991Reg(0x10 | delay_p&0xf,8);
  digitalWrite(dout_pin, LOW);

  _delay_us(20);//20
  digitalWrite(dout_pin, HIGH);
  _delay_us(20);
  digitalWrite(dout_pin, LOW);

  for(int by=0; by<=bytes; by++) 
  {
    if(by==bytes)
      bytBits=rembits;
    else
      bytBits=8;
      
    for(int i=0; i<bytBits; i++) 
    {
      if( bitRead(data[by], 7-i))
      {
        //Serial.print("1");
        for(int i = 0;i<delay_1; i++)
          _delay_us(10);//180
        digitalWrite(dout_pin, HIGH);
        _delay_us(10);
        digitalWrite(dout_pin, LOW);

      }
      else
      {
        //Serial.print("0");
        for(int i = 0;i<delay_0; i++)
          _delay_us(10);//120
        digitalWrite(dout_pin, HIGH);
        _delay_us(10);
        digitalWrite(dout_pin, LOW);

      }
  
    }
  }
  
  //end of transmission
  if(decodemode == 0)
    _delay_us(1200);
  else
    _delay_us(400); //Why biphase needs shorter delay???

}

void readTagResp()
{
  writePCF7991Reg(0xe0,3);
  isrCnt=0;
  capturedone=0;
  bitsCnt=0;
  //byte timski = TIMSK0;
  //TIMSK0=0;
  TCCR1B =2;
  EIFR = (1<<PCIF0);            // Clear EINT0-flag
  START_TIMER;
  attachInterrupt(digitalPinToInterrupt(din_pin) , pin_ISR, CHANGE );

  for(volatile int i = 0;i<100;i++)
    for(volatile int k = 0;k<200;k++);

  //last pulse
  if(isrCnt<400 && isrCnt>3)
  {
    isrtimes_ptr[isrCnt-1]=isrtimes_ptr[isrCnt-2]+201;
    isrCnt++;
  }
  digitalWrite(SCK_pin, HIGH); 
  STOP_TIMER;
  //TIMSK0 = timski;
  detachInterrupt(digitalPinToInterrupt(din_pin));

}

void communicateTag(byte  *tagcmd, unsigned int cmdLengt)
{
  isrtimes_ptr=isrtimes;
  //_delay_ms(10);
  writeToTag(tagcmd, cmdLengt);
  //_delay_us(4000);
  readTagResp();

  Serial.print("ISRcnt:");
  Serial.println(isrCnt,HEX);

  if(debug)
  {
    char hash[5];
    for(int s=0; s<isrCnt; s++) 
    {
      Serial.print(isrtimes[s]);
      Serial.print(", ");
    }
    Serial.print("\n");
  }

  if(decodemode == 0)
    processManchester();
  else
    processcdp();
}



void writePCF7991Reg(byte _send, int bits)  
{

  pinMode(dout_pin, OUTPUT);
  digitalWrite(dout_pin, LOW);
  digitalWrite(SCK_pin, HIGH); 
  _delay_us(50);
  digitalWrite(dout_pin, HIGH);
  _delay_us(50);   
  digitalWrite(SCK_pin, LOW);   
  
  for(int i=0; i<bits; i++) 
  {
    digitalWrite(dout_pin, bitRead(_send, 7-i));   
    _delay_us(50);
    digitalWrite(SCK_pin, HIGH);                  
    _delay_us(50);
    
    digitalWrite(SCK_pin, LOW);                 
    _delay_us(50);
  }
  
}

void pin_ISR()
{
  unsigned int travelTime = TCNT1; 
  TCNT1=0;

  if(isrCnt>0)
  {
    if(digitalRead(din_pin))
      travelTime&= ~1;
    else
      travelTime|= 1;
  }
  else
  {
    isrCnt++;
    return;
  }
  isrtimes_ptr[isrCnt-1]=travelTime;
  if(isrCnt<400)
    isrCnt++;
    
}

void processManchester() 
{
  int bitcount =0;
  int bytecount =0;
  int mybytes [10] = {0};
  int lead=0;
  int errorCnt=0;
  int state = 1;
  int start = 0;
  for(start = 0; start<10; start++)
  {
    if(isrtimes_ptr[start]<45)
      break;
  }
  start+=3;
  if(((isrtimes_ptr[start])&1)==0) 
   start++;

  for(int i = start; i<isrCnt; i++)
  {
    int travelTime = isrtimes_ptr[i];
    if(((travelTime&1)==1))//high
    {
        if(travelTime>45)
        {
          //travelTime =11;
          if(state)
          {
            state = 1;
            if(lead<4)
            {
              lead++;
              //Serial.print("X");
            }
            else
            {
              mybytes[bytecount] |= (1<<(7-bitcount++));
              //Serial.print("1");
            }
          }
          else
          {
            Serial.print("X");
            if(bytecount<1)
              errorCnt++;
          }
        }
        else
        {
          //travelTime =1;
          if(state)
          {
            state = 0;
            if(lead<4)
              lead++;
            else
            {
              mybytes[bytecount] |= (1<<(7-bitcount++));
              //Serial.print("1");
            }
          }
          else
          {
            state++;
          }
        }
      }
      else
      {
        if(travelTime>45)
        {
          if(state)
          {
            state = 1;
            bitcount++;
            //Serial.print("0");
          }
          else
          {
            Serial.print("X");
            if(bytecount<1)
              errorCnt++;
          }
        }
        else
        {
          if(state)
          {
            state = 0;
            bitcount++;
            //Serial.print("0");
          }
          else
          {
            state++;
          }
        }
      }
      if(bitcount>7)
      {
        
        bitcount = 0;
        bytecount++;
      }
      if(travelTime>80)
      {
        if(bitcount>0)
          bytecount++;
        break;
      }
 }
  
  char hash[20];
  Serial.print("\nRESP:");
  if(errorCnt || bytecount==0 )
    Serial.print("NORESP\n");
  else
    for(int s=0; s<bytecount && s<20; s++) 
    {
      sprintf(hash,"%02X", mybytes[s]);
      Serial.print(hash);
    
    }
  Serial.print("\n");      

}

void processcdp() 
{
  int bitcount =0;
  int bytecount =0;
  int mybytes [10] = {0};
  int lead=0;
  int errorCnt=0;
  int state = 1;
  int start = 0;
  /*
  for(start = 0; start<10; start++)
  {
    if(isrtimes_ptr[start]<45)
      break;
  }*/
  start+=6;
  if(((isrtimes_ptr[start])&1)==0) 
   start++;

  for(int i = start; i<isrCnt; i++)
  {
    int travelTime = isrtimes_ptr[i];
    if(travelTime>45)
    //if(travelTime>80)
    {
      mybytes[bytecount] |= (1<<(7-bitcount++));
      //Serial.print("1");
    }
    else 
    {
      bitcount++;
      //Serial.print("0");
      i++;
    }      
    if(bitcount>7)
    {   
      bitcount = 0;
      bytecount++;
    }
    if(travelTime>200)
    {
      if(bitcount>0)
        bytecount++;
      break;
    }
 }
  
  char hash[20];
  Serial.print("\nRESP:");
  if(errorCnt || bytecount==0 )
    Serial.print("NORESP\n");
  else
    for(int s=0; s<bytecount && s<20; s++) 
    {
      sprintf(hash,"%02X", mybytes[s]);
      Serial.print(hash);
    
    }
  Serial.print("\n");      

}
