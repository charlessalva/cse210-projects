public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        
        // Split the text into words and create Word objects
        string[] wordArray = text.Split(' ');
        foreach (string wordText in wordArray)
        {
            _words.Add(new Word(wordText));
        }
    }

    public void HideRandomWords(int numberToHide)
    {
        Random rand = new Random();
        int hiddenCount = 0;

        // Get the number of words that are not hidden
        int wordsLeftToHide = _words.Count(w => !w.IsHidden());
        
        // If there are fewer than 'numberToHide' words left, only hide those that are left
        int wordsToHide = Math.Min(numberToHide, wordsLeftToHide);

        while (hiddenCount < wordsToHide)
        {
            int index = rand.Next(0, _words.Count);
            // EXCEEDING REQUIREMENTS
            // Only hide the word if it is not already hidden
            if (!_words[index].IsHidden())
            {
                _words[index].Hide();
                hiddenCount++;
            }
        }
    }

    public string GetDisplayText()
    {
        string result = _reference.GetDisplayText() + "\n";

        foreach (Word word in _words)
        {
            result += word.GetDisplayText() + " ";
        }

        return result;
    }

    public bool isFullyHidden()
    {
        // Check if all words are hidden
        return _words.All(w => w.IsHidden());
    }
}