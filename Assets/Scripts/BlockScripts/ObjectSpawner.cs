using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject SpawnGameObject(GameObject gameObject, Transform parent)
    {
        return Instantiate(gameObject, transform.position, Quaternion.identity, parent);
    }

    public GameObject SpawnGameObject(GameObject gameObject)
    {
        return Instantiate(gameObject, transform.position, Quaternion.identity);
    }
}
