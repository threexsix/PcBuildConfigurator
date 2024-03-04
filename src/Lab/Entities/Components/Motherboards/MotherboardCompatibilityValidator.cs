using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.ComputerCases;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Motherboards;

public class MotherboardCompatibilityValidator
{
    private readonly Motherboard _motherboard;

    public MotherboardCompatibilityValidator(Motherboard motherboard)
    {
        _motherboard = motherboard ?? throw new ArgumentNullException(nameof(motherboard));
    }

    public void ValidateMotherboardCompatibility(ComputerCase? computerCase)
    {
        if (computerCase is null)
            throw new PrerequisitesViolationException("case should be installed before motherboard");

        if (computerCase.FormFactors.All(x => !x.Equals(_motherboard.FormFactor)))
            throw new MismatchAssemblyException("Wrong form factor between case and motherboard");
    }
}