using System.Linq;

public static class StringExtensions
{
    public static bool IsContainWhiteSpace(this string text)
    {
        return text.Contains(WHITE_SPACE);
    }

    private const char WHITE_SPACE = ' ';
}