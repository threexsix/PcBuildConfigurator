using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Services;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.CPUs;

public interface ICpu : IPowered, ICloneable<ICpu>
{
    public MHz CoreFrequency { get; }
    public Quantity CoreQuantity { get; }
    public CpuSocket Socket { get; }
    public Watt Tdp { get; }
    public CpuBase CpuBase { get; }
}