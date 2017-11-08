using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Vector2Extension
{

    public static float RandomValue(this Vector2 v2)
    {
        float random = Random.Range(v2.x, v2.y);

        Debug.Log(random);

        return random;
    }


}
