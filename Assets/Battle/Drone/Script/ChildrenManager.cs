using UnityEngine;
using System.Collections;
using System.Linq;

public static class ChildrenManager 
{
    public static T[] GetComponentsInChildrenWithoutSelf<T>(this GameObject self, bool includeInactive = false) where T : Component
    {
        return self
            .GetComponentsInChildren<T>(includeInactive)
            .Where(c => self != c.gameObject)
            .ToArray();
    }

    public static T[] GetComponentsInChildrenWithoutSelf<T>(this Component self, bool includeInactive = false) where T : Component
    {
        return self
            .GetComponentsInChildren<T>(includeInactive)
            .Where(c => self.gameObject != c.gameObject)
            .ToArray();
    }
}

