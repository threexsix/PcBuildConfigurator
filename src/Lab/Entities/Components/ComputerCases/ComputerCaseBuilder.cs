using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.ComputerCases;

public class ComputerCaseBuilder
{
    private readonly List<FormFactors>? _formFactors = new List<FormFactors>();
    private Millimeters? _maxLength;
    private Millimeters? _maxHeight;
    private Watt? _power;

    public ComputerCaseBuilder AddFormFactor(FormFactors formFactor)
    {
        _formFactors?.Add(formFactor);
        return this;
    }

    public ComputerCaseBuilder SetMaxLength(Millimeters length)
    {
        _maxLength = length;
        return this;
    }

    public ComputerCaseBuilder SetMaxHeight(Millimeters height)
    {
        _maxHeight = height;
        return this;
    }

    public ComputerCaseBuilder SetPower(Watt power)
    {
        _power = power;
        return this;
    }

    public ComputerCase Build()
    {
        if (_formFactors is null || _maxLength is null || _maxHeight is null || _power is null)
            throw new ArgumentNullException();
        return new ComputerCase(_formFactors, _maxLength, _maxHeight, _power);
    }
}