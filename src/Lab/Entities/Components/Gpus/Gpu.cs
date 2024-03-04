using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Services;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.GPUs;

public class Gpu : IPowered, ICloneable<Gpu>
{
    public Gpu(
        Millimeters gpuHeight,
        Millimeters gpuLength,
        Gigabyte videoMemory,
        MHz frequency,
        Watt power)
    {
        GpuHeight = gpuHeight ?? throw new ArgumentNullException(nameof(gpuHeight));
        GpuLength = gpuLength ?? throw new ArgumentNullException(nameof(gpuLength));
        VideoMemory = videoMemory ?? throw new ArgumentNullException(nameof(videoMemory));
        Frequency = frequency ?? throw new ArgumentNullException(nameof(frequency));
        Power = power ?? throw new ArgumentNullException(nameof(power));
    }

    public Millimeters GpuHeight { get; }
    public Millimeters GpuLength { get; }
    public Gigabyte VideoMemory { get; }
    public MHz Frequency { get; }
    public Watt Power { get; }

    public Gpu Clone()
    {
        return new Gpu(
            new Millimeters(GpuHeight.Value),
            new Millimeters(GpuLength.Value),
            new Gigabyte(VideoMemory.Value),
            new MHz(Frequency.Value),
            new Watt(Power.Value));
    }
}