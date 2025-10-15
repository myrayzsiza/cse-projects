class Cycling : Activity
{
    private double _speed; // in kph

    public Cycling(string date, int minutes, double speed)
        : base(date, minutes)
    {
        _speed = speed;
    }

    public override double GetDistance()
    {
        // distance = speed * time(hours)
        return (_speed * GetMinutes()) / 60.0;
    }

    public override double GetSpeed()
    {
        return _speed;
    }

    public override double GetPace()
    {
        // pace = 60 / speed => min per km
        return 60.0 / _speed;
    }
}
