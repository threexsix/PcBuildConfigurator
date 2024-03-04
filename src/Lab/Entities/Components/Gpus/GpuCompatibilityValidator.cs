using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.ComputerCases;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Motherboards;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.GPUs;

public class GpuCompatibilityValidator
{
    private readonly Gpu _gpu;

    public GpuCompatibilityValidator(Gpu gpu)
    {
        _gpu = gpu ?? throw new ArgumentNullException(nameof(gpu));
    }

    public void ValidateGpuCompatibility(ComputerCase? computerCase, Motherboard? motherboard, IReadOnlyCollection<Gpu?> installedGpus)
    {
        if (computerCase is null || motherboard is null)
            throw new PrerequisitesViolationException("Case and motherboard should be installed before GPUs");

        if (installedGpus is null)
            throw new PrerequisitesViolationException("Dram collection shouldn't be null");

        if (computerCase.MaxHeight < _gpu.GpuHeight || computerCase.MaxLength < _gpu.GpuLength)
            throw new MismatchAssemblyException("GPUs do not fit the PC case");

        if (motherboard.QuantityPciEx16.Value == installedGpus.Count)
            throw new MismatchAssemblyException("Not enough PCI-Ex16 slots for GPUs");
    }
}