using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public abstract class ConnectionType
{
    protected ConnectionType(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("string is null or empty", nameof(name));
        Name = name;
    }

    public string Name { get; }

    public bool Equals(ConnectionType? other)
    {
        return other != null && Name.Equals(other.Name, StringComparison.Ordinal);
    }

    public override bool Equals(object? obj)
    {
        return obj is not null &&
               (ReferenceEquals(this, obj) || (obj is ConnectionType otherSocketType && Equals(otherSocketType)));
    }

    public override int GetHashCode()
    {
        return Name.GetHashCode(StringComparison.Ordinal);
    }
}