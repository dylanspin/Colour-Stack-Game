using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnMain : MonoBehaviour
{
    public Material[] mat;
    public Transform[] spawnPoints;
    public objects objScript;


    public void Start()
    {
        Spawn();
    }

    void Spawn()
    {
        CancelInvoke("Spawn");
        int random = Random.Range(0,spawnPoints.Length);
        Vector3 pos = new Vector3(spawnPoints[random].position.x,spawnPoints[random].position.y,spawnPoints[random].position.z);
        GameObject spawned =  Instantiate(objScript.shapes[Random.Range(0,objScript.shapes.Length)],pos,Quaternion.Euler(Random.Range(-90,90),Random.Range(-90,90),Random.Range(-90,90)));
        spawned.transform.GetChild(0).transform.gameObject.GetComponent<MeshRenderer>().material = mat[Random.Range(0,mat.Length)];
        Invoke("Spawn",Random.Range(0,3));
    }
}
