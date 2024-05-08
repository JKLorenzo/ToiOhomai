internal class Program
{
    static void Main(string[] args)
    {
        String[] phrases = {
                "Automatic Teller Machine",
                "Laugh Out Loud",
                "On My Way",
                "Got To Go",
            };

        Acronym acronym;
        foreach (String phrase in phrases)
        {
            acronym = new Acronym(phrase);
            acronym.BuildAcronym();
            acronym.DisplayAcronym();
        }

        Console.ReadLine();
    }
}

class Acronym
{
    private string fullSentence;
    private string[] words;
    private Dictionary<char, string> acronymDictionary;

    public Acronym(string sentence)
    {
        this.fullSentence = sentence;
        this.acronymDictionary = new Dictionary<char, string>();
    }

    public void BuildAcronym()
    {
        this.words = this.fullSentence.Split(' ');
        foreach (string word in words)
        {
            // Get first letter
            char firstLetter = word.ToUpper()[0];
            if (this.acronymDictionary.ContainsKey(firstLetter))
            {
                // Convert to lowercase if repetition
                firstLetter = word.ToLower()[0];
            }

            acronymDictionary.Add(firstLetter, word);
        }
    }

    public void DisplayAcronym()
    {
        string acronym = String.Join("", acronymDictionary.Keys);
        string phrase = String.Join(" ", acronymDictionary.Values);

        Console.WriteLine($"{acronym} is an acronym for the Phrase {phrase}.");
    }
}