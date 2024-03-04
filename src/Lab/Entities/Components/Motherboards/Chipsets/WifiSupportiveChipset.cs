namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Motherboards.Chipsets;

public class WifiSupportiveChipset : ChipsetDecorator
{
    public WifiSupportiveChipset(Chipset wrappee)
        : base(wrappee)
    {
    }
}