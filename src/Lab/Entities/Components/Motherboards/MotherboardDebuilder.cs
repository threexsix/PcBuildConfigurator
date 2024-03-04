using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Motherboards.Chipsets;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Motherboards;

public class MotherboardDebuilder
{
    private FormFactors _formFactor;
    private CpuSocket _socket;
    private IChipset? _chipset;
    private Bios? _bios;
    private MemoryFormFactors _memoryFormFactors;
    private Ddr _ddrTypes;
    private Gigabyte? _maxMemoryCapacity;
    private Quantity? _quantityDram;
    private Quantity? _quantityPciEx16;
    private Quantity? _quantityPciEx4;
    private Quantity? _quantitySata;
    private Watt? _power;

    public MotherboardDebuilder(Motherboard motherboard)
    {
        if (motherboard is null)
            throw new ArgumentNullException(nameof(motherboard));

        _formFactor = motherboard.FormFactor;
        _socket = motherboard.Socket;
        _chipset = motherboard.Chipset;
        _bios = motherboard.Bios;
        _memoryFormFactors = motherboard.MemoryFormFactors;
        _ddrTypes = motherboard.DdrTypes;
        _maxMemoryCapacity = motherboard.MaxMemoryCapacity;
        _quantityDram = motherboard.QuantityDram;
        _quantityPciEx16 = motherboard.QuantityPciEx16;
        _quantityPciEx4 = motherboard.QuantityPciEx4;
        _quantitySata = motherboard.QuantitySata;
        _power = motherboard.Power;
    }

    public MotherboardDebuilder AnotherFormFactor(FormFactors factor)
    {
        _formFactor = factor;
        return this;
    }

    public MotherboardDebuilder AnotherSocket(CpuSocket cpuSocket)
    {
        _socket = cpuSocket;
        return this;
    }

    public MotherboardDebuilder AnotherChipset(Chipset chipsetType)
    {
        _chipset = chipsetType;
        return this;
    }

    public MotherboardDebuilder AnotherBios(Bios biosType)
    {
        _bios = biosType;
        return this;
    }

    public MotherboardDebuilder AnotherMemoryFormFactors(MemoryFormFactors formFactors)
    {
        _memoryFormFactors = formFactors;
        return this;
    }

    public MotherboardDebuilder AnotherDdrTypes(Ddr ddr)
    {
        _ddrTypes = ddr;
        return this;
    }

    public MotherboardDebuilder AnotherMaxMemoryCapacity(Gigabyte capacity)
    {
        _maxMemoryCapacity = capacity;
        return this;
    }

    public MotherboardDebuilder AnotherQuantityDram(Quantity dramQuantity)
    {
        _quantityDram = dramQuantity;
        return this;
    }

    public MotherboardDebuilder AnotherQuantityPciEx16(Quantity pciEx16Quantity)
    {
        _quantityPciEx16 = pciEx16Quantity;
        return this;
    }

    public MotherboardDebuilder AnotherQuantityPciEx4(Quantity pciEx4Quantity)
    {
        _quantityPciEx4 = pciEx4Quantity;
        return this;
    }

    public MotherboardDebuilder AnotherQuantitySata(Quantity sataQuantity)
    {
        _quantitySata = sataQuantity;
        return this;
    }

    public MotherboardDebuilder AnotherPower(Watt motherboardPower)
    {
        _power = motherboardPower;
        return this;
    }

    public Motherboard Build()
    {
        if (_chipset is null || _bios is null || _maxMemoryCapacity is null || _quantityDram is null ||
            _quantityPciEx16 is null || _quantityPciEx4 is null || _quantitySata is null || _power is null)
            throw new ArgumentNullException();

        return new Motherboard(
            _formFactor,
            _socket,
            _chipset,
            _bios,
            _memoryFormFactors,
            _ddrTypes,
            _maxMemoryCapacity,
            _quantityDram,
            _quantityPciEx16,
            _quantityPciEx4,
            _quantitySata,
            _power);
    }
}