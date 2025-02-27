using System;
using System.Text;

public class Encryption
{
    public string Encrypt(string input, int shift)
    {
        StringBuilder result = new StringBuilder();

        foreach (char letter in input)
        {
            if (char.IsLetter(letter))
            {
                char baseChar = char.IsUpper(letter) ? 'A' : 'a';
                result.Append((char)((letter - baseChar + shift + 26) % 26 + baseChar));
            }
            else if (char.IsDigit(letter))
            {
                result.Append((char)((letter - '0' + shift + 10) % 10 + '0'));
            }
            else
            {
                result.Append(letter); // Behåll specialtecken oförändrade
            }
        }

        return result.ToString();
    }

    public string Decrypt(string input, int shift)
    {
        return Encrypt(input, -shift);
    }
}
