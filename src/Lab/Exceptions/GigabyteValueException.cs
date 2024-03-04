using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

public class GigabyteValueException : Exception
{
    public GigabyteValueException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public GigabyteValueException(string message)
        : base(message)
    {
    }

    public GigabyteValueException()
    {
    }
}