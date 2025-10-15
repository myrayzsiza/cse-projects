class Running : Activity
{
    private double _distance; // in kilometers

    public Running(string date, int minutes, double distance)
        : base(date, minutes)
    {
        _distance = distance;
    }

    public override double GetDistance()
    {
        return _distance;
    }

    public override double GetSpeed()
    {
        // speed = (distance / minutes) * 60 => km per hour
        return (GetDistance() / GetMinutes()) * 60.0;
    }

    public override double GetPace()
    {
        // pace = minutes / distance => min per km
        return GetMinutes() / GetDistance();
    }
}
