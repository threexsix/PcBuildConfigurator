using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Services;

public interface IPowered
{
    public Watt Power { get; }
}