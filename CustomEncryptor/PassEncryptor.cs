using System.Security.Cryptography;
using System.Text;

namespace CustomEncryptor;

public static class PassEncryptor
{
    private static char[] fullArray = new[] { '0','1','2','3','4','5','6','7','8','9',
        'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O',
        'P','Q','R','S','T','U','V','W','X','Y','Z','a','b','c','d',
        'e','f','g','h','i','j','k','l','m','n','o','p','q',
        'r','s','t','u','v','w','x','y','z','+', '-', '&', '|',
        '!', '(', ')', '{', '}', '[', ']', '^', '~', '*', '?', ':'};
    public static string NextLetterEnc(string password, int nextCount)
    {
        StringBuilder sb = new();
        for (int i = 0; i < password.Length; i++)
        {
            var ch = password[i];
            var b = (byte)ch;
            var newB = b + (nextCount + 5);
            ch = (char)newB;
            sb.Append(ch);
        }

        sb.Append($".{nextCount}");

        return sb.ToString();
    }

    public static string NextLetterDec(string encrypted)
    {
        var nextCount = encrypted.Contains(".") ? int.Parse(encrypted.Substring(encrypted.LastIndexOf(".") + 1)) : 1;
        StringBuilder sb = new();
        for (int i = 0; i < encrypted.Length; i++)
        {

            var ch = encrypted[i];
            if (ch == '.')
                break;
            var b = (byte)ch;
            var newB = b - nextCount - 5;
            ch = (char)newB;
            sb.Append(ch);
        }

        return sb.ToString();
    }

    public static string ByteBaseEnc(string password)
    {
        List<string> randomNumbers = new();
        StringBuilder sb = new();
        var i = 0;
        for (; i < password.Length; i++)
        {
            var rnd = new Random().Next(fullArray.Length);
            randomNumbers.Add(rnd.ToString().PadLeft(3, 'x'));

            var ch = password[i];
            var b = (byte)ch + rnd;
            var value = b.ToString().PadLeft(3, 'x');

            var rndChar = fullArray[rnd];

            sb.Append(value);
            sb.Append(rndChar);
        }

        sb.Append($".{string.Join("", randomNumbers)}");
        return sb.ToString();
    }

    public static string ByteBaseDec(string password)
    {
        var arr = password.Split('.', StringSplitOptions.RemoveEmptyEntries);
        var randomNumberArr = arr[^1];
        var randomNumbers = randomNumberArr.Chunk(3)
            .Select(x => new string(x).Replace("x", ""))
            .Select(int.Parse)
            .ToList();

        var sb = new StringBuilder();

        var passPart = arr.First();
        var byteArray = passPart.Chunk(4)
            .Select(x => new string(x))
            .Select(x => x.Substring(0, x.Length - 1).Replace("x",""))
            .Select(int.Parse)
            .ToList();
        var i = 0;
        for (; i < byteArray.Count; i++)
        {
            var randomNumber = randomNumbers[i];
            var ch = byteArray[i] - randomNumber;
            sb.Append((char)ch);
        }
        return sb.ToString();
    }

    public static string RandomByteBaseEnc(string password,string key)
    {
        var sb = new StringBuilder();
        var seed = key.ToCharArray().Select(x => (byte)x).Sum(x=>x);
        var r = new Random(seed);
        foreach (var ch in password)
        {
            var randomNumber = r.Next(fullArray.Length);
            var charValue = fullArray[randomNumber];
            sb.Append(charValue);
        }
        return sb.ToString();
    }

    public static string MD5_Enc(string text)
    {
        using MD5 md5 = MD5.Create();
        var passBytes = md5.ComputeHash(Encoding.UTF8.GetBytes(text));
        return BitConverter.ToString(passBytes).Replace("-","");
    }
    public static string SHA256_Enc(string text)
    {
        using SHA256 sha = SHA256.Create();
        var passBytes = sha.ComputeHash(Encoding.UTF8.GetBytes(text));
        return BitConverter.ToString(passBytes).Replace("-","");
    }
    public static string SHA512_Enc(string text)
    {
        using SHA512 sha = SHA512.Create();
        var passBytes = sha.ComputeHash(Encoding.UTF8.GetBytes(text));
        return BitConverter.ToString(passBytes).Replace("-","");
    }
}