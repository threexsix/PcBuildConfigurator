using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.DRAMs;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Motherboards.Chipsets;

public class Chipset : IChipset
{
    private readonly List<Xmp> _xmps;
    public Chipset(IEnumerable<Xmp> supportedXmpProfiles)
    {
        _xmps = new List<Xmp>(supportedXmpProfiles);
    }

    public IReadOnlyCollection<Xmp> SupportedXmpProfiles => _xmps;
}