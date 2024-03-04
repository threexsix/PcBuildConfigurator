using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

public class PrerequisitesViolationException : Exception
{
    public PrerequisitesViolationException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public PrerequisitesViolationException(string message)
        : base(message)
    {
    }

    public PrerequisitesViolationException()
    {
    }
}