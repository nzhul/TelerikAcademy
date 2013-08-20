// 07. Write a program that encodes and decodes a string using given encryption key 
//     (cipher). The key consists of a sequence of characters. The encoding/decoding 
//     is done by performing XOR (exclusive or) operation over the first letter of the 
//     string with the first of the key, the second – with the second, etc. When the last 
//     key character is reached, the next is the first.


using System;
using System.Text;

class EncodeDecode
{
    static void Main()
    {
        string text = "Some text for decrypting!";
        string key = "gosho";

        Console.WriteLine("Encrypted text: ");
        Console.WriteLine(EncryptOrDecrypt(text,key));
        Console.WriteLine();
        Console.WriteLine("Decrypted text: ");
        Console.WriteLine(EncryptOrDecrypt(EncryptOrDecrypt(text, key), key));
    }
    static string EncryptOrDecrypt(string text, string key)
    {
        StringBuilder result = new StringBuilder();
        for (int i = 0; i < text.Length; i++)
        {
            // get the next character from the string
            char character = text[i];

            // cast to int
            int charCode = (int)character;

            // find out which character to take from the key
            int keyPosition = i % key.Length;

            // take the key character
            char keyChar = key[keyPosition];

            // cast it to int also
            int keyCode = (int)keyChar;

            // perform XOR on the two character codes
            int combinedCode = charCode ^ keyCode;

            // cast back to char
            char combinedChar = (char)combinedCode;

            // add to the result
            result.Append(combinedChar);
        }
        return result.ToString();
    }
}