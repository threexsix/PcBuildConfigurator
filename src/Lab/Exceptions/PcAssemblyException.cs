using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

public class PcAssemblyException : Exception
{
    public PcAssemblyException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public PcAssemblyException(string message)
        : base(message)
    {
    }

    public PcAssemblyException()
    {
    }
}