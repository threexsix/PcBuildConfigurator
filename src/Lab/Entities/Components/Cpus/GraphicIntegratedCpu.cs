namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.CPUs;

public class GraphicIntegratedCpu : CpuDecorator
{
    public GraphicIntegratedCpu(ICpu wrappee)
        : base(wrappee)
    {
    }

    public override ICpu Clone()
    {
        return new GraphicIntegratedCpu(Wrappee);
    }
}