using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

public class WattValueException : Exception
{
    public WattValueException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public WattValueException(string message)
        : base(message)
    {
    }

    public WattValueException()
    {
    }
}