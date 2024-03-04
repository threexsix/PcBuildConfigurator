using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

public class QuantityValueException : Exception
{
    public QuantityValueException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public QuantityValueException(string message)
        : base(message)
    {
    }

    public QuantityValueException()
    {
    }
}