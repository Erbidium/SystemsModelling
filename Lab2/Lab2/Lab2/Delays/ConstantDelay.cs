﻿namespace Lab2.Delays;

public class ConstantDelay : IDelay
{
    private readonly double _delay;

    public ConstantDelay(double delay)
        => _delay = delay;

    public double Generate()
        => _delay;
}