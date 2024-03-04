using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Motherboards.Chipsets;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Motherboards;

public class MotherboardBuilder
{
        private FormFactors? _formFactor;
        private CpuSocket? _socket;
        private IChipset? _chipset;
        private Bios? _bios;
        private MemoryFormFactors? _memoryFormFactors;
        private Ddr? _ddrTypes;
        private Gigabyte? _maxMemoryCapacity;
        private Quantity? _quantityDram;
        private Quantity? _quantityPciEx16;
        private Quantity? _quantityPciEx4;
        private Quantity? _quantitySata;
        private Watt? _power;

        public MotherboardBuilder WithFormFactor(FormFactors factor)
        {
            _formFactor = factor;
            return this;
        }

        public MotherboardBuilder WithSocket(CpuSocket cpuSocket)
        {
            _socket = cpuSocket;
            return this;
        }

        public MotherboardBuilder WithChipset(Chipset chipsetType)
        {
            _chipset = chipsetType;
            return this;
        }

        public MotherboardBuilder WithBios(Bios biosType)
        {
            _bios = biosType;
            return this;
        }

        public MotherboardBuilder WithMemoryFormFactors(MemoryFormFactors formFactors)
        {
            _memoryFormFactors = formFactors;
            return this;
        }

        public MotherboardBuilder WithDdrTypes(Ddr ddr)
        {
            _ddrTypes = ddr;
            return this;
        }

        public MotherboardBuilder WithMaxMemoryCapacity(Gigabyte capacity)
        {
            _maxMemoryCapacity = capacity;
            return this;
        }

        public MotherboardBuilder WithQuantityDram(Quantity dramQuantity)
        {
            _quantityDram = dramQuantity;
            return this;
        }

        public MotherboardBuilder WithQuantityPciEx16(Quantity pciEx16Quantity)
        {
            _quantityPciEx16 = pciEx16Quantity;
            return this;
        }

        public MotherboardBuilder WithQuantityPciEx4(Quantity pciEx4Quantity)
        {
            _quantityPciEx4 = pciEx4Quantity;
            return this;
        }

        public MotherboardBuilder WithQuantitySata(Quantity sataQuantity)
        {
            _quantitySata = sataQuantity;
            return this;
        }

        public MotherboardBuilder WithPower(Watt motherboardPower)
        {
            _power = motherboardPower;
            return this;
        }

        public Motherboard Build()
        {
            if (_chipset is null || _bios is null || _maxMemoryCapacity is null || _quantityDram is null ||
                _quantityPciEx16 is null || _quantityPciEx4 is null || _quantitySata is null || _power is null ||
                _formFactor is null || _socket is null || _memoryFormFactors is null || _ddrTypes is null)
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
