using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.DRAMs;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Motherboards.Chipsets;

public abstract class ChipsetDecorator : IChipset
{
    protected ChipsetDecorator(Chipset wrappee)
    {
        ArgumentNullException.ThrowIfNull(wrappee);
        Wrappee = wrappee;
        SupportedXmpProfiles = wrappee.SupportedXmpProfiles;
    }

    public Chipset Wrappee { get; }
    public IReadOnlyCollection<Xmp> SupportedXmpProfiles { get; }
}