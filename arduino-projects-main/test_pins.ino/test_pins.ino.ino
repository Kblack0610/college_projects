   const int ledPin = 13; // Define LED pin

    const int buzzerPin = 12; // Define buzzer pin



    void setup() {  

        pinMode(ledPin, OUTPUT); // Set LED pin as output

        pinMode(buzzerPin, OUTPUT); // Set buzzer pin as output

    }



    void loop() {

        digitalWrite(ledPin, HIGH); // Turn LED on

        tone(buzzerPin, 1000); // Play a 1kHz tone on buzzer

        delay(500); // Wait 0.5 seconds



        digitalWrite(ledPin, LOW); // Turn LED off

        noTone(buzzerPin); // Stop the tone

        delay(500); // Wait another 0.5 seconds

    }