using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.DRAMs;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Motherboards.Chipsets;

public interface IChipset
{
    public IReadOnlyCollection<Xmp> SupportedXmpProfiles { get; }
}