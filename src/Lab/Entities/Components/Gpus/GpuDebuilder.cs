using System;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.GPUs;

public class GpuDebuilder
{
    private Millimeters _gpuHeight;
    private Millimeters _gpuLength;
    private Gigabyte _videoMemory;
    private MHz _frequency;
    private Watt _power;

    public GpuDebuilder(Gpu gpu)
    {
        if (gpu is null)
            throw new ArgumentNullException(nameof(gpu));

        _gpuHeight = gpu.GpuHeight;
        _gpuLength = gpu.GpuLength;
        _videoMemory = gpu.VideoMemory;
        _frequency = gpu.Frequency;
        _power = gpu.Power;
    }

    public GpuDebuilder AnotherGpuHeight(Millimeters height)
    {
        _gpuHeight = height;
        return this;
    }

    public GpuDebuilder AnotherGpuLength(Millimeters length)
    {
        _gpuLength = length;
        return this;
    }

    public GpuDebuilder AnotherVideoMemory(Gigabyte memory)
    {
        _videoMemory = memory;
        return this;
    }

    public GpuDebuilder AnotherFrequency(MHz gpuFrequency)
    {
        _frequency = gpuFrequency;
        return this;
    }

    public GpuDebuilder AnotherPower(Watt gpuPower)
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