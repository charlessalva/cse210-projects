public class Swimming : Activity
{
    private int _laps;
    private const double LapLength = 50; // meters

    public Swimming(DateTime date, int minutes, int laps) : base(date, minutes)
    {
        _laps = laps;
    }

    public override double GetDistance()
    {
        return (_laps * LapLength) / 1000; // Convert meters to km
    }
    
    public override double GetSpeed()
    {
        return (GetDistance() / GetMinutes()) * 60;
    }
    
    public override double GetPace()
    {
        return GetMinutes() / GetDistance();
    }
}