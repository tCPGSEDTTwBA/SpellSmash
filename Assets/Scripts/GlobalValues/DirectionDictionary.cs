using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static class DirectionDictionary
{
    private static Dictionary<Vector3, string> VECTOR_DIRECTIONS = new Dictionary<Vector3, string>()
    {
        {new Vector3(0,1,0), "UP" },
        {new Vector3(0,-1,0), "DOWN" },
        {new Vector3(-1,0,0), "LEFT" },
        {new Vector3(1,0,0), "RIGHT" }
    };

    private static Dictionary<string, Vector3> NAME_DIRECTIONS = new Dictionary<string, Vector3>()
    {
        {"UP", new Vector3(0,1,0) },
        {"DOWN", new Vector3(0,-1,0) },
        {"LEFT", new Vector3(-1,0,0) },
        {"RIGHT", new Vector3(1,0,0) }
    };

    public static string GetDirection(Vector3 direction)
    {
        if(VECTOR_DIRECTIONS.ContainsKey(direction)) {
            return VECTOR_DIRECTIONS[direction];
        }
        return "";
    }

    public static Vector3 GetDirection(string direction)
    {
        if (NAME_DIRECTIONS.ContainsKey(direction)) {
            return NAME_DIRECTIONS[direction];
        }
        return Vector3.zero;
    }

    public static bool HasKey(string key)
    {
        return NAME_DIRECTIONS.ContainsKey(key);
    }

    public static bool HasKey(Vector3 key)
    {
        return VECTOR_DIRECTIONS.ContainsKey(key);
    }
}
