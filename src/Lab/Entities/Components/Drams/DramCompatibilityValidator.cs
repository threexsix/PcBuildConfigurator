using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Motherboards;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.DRAMs;

public class DramCompatibilityValidator
{
    private readonly Dram _dram;

    public DramCompatibilityValidator(Dram dram)
    {
        _dram = dram ?? throw new ArgumentNullException(nameof(dram));
    }

    public void ValidateDramCompatibility(Motherboard? motherboard, IReadOnlyCollection<Dram> installedDrams)
    {
        if (motherboard is null)
            throw new PrerequisitesViolationException("Motherboard should be installed before memory");

        if (installedDrams is null)
            throw new PrerequisitesViolationException("Dram collection shouldn't be null");

        if (!motherboard.DdrTypes.Equals(_dram.Ddr))
            throw new MismatchAssemblyException("Wrong DDR format between motherboard and memory");

        if (motherboard.QuantityDram.Value == installedDrams.Count)
            throw new MismatchAssemblyException("Not enough DRAM slots");

        if (_dram.Xmp.All(xmpFrequency => motherboard.Chipset.SupportedXmpProfiles.Contains(xmpFrequency)))
            throw new MismatchAssemblyException("Motherboard is not supporting XMP DRAMs");
    }
}