
using System.Text;

public class PasswordGeneratorService
{
    private readonly Random random;
    private readonly int pwdLength;
    private readonly string pwdCharactersSet;

    public PasswordGeneratorService(int pwdLength, CharacterSetMask characterSets)
    {
        this.random = new Random();
        this.pwdLength = pwdLength;
        this.pwdCharactersSet = CalcPwdCharacterSet(characterSets);
    }

    public string[] GeneratePasswords(int qty)
    {
        var result = new List<string>();
        for (int i = 0; i < qty; i++)
        {
            string password = new string(Enumerable.Repeat(pwdCharactersSet, pwdLength).Select(s => s[random.Next(s.Length)]).ToArray());
            result.Add(password);
        }
        return result.ToArray();
    }

    private static string CalcPwdCharacterSet(CharacterSetMask characterSets)
    {
        var builder = new StringBuilder();
        if ((characterSets & CharacterSetMask.Capital) == CharacterSetMask.Capital) builder.Append("ABCDEFGHIJKLMNOPQRSTUVWXYZ");
        if ((characterSets & CharacterSetMask.Lowercase) == CharacterSetMask.Lowercase) builder.Append("abcdefghijklmnopqrstuvwxyz");
        if ((characterSets & CharacterSetMask.Digits) == CharacterSetMask.Digits) builder.Append("0123456789");
        if ((characterSets & CharacterSetMask.Symbols) == CharacterSetMask.Symbols) builder.Append("!@#$%^&*_()");
        var result = builder.ToString();
        if ((characterSets & CharacterSetMask.ExcludeAmbiguous) == CharacterSetMask.ExcludeAmbiguous)
        {
            var ambiguous = "IOl";
            foreach (char ambiguousChar in ambiguous)
            {
                result = result.Replace(ambiguousChar.ToString(), "");
            }
        }

        return result;
    }
}