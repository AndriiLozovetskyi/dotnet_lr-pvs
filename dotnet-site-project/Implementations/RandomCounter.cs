using dotnet_site_project.Interfaces;

namespace dotnet_site_project.Implementations;

using System;

public class RandomCounter : ICounter
{
    static Random Rnd = new Random();
    private int _value;

    public RandomCounter()
    {
        _value = Rnd.Next(0, 1000000);
    }

    public int Value
    {
        get { return _value; }
    }
}