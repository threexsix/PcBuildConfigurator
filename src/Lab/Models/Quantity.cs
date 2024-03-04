using System;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class Quantity
{
    private const int MinValue = 0;

    public Quantity(int value)
    {
        if (value < MinValue)
            throw new QuantityValueException("Quantity should be above zero");
        Value = value;
    }

    public int Value { get; }

    public static Quantity operator +(Quantity left, Quantity right)
    {
        if (left is null || right is null)
        {
            throw new InvalidOperationException();
        }

        return new Quantity(left.Value + right.Value);
    }

    public static Quantity operator *(Quantity left, Quantity right)
    {
        if (left is null || right is null)
        {
            throw new InvalidOperationException();
        }

        return new Quantity(left.Value * right.Value);
    }

    public static Quantity operator /(Quantity left, Quantity right)
    {
        if (left is null || right is null)
        {
            throw new InvalidOperationException();
        }

        return new Quantity(left.Value / right.Value);
    }

    public static Quantity operator -(Quantity left, Quantity right)
    {
        if (left is null || right is null)
        {
            throw new InvalidOperationException();
        }

        return new Quantity(left.Value - right.Value);
    }

    public static bool operator >(Quantity? left, Quantity? right)
    {
        if ((left != null) && (right != null)) return left.Value > right.Value;
        return false;
    }

    public static bool operator <(Quantity? left, Quantity? right)
    {
        if ((left != null) && (right != null)) return left.Value < right.Value;
        return false;
    }

    public static Quantity Multiply(Quantity left, Quantity right)
    {
        if (left is null || right is null)
        {
            throw new InvalidOperationException();
        }

        return new Quantity(left.Value * right.Value);
    }

    public static Quantity Divide(Quantity left, Quantity right)
    {
        if (left is null || right is null)
        {
            throw new InvalidOperationException();
        }

        return new Quantity(left.Value / right.Value);
    }

    public static Quantity Add(Quantity left, Quantity right)
    {
        if (left is null || right is null)
        {
            throw new InvalidOperationException();
        }

        return new Quantity(left.Value + right.Value);
    }

    public static Quantity Subtract(Quantity left, Quantity right)
    {
        if (left is null || right is null)
        {
            throw new InvalidOperationException();
        }

        return new Quantity(left.Value - right.Value);
    }

    public static Quantity ToQuantity(int value)
    {
        return new Quantity(value);
    }

    public int CompareTo(object? obj)
    {
        if (obj is null) return 1;
        if (obj is Quantity otherQuantity)
            return Value.CompareTo(otherQuantity.Value);
        else
            throw new ArgumentException("Object is not a Quantity");
    }

    public bool Equals(Quantity? other)
    {
        return other != null && Value.Equals(other.Value);
    }

    public override bool Equals(object? obj)
    {
        return obj is not null &&
               (ReferenceEquals(this, obj) || (obj is Quantity otherQuantity && Equals(otherQuantity)));
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }
}