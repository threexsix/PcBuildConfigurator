using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

public class MillimetersValueException : Exception
{
    public MillimetersValueException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public MillimetersValueException(string message)
        : base(message)
    {
    }

    public MillimetersValueException()
    {
    }
}