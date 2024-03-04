using System;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class Gigabyte
{
    private const int MinValue = 0;
    public Gigabyte(int value)
    {
        if (value < MinValue)
            throw new GigabyteValueException("Gigabyte should be above zero");
        Value = value;
    }

    public int Value { get; }

    public static Gigabyte operator +(Gigabyte left, Gigabyte right)
    {
        if (left is null || right is null)
        {
            throw new InvalidOperationException();
        }

        return new Gigabyte(left.Value + right.Value);
    }

    public static Gigabyte operator *(Gigabyte left, Gigabyte right)
    {
        if (left is null || right is null)
        {
            throw new InvalidOperationException();
        }

        return new Gigabyte(left.Value * right.Value);
    }

    public static Gigabyte operator /(Gigabyte left, Gigabyte right)
    {
        if (left is null || right is null)
        {
            throw new InvalidOperationException();
        }

        return new Gigabyte(left.Value / right.Value);
    }

    public static Gigabyte operator -(Gigabyte left, Gigabyte right)
    {
        if (left is null || right is null)
        {
            throw new InvalidOperationException();
        }

        return new Gigabyte(left.Value - right.Value);
    }

    public static bool operator >(Gigabyte? left, Gigabyte? right)
    {
        if ((left != null) && (right != null)) return left.Value > right.Value;
        return false;
    }

    public static bool operator <(Gigabyte? left, Gigabyte? right)
    {
        if ((left != null) && (right != null)) return left.Value < right.Value;
        return false;
    }

    public static Gigabyte Multiply(Gigabyte left, Gigabyte right)
    {
        if (left is null || right is null)
        {
            throw new InvalidOperationException();
        }

        return new Gigabyte(left.Value * right.Value);
    }

    public static Gigabyte Divide(Gigabyte left, Gigabyte right)
    {
        if (left is null || right is null)
        {
            throw new InvalidOperationException();
        }

        return new Gigabyte(left.Value / right.Value);
    }

    public static Gigabyte Add(Gigabyte left, Gigabyte right)
    {
        if (left is null || right is null)
        {
            throw new InvalidOperationException();
        }

        return new Gigabyte(left.Value + right.Value);
    }

    public static Gigabyte Subtract(Gigabyte left, Gigabyte right)
    {
        if (left is null || right is null)
        {
            throw new InvalidOperationException();
        }

        return new Gigabyte(left.Value - right.Value);
    }

    public static Gigabyte ToGigabyte(int value)
    {
        return new Gigabyte(value);
    }

    public int CompareTo(object? obj)
    {
        if (obj is null) return 1;
        if (obj is Gigabyte otherGigabyte)
            return Value.CompareTo(otherGigabyte.Value);
        else
            throw new ArgumentException("Object is not a Gigabyte");
    }

    public bool Equals(Gigabyte? other)
    {
        return other != null && Value.Equals(other.Value);
    }

    public override bool Equals(object? obj)
    {
        return obj is not null &&
               (ReferenceEquals(this, obj) || (obj is Gigabyte otherGigabyte && Equals(otherGigabyte)));
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }
}