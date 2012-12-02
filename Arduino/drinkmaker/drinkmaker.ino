int dispenseCount = 3;
int dispensePins[] = {12,11,10};
int dispenseRemaining[] = {0, 0, 0};
int dispenseOpen[] = {0, 0, 0};

unsigned long dispenseUnitTime = 100;

// the setup routine runs once when you press reset:
void setup() {
    Serial.begin(9600);
    
    for(int i = 0; i < dispenseCount; i++)
    {
        pinMode(dispensePins[i], OUTPUT);
        digitalWrite(dispensePins[i], LOW);
    }
}


void loop() {

    if (Serial.available() >= 3)
    {
        int byteA = Serial.read();
        int byteB = Serial.read();
        int byteC = Serial.read();
     
        int d = 0;
        switch(byteA)
        {
        case('d'): //dispense
            if(byteB >= 0 && byteB < dispenseCount && byteC >= 0)
                dispenseRemaining[byteB] += (byteC);
                break;
        case('u'):
            dispenseUnitTime = (byteB << 8) | byteC;
                break;
        case('o'):
            if(byteB >= 0 && byteB < dispenseCount)
                dispenseOpen[byteB] = 1;
            break;
        case('c'):
            if(byteB >= 0 && byteB < dispenseCount)
                dispenseOpen[byteB] = 0;
                break;
        case('r'):
            for(int i = 0; i < dispenseCount; i++)
            {
                dispenseOpen[i] = 0;
                dispenseRemaining[i] = 0; 
            }
            break;
        }
    }
    dispenseCheck();
}

unsigned long lastDispenseUnitTime = 0;
void dispenseCheck()
{
    for(int i = 0; i < dispenseCount; i++)
    {
        if(dispenseOpen[i] || dispenseRemaining[i] > 0)
            digitalWrite(dispensePins[i], HIGH);
        else
            digitalWrite(dispensePins[i], LOW);  
    }
  
    unsigned long now = millis();
  
    if (now - lastDispenseUnitTime > dispenseUnitTime)
    {
        lastDispenseUnitTime = now;
        for(int i = 0; i < dispenseCount; i++)
        {
            if(dispenseRemaining[i] > 0)
            {
                dispenseRemaining[i] = dispenseRemaining[i] - 1;
            }
        } 
    }
}
