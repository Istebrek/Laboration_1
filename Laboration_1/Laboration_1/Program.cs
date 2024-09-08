Console.WriteLine("Enter a string");
string userString = Console.ReadLine();

string grayPreSubstring = "";
string redSubstring = "";
string grayRemainingSubstring = "";

long substringsSum = 0;

for (int i = 0; i < userString.Length; i++)
{
    char currentCharacter = userString[i];

    int temporarySum = 0;
    bool isDigit = int.TryParse(currentCharacter + "", out temporarySum);

    if (isDigit==false)
    {
        continue;
    }

    for (int j = i +1; j < userString.Length; j++)
    {
        char nextCharacters = userString[j];

        if (!char.IsDigit(nextCharacters))
        {
            break;
        }       
        if (currentCharacter == nextCharacters)
        {
            redSubstring = userString.Substring(i, j - i + 1);
            grayPreSubstring=userString.Substring(0, userString.IndexOf(redSubstring));            
            grayRemainingSubstring = userString.Substring(redSubstring.Length + grayPreSubstring.Length, (userString.Length) - (redSubstring.Length + grayPreSubstring.Length));

            long total;
            long.TryParse(redSubstring, out total);
            substringsSum += total;

            Console.Write(grayPreSubstring);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(redSubstring);
            Console.ResetColor();
            Console.WriteLine(grayRemainingSubstring);
            break;
        }
    }
}

Console.WriteLine();
Console.WriteLine($"Sum: {substringsSum}");