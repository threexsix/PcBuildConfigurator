using System;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.DRAMs;

public class Xmp
{
    public Xmp(MHz frequency)
    {
        Frequency = frequency ?? throw new ArgumentNullException(nameof(frequency));
    }

    public MHz Frequency { get; }
}