public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points)
    {
    }

    public override void RecordEvent()
    {
        // No completion, just gains points
    }

    public override bool IsComplete()
    {
        return false;
    }

    public override string GetDetailsString()
    {
        return "[∞] " + _shortName;
    }

    public override string GetStringRepresentation()
    {
        return $"EternalGoal|{_shortName}|{_description}|{_points}";
    }
}
