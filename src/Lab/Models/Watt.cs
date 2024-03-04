using System;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class Watt
{
    private const int MinValue = 0;

    public Watt(int value)
    {
        if (value < MinValue)
            throw new WattValueException("Watt should be above zero");
        Value = value;
    }

    public int Value { get; }

    public static Watt operator +(Watt left, Watt right)
    {
        if (left is null || right is null)
        {
            throw new InvalidOperationException();
        }

        return new Watt(left.Value + right.Value);
    }

    public static Watt operator *(Watt left, Watt right)
    {
        if (left is null || right is null)
        {
            throw new InvalidOperationException();
        }

        return new Watt(left.Value * right.Value);
    }

    public static Watt operator /(Watt left, Watt right)
    {
        if (left is null || right is null)
        {
            throw new InvalidOperationException();
        }

        return new Watt(left.Value / right.Value);
    }

    public static Watt operator -(Watt left, Watt right)
    {
        if (left is null || right is null)
        {
            throw new InvalidOperationException();
        }

        return new Watt(left.Value - right.Value);
    }

    public static bool operator >(Watt? left, Watt? right)
    {
        if ((left != null) && (right != null)) return left.Value > right.Value;
        return false;
    }

    public static bool operator <(Watt? left, Watt? right)
    {
        if ((left != null) && (right != null)) return left.Value < right.Value;
        return false;
    }

    public static Watt Multiply(Watt left, Watt right)
    {
        if (left is null || right is null)
        {
            throw new InvalidOperationException();
        }

        return new Watt(left.Value * right.Value);
    }

    public static Watt Divide(Watt left, Watt right)
    {
        if (left is null || right is null)
        {
            throw new InvalidOperationException();
        }

        return new Watt(left.Value / right.Value);
    }

    public static Watt Add(Watt left, Watt right)
    {
        if (left is null || right is null)
        {
            throw new InvalidOperationException();
        }

        return new Watt(left.Value + right.Value);
    }

    public static Watt Subtract(Watt left, Watt right)
    {
        if (left is null || right is null)
        {
            throw new InvalidOperationException();
        }

        return new Watt(left.Value - right.Value);
    }

    public static Watt ToWatt(int value)
    {
        return new Watt(value);
    }

    public int CompareTo(object? obj)
    {
        if (obj is null) return 1;
        if (obj is Watt otherWatt)
            return Value.CompareTo(otherWatt.Value);
        else
            throw new ArgumentException("Object is not a Watt");
    }

    public bool Equals(Watt? other)
    {
        return other != null && Value.Equals(other.Value);
    }

    public override bool Equals(object? obj)
    {
        return obj is not null &&
               (ReferenceEquals(this, obj) || (obj is Watt otherWatt && Equals(otherWatt)));
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }
}