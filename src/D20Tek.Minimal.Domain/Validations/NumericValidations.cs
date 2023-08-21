//---------------------------------------------------------------------------------------------------------------------
// Copyright (c) d20Tek.  All rights reserved.
//---------------------------------------------------------------------------------------------------------------------

namespace D20Tek.Minimal.Domain.Validations;

public static class NumericValidations
{
    public static bool InRange<T>(this T number, T min, T max, bool isInclusive = true)
        where T : struct, IComparable<T>
    {
        var minCheck = number.CompareTo(min);
        var maxCheck = number.CompareTo(max);

        if (isInclusive)
        {
            return (minCheck >= 0) && (maxCheck <= 0);
        }

        return (minCheck > 0) && (maxCheck < 0);
    }

    public static bool GreaterThan<T>(this T number, T other, bool isInclusive = true)
        where T : struct, IComparable<T>
    {
        var check = number.CompareTo(other);

        if (isInclusive)
        {
            return (check >= 0);
        }

        return (check > 0);
    }

    public static bool LessThan<T>(this T number, T other, bool isInclusive = true)
        where T : struct, IComparable<T>
    {
        var check = number.CompareTo(other);

        if (isInclusive)
        {
            return (check <= 0);
        }

        return (check < 0);
    }
}
