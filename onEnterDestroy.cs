using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onEnterDestroy : MonoBehaviour
{
    public Spawn spawnScript;
    private void OnTriggerEnter(Collider other)
    {
        checkStill checkScript = other.transform.root.transform.gameObject.GetComponent<checkStill>();
        checkScript.playExplotion();
        spawnScript.loseLife(checkScript.playernum,checkScript.check);
    }
}
