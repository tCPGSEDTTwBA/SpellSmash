using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Helper functions to keep track of string directions, vectors and indexes
 */
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

    private static Dictionary<string, int> DIRECTION_INDEX = new Dictionary<string, int> { 
        { "UP", 0 }, {"DOWN", 1 }, {"LEFT", 2 }, {"RIGHT", 3 } 
    };

    private static Dictionary<int, string> INDEX_OF_DIRECTION = new Dictionary<int, string> {
        {0, "UP"  }, {1, "DOWN" }, {2, "LEFT"  }, {3, "RIGHT"  }
    };

    public static string GetDirection(Vector3 direction)
    {
        if(HasKey(direction)) {
            return VECTOR_DIRECTIONS[direction];
        }
        return "";
    }

    public static string GetDirection(Vector2 direction)
    {
        return GetDirection((Vector3)direction);
    }

    public static Vector3 GetDirection(string direction)
    {
        if (HasKey(direction)) {
            return NAME_DIRECTIONS[direction];
        }
        return Vector3.zero;
    }

    public static int GetIndex(string direction)
    {
        return DIRECTION_INDEX[direction];
    }

    public static string GetDirectionByIndex(int index)
    {
        return INDEX_OF_DIRECTION[index];
    }
    
    public static bool HasKey(string key)
    {
        return NAME_DIRECTIONS.ContainsKey(key);
    }

    public static bool HasKey(Vector3 key)
    {
        return VECTOR_DIRECTIONS.ContainsKey(key);
    }

    public static bool HasKey(Vector2 key)
    {
        return HasKey((Vector3)key);
    }
}
