using System;
using UnityEngine;

public static class EnumExtantion
{
    public static bool HasFlag(this Enum val, Enum flags)
    {
        long ulongVal = Convert.ToInt64(val);
        long ulongFlags = Convert.ToInt64(flags);

        if (ulongFlags == 0)
        {
            Debug.LogWarning("Не содержит флагов");
            return false;
        }

        return (ulongVal & ulongFlags) == ulongFlags;
    }
}
