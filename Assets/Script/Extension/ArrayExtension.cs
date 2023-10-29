using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace DF.Extension
{
    public static partial class Extension
    {
        public static T RandomElement<T>(this T[] array)
        {
            if (array == null || array.Length == 0)
            {
                Debug.LogError("Array is null or empty!");
                return default(T);
            }

            int randomIndex = Random.Range(0, array.Length);
            return array[randomIndex];
        }
    }
}
