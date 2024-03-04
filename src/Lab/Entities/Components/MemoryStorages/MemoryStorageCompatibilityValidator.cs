using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Motherboards;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.MemoryStorages;

public class MemoryStorageCompatibilityValidator
{
    private readonly MemoryStorage _memoryStorage;

    public MemoryStorageCompatibilityValidator(MemoryStorage memoryStorage)
    {
        _memoryStorage = memoryStorage ?? throw new ArgumentNullException(nameof(memoryStorage));
    }

    public void ValidateMemoryStorageCompatibility(Motherboard? motherboard, IReadOnlyCollection<MemoryStorage?> sataMemoryStorages, IReadOnlyCollection<MemoryStorage?> pcieX4MemoryStorages)
    {
        if (motherboard is null)
            throw new PrerequisitesViolationException("Motherboard should be installed before memory storage");

        if (sataMemoryStorages is null || pcieX4MemoryStorages is null)
            throw new PrerequisitesViolationException("MemoryStorage collections shouldn't be null");

        if (_memoryStorage.InterfaceType.Equals(new MemoryStorageInterfaces("SATA")) &&
            motherboard.QuantitySata.Value <= sataMemoryStorages.Count)
            throw new MismatchAssemblyException("Not enough SATA memory storage slots");

        if (_memoryStorage.InterfaceType.Equals(new MemoryStorageInterfaces("PCIEx4")) &&
            motherboard.QuantityPciEx4.Value <= pcieX4MemoryStorages.Count)
            throw new MismatchAssemblyException("Not enough PCI-E x4 memory storage slots");
    }
}