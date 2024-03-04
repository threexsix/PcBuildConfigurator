using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

public class FrequencyValueException : Exception
{
    public FrequencyValueException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public FrequencyValueException(string message)
        : base(message)
    {
    }

    public FrequencyValueException()
    {
    }
}