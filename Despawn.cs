using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despawn : MonoBehaviour
{
    public float despawnTime = 1.0f;

    void Start()
    {
        Destroy(this.gameObject,despawnTime);
    }
}
