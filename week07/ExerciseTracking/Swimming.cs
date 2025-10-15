class Swimming : Activity
{
    private int _laps; // number of 50m laps

    public Swimming(string date, int minutes, int laps)
        : base(date, minutes)
    {
        _laps = laps;
    }

    public override double GetDistance()
    {
        // laps * 50 meters => convert to kilometers
        return (_laps * 50) / 1000.0;
    }

    public override double GetSpeed()
    {
        return (GetDistance() / GetMinutes()) * 60.0;
    }

    public override double GetPace()
    {
        return GetMinutes() / GetDistance();
    }
}
