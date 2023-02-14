using System;

public static class IntHelpers
{
    public static bool IsEven(this int number)
    {
        return (number & 1) == 0;
    }
    public static bool IsOdd(this int number)
    {
        return (number & 1) == 1;
    }
}
