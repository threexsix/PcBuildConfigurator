using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Motherboards.Chipsets;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Services;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Motherboards;

public class Motherboard : IPowered, ICloneable<Motherboard>
{
    public Motherboard(
        FormFactors formFactor,
        CpuSocket socket,
        IChipset chipset,
        Bios bios,
        MemoryFormFactors memoryFormFactors,
        Ddr ddrTypes,
        Gigabyte maxMemoryCapacity,
        Quantity quantityDram,
        Quantity quantityPciEx16,
        Quantity quantityPciEx4,
        Quantity quantitySata,
        Watt power)
    {
        FormFactor = formFactor ?? throw new ArgumentNullException(nameof(formFactor));
        Socket = socket ?? throw new ArgumentNullException(nameof(socket));
        Chipset = chipset ?? throw new ArgumentNullException(nameof(chipset));
        Bios = bios ?? throw new ArgumentNullException(nameof(bios));
        MemoryFormFactors = memoryFormFactors ?? throw new ArgumentNullException(nameof(memoryFormFactors));
        DdrTypes = ddrTypes ?? throw new ArgumentNullException(nameof(ddrTypes));
        MaxMemoryCapacity = maxMemoryCapacity ?? throw new ArgumentNullException(nameof(maxMemoryCapacity));
        QuantityDram = quantityDram ?? throw new ArgumentNullException(nameof(quantityDram));
        QuantityPciEx16 = quantityPciEx16 ?? throw new ArgumentNullException(nameof(quantityPciEx16));
        QuantityPciEx4 = quantityPciEx4 ?? throw new ArgumentNullException(nameof(quantityPciEx4));
        QuantitySata = quantitySata ?? throw new ArgumentNullException(nameof(quantitySata));
        Power = power ?? throw new ArgumentNullException(nameof(power));
    }

    public FormFactors FormFactor { get; }
    public CpuSocket Socket { get; }
    public IChipset Chipset { get; }
    public Bios Bios { get; }
    public MemoryFormFactors MemoryFormFactors { get; }
    public Ddr DdrTypes { get; }
    public Gigabyte MaxMemoryCapacity { get; }
    public Quantity QuantityDram { get; }
    public Quantity QuantityPciEx16 { get; }
    public Quantity QuantityPciEx4 { get; }
    public Quantity QuantitySata { get; }
    public Watt Power { get; }

    public Motherboard Clone()
    {
        return new Motherboard(
            FormFactor,
            Socket,
            Chipset,
            Bios,
            MemoryFormFactors,
            DdrTypes,
            new Gigabyte(MaxMemoryCapacity.Value),
            new Quantity(QuantityDram.Value),
            new Quantity(QuantityPciEx16.Value),
            new Quantity(QuantityPciEx4.Value),
            new Quantity(QuantitySata.Value),
            new Watt(Power.Value));
    }
}