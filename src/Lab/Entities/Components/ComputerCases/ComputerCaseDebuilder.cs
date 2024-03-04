using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.ComputerCases;

public class ComputerCaseDebuilder
{
    private List<FormFactors>? _formFactors;
    private Millimeters? _maxLength;
    private Millimeters? _maxHeight;
    private Watt? _power;

    public ComputerCaseDebuilder(ComputerCase computerCase)
    {
        if (computerCase is null)
            throw new ArgumentNullException(nameof(computerCase));

        _formFactors = new List<FormFactors>(computerCase.FormFactors);
        _maxLength = computerCase.MaxLength;
        _maxHeight = computerCase.MaxHeight;
        _power = computerCase.Power;
    }

    public ComputerCaseDebuilder AnotherFormFactor(FormFactors formFactor)
    {
        _formFactors?.Add(formFactor);
        return this;
    }

    public ComputerCaseDebuilder AnotherMaxLength(Millimeters length)
    {
        _maxLength = length;
        return this;
    }

    public ComputerCaseDebuilder AnotherMaxHeight(Millimeters height)
    {
        _maxHeight = height;
        return this;
    }

    public ComputerCaseDebuilder AnotherPower(Watt power)
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