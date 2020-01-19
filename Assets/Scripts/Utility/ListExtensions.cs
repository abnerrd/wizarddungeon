using System.Collections.Generic;

public static class ListExtensions
{
    public static bool AddExclusive<T>(this List<T> toAddList, T toAdd) 
    {
        if (toAddList.Contains(toAdd))
        {
            return false;
        }

        toAddList.Add(toAdd);
        return true;
    }
}
