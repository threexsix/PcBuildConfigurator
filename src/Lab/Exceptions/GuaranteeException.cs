using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

public class GuaranteeException : Exception
{
    public GuaranteeException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public GuaranteeException(string message)
        : base(message)
    {
    }

    public GuaranteeException()
    {
    }
}