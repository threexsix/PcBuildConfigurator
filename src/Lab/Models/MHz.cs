using System;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class MHz
{
    private const int MinValue = 0;
    public MHz(int value)
    {
        if (value < MinValue)
            throw new FrequencyValueException("MHz should be above zero");
        Value = value;
    }

    public int Value { get; }

    public static MHz operator +(MHz left, MHz right)
    {
        if (left is null || right is null)
        {
            throw new InvalidOperationException();
        }

        return new MHz(left.Value + right.Value);
    }

    public static MHz operator *(MHz left, MHz right)
    {
        if (left is null || right is null)
        {
            throw new InvalidOperationException();
        }

        return new MHz(left.Value * right.Value);
    }

    public static MHz operator /(MHz left, MHz right)
    {
        if (left is null || right is null)
        {
            throw new InvalidOperationException();
        }

        return new MHz(left.Value / right.Value);
    }

    public static MHz operator -(MHz left, MHz right)
    {
        if (left is null || right is null)
        {
            throw new InvalidOperationException();
        }

        return new MHz(left.Value - right.Value);
    }

    public static bool operator >(MHz? left, MHz? right)
    {
        if ((left != null) && (right != null)) return left.Value > right.Value;
        return false;
    }

    public static bool operator <(MHz? left, MHz? right)
    {
        if ((left != null) && (right != null)) return left.Value < right.Value;
        return false;
    }

    public static MHz Multiply(MHz left, MHz right)
    {
        if (left is null || right is null)
        {
            throw new InvalidOperationException();
        }

        return new MHz(left.Value * right.Value);
    }

    public static MHz Divide(MHz left, MHz right)
    {
        if (left is null || right is null)
        {
            throw new InvalidOperationException();
        }

        return new MHz(left.Value / right.Value);
    }

    public static MHz Add(MHz left, MHz right)
    {
        if (left is null || right is null)
        {
            throw new InvalidOperationException();
        }

        return new MHz(left.Value + right.Value);
    }

    public static MHz Subtract(MHz left, MHz right)
    {
        if (left is null || right is null)
        {
            throw new InvalidOperationException();
        }

        return new MHz(left.Value - right.Value);
    }

    public static MHz ToMHz(int value)
    {
        return new MHz(value);
    }

    public int CompareTo(object? obj)
    {
        if (obj is null) return 1;
        if (obj is MHz otherMHz)
            return Value.CompareTo(otherMHz.Value);
        else
            throw new ArgumentException("Object is not a MHz");
    }

    public bool Equals(MHz? other)
    {
        return other != null && Value.Equals(other.Value);
    }

    public override bool Equals(object? obj)
    {
        return obj is not null &&
               (ReferenceEquals(this, obj) || (obj is MHz otherMHz && Equals(otherMHz)));
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }
}