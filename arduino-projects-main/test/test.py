import serial



# Replace with your Arduino port

arduino_port = "/dev/ttyUSB0"



# Open serial connection

ser = serial.Serial(arduino_port, 9600, timeout=1)



# Send data to Arduino

def send_data(data):

    ser.write(data.encode())



# Read data from Arduino

def read_data():

    data = ser.readline().decode('utf-8').rstrip()

    return data 



# Example usage

send_data("Hello Arduino!")

received_data = read_data()

print(f"Received from Arduino: {received_data}") 



ser.close() 

