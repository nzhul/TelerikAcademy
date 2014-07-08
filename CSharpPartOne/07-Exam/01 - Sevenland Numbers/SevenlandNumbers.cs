using System;

    class SevenlandNumbers
    {
        static void Main()
        {
            int k = Int32.Parse(Console.ReadLine());
            byte powerCounter = 0;
            int decimalNumber = 0;

            // Convert from SevenLand System to Decimal 
            while (k != 0)
            {
                byte lastNumber = (byte)(k % 10);
                decimalNumber += lastNumber * (int)Math.Pow(7, powerCounter);
                powerCounter++;
                k /= 10;
            }

            // Increment the newly converted decimal number with 1
            decimalNumber++;
            string result = "";
            
            // Convert the incremented decimal number back to SevenLand System
            while (decimalNumber != 0)
            {
                byte lastNumber = (byte)(decimalNumber % 7);
                result = lastNumber + result;
                decimalNumber /= 7;
            }
            Console.WriteLine(result);
        }
    }
