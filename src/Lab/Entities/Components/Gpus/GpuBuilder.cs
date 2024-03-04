using System;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.GPUs;

public class GpuBuilder
{
    private Millimeters? _gpuHeight;
    private Millimeters? _gpuLength;
    private Gigabyte? _videoMemory;
    private MHz? _frequency;
    private Watt? _power;

    public GpuBuilder WithGpuHeight(Millimeters height)
    {
        _gpuHeight = height;
        return this;
    }

    public GpuBuilder WithGpuLength(Millimeters length)
    {
        _gpuLength = length;
        return this;
    }

    public GpuBuilder WithVideoMemory(Gigabyte memory)
    {
        _videoMemory = memory;
        return this;
    }

    public GpuBuilder WithFrequency(MHz gpuFrequency)
    {
        _frequency = gpuFrequency;
        return this;
    }

    public GpuBuilder WithPower(Watt gpuPower)
    {
        _power = gpuPower;
        return this;
    }

    public Gpu Build()
    {
        if (_gpuHeight is null || _gpuLength is null || _videoMemory is null || _frequency is null || _power is null)
            throw new ArgumentNullException();
        return new Gpu(_gpuHeight, _gpuLength, _videoMemory, _frequency, _power);
    }
}