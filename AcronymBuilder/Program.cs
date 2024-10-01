internal class Program
{
    static void Main(string[] args)
    {
        // First we will declare our Acronym variable.
        Acronym acronym;

        // We then instantiate it and provide the phrase that we need to make the acronym
        acronym = new Acronym("Laugh Out Loud");
        // We then call the BuildAcronym function of the Acronym class. This will generate the corresponding acronym for the phrase above.
        acronym.BuildAcronym();
        // Then we will call the DisplayAcronym function of the Acronym class. This will display the acronym that we 'built'.
        acronym.DisplayAcronym();


        // We will repeat this process for other phrases:

        acronym = new Acronym("Automatic Teller Machine");
        acronym.BuildAcronym();
        acronym.DisplayAcronym();

        acronym = new Acronym("On My Way");
        acronym.BuildAcronym();
        acronym.DisplayAcronym();

        acronym = new Acronym("Got To Go");
        acronym.BuildAcronym();
        acronym.DisplayAcronym();

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
        words = [];
        acronymDictionary = new Dictionary<char, string>();
        fullSentence = sentence;
    }

    public void BuildAcronym()
    {
        // Separate each words by space
        // The fullSentence contains the phrase as a whole.
        // Example, Laugh Out Loud
        // To build its corresponding acronym, we need to extract each word from this phrase.
        // We do that by calling the Split function and supplying it a space ' ' as the splitter in its function parameter.
        // This means that we would like to divide this string into multiple strings and we separate it if there is space.
        // For this case, Laugh Out Loud will become ["Laugh","Out","Loud"]. An array of strings.
        words = fullSentence.Split(' ');

        // We will then iterate through each words we have extracted and we will process each accordingly
        foreach (string word in words)
        {
            // Captialize this word and get the first character
            // If for example the word is laugh,
            // word.ToUpper() will return the string as LAUGH (capitalized all characters)
            // [0] in the word.ToUpper()[0] means that we will only get the first character of this word.
            // For this case, it will be L for laugh, O for out, and L for loud (since we iterate through each word)
            // Since [0] will only return a single character from the string, we declare the firstLetter variable as of type char = character.
            char firstLetter = word.ToUpper()[0];

            // Check if the firstLetter already exists in the dictionary
            // This way, we will know if we need to convert it to lowercase if this letter is already added in the acronymDictionary.
            if (acronymDictionary.ContainsKey(firstLetter))
            {
                // Convert to lowercase and get the first character in the case of repetition
                // In the case of Laugh Out Loud - LOL, it would be LOl.
                // Since the L is already existing in the dictionary for the word Laugh, the second L will be lowercased for the word Loud.
                // Key  Value
                // L    Laugh
                // O    Out
                // l    Loud
                firstLetter = word.ToLower()[0];
            }

            // Add this to dictionary. The key is the firstLetter and the value is the word.
            // Example, if the word is Laugh Out Loud.
            // For the first word - Laugh,
            // L is the firstLetter (the key in the acronymDictionary)
            // And the word Laugh is the word (the value of this key in the acronymDictionary).
            // L = Laugh
            // O = Out
            // l = Loud
            acronymDictionary.Add(firstLetter, word);
        }
    }

    public void DisplayAcronym()
    {
        // Iterate the dictionary
        foreach (var keyValuePair in acronymDictionary)
        {
            // Show each character and its corresponding equivalent word.
            // Key is the firstLetter in the BuildAcronym function, and Value is the word.
            Console.WriteLine($"{keyValuePair.Key} is {keyValuePair.Value}.");
        }

        // To only get the firstLetters in the dictionary, we will call the Keys getter of the Dictionary.
        // For Laugh Out Loud, the keys are be ['L','O','l'] and the Values are ["Laugh","Out","Loud"].
        // Notice the " and ', enclosed in " means its a string, meanwhile ' indicates a char.
        // For the Keys, we would like to combine it without space.
        // For the Values, we would like to combine it with space.
        string acronym = String.Join("", acronymDictionary.Keys);
        string phrase = String.Join(" ", acronymDictionary.Values);
        Console.WriteLine($"{acronym} is {phrase}.");
    }
}