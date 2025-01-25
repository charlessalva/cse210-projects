public class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text.Trim(); // Remove any leading/trailing spaces
        _isHidden = false;
    }

    public void Hide()
    {
        _isHidden = true;
    }

    public void Show()
    {
        _isHidden = false;
    }

    public bool IsHidden()
    {
        return _isHidden;
    }

    public string GetDisplayText()
    {
        if (_isHidden)
        {
            return new string('_', _text.Length); // Return underscores
        }
        return _text;
    }
}
