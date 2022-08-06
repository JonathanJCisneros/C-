#pragma warning disable CS8618
namespace RandomPasscode.Models;

public class Passcode
{
    public string PassCode {get; set;}

    public string GenerateString()
    {
        string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        Random rand = new Random();
        char[] chars = new char[14];
        for (int i=0; i < chars.Length; i++)
        {
            chars[i] = Alphabet[rand.Next(Alphabet.Length)];
        }
        PassCode = new string(chars);
        return PassCode;
    }
}


