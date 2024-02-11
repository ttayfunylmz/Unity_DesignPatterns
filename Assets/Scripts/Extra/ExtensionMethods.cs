using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Extension Methods class that are useful for some cases in our Design Pattern examples.
public static class ExtensionMethods
{
    //Sets any value of the Vector3
    public static Vector3 With(this Vector3 vector, float? x = null, float? y = null, float? z = null) 
    {
        return new Vector3(x ?? vector.x, y ?? vector.y, z ?? vector.z);
    }
}
