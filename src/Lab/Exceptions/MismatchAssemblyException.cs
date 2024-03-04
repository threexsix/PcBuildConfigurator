using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

public class MismatchAssemblyException : Exception
{
    public MismatchAssemblyException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public MismatchAssemblyException(string message)
        : base(message)
    {
    }

    public MismatchAssemblyException()
    {
    }
}