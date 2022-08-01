string[] words = new string[]{"computer", "bottle", "pencil", "phone","internet","cat","teemo"};
char[] guesses;
string[] fails;
string secretword;
bool won, lost;

Random random = new Random();
int index = random.Next(words.Length);
secretword = words[index];
guesses = new char[secretword.Length];
Array.Fill(guesses, '*');
fails = new string[0];
won = false;
lost = false;

Console.WriteLine("Bienvenido a ahorcado! \n\n");
gameCicle();



void gameCicle()
{
    Console.WriteLine($"La palabra secreta es {new String(guesses)}. ");

    printHangMan();
    if (lost)
    {
        Console.WriteLine("Perdiste :c");

    }
    else if (won)
    {
        Console.WriteLine("ganaste c:");
    }
    else
    {
        PlayerTurn();
        gameCicle();

    }

}
void PlayerTurn()
{
    Console.WriteLine("Ingrese una letra o adivine una palabra: ");
    string attempt = Console.ReadLine() ?? "";
    if (attempt.Length == 0)
    {
        Console.WriteLine("Intente denuevo");

    }
    else if (attempt.Length ==1)
    {
       lookForLetter(attempt[0]);
    }
    else
    {
        TryToGuess(attempt);
    }

}
void lookForLetter(char letter)
{
    Console.WriteLine("Buscando letra...");
    if (secretword.IndexOf(letter) > -1)
    {
        Console.WriteLine($"La letra ¨{letter} si esta ");
        for (int i = 0; i < secretword.Length; i++)
        {
            if (secretword[i] == letter)
            {
                guesses[i] = letter;
            }
        }
        won = (Array.IndexOf(guesses, '*') == -1);

    }
    else 
    {
        Console.WriteLine($"La letra {letter} no está");
        Array.Resize(ref fails, fails.Length +1);
        fails.SetValue(letter.ToString(), fails.Length -1);
    }
}

void TryToGuess(string word)
{
    if (secretword == word)
    {
      Console.WriteLine($"La palabra {word} si es  ");
      guesses = secretword.ToCharArray();
      won = true;

    }
    else
    {
        Console.WriteLine($"La palabra {word} no es ");
         Array.Resize(ref fails, fails.Length +1);
         fails.SetValue(word, fails.Length -1);
    }
}






void printHangMan()
{
    Console.WriteLine("Intentas fallidos: ");
    for (int i=0; i < fails.Length; i++)
    {
        Console.Write(fails[i] + ' ');
    }

    int f = fails.Length;
    Console.WriteLine();
    Console.WriteLine("|---");
    Console.WriteLine($"|    {(f > 0 ? 'o' : ' ')}");
    Console.WriteLine($"|   {(f > 2 ? '/' : ' ' )}{(f > 1 ? '|' : ' ')}{(f > 3 ? '\\'  : ' ')}");
    Console.WriteLine("|");
    Console.WriteLine("/---------------\\");
    if (f == 6)
    {
        lost = true;
    }
}