using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Motherboards;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Motherboards.Chipsets;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.PluginModules;

public class WifiModuleCompatibilityValidator
{
    private readonly WiFiAdapter _wiFiAdapter;

    public WifiModuleCompatibilityValidator(WiFiAdapter wiFiAdapter)
    {
        _wiFiAdapter = wiFiAdapter ?? throw new ArgumentNullException(nameof(wiFiAdapter));
    }

    public virtual void ValidateWifiModuleCompatibility(Motherboard? motherboard)
    {
        if (motherboard is null)
            throw new PrerequisitesViolationException("Motherboard should be installed before Wi-Fi Adapter");

        if (motherboard.Chipset is WifiSupportiveChipset)
            throw new PcAssemblyException("Networking interfaces conflict");
    }
}