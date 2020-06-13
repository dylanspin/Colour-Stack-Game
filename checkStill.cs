using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkStill : MonoBehaviour
{

    public Spawn spawnScript;
    public Material mat;
    public int playernum;
    public GameObject sparks;
    public GameObject explotionObj;
    public Rigidbody rb;

    float speed;
    public bool check = false;
    bool stoped = false;

    void Update()
    {
        if(check)
        {
            speed = rb.velocity.magnitude;
            if(speed < 0.5) {
                rb.velocity = new Vector3(0, 0, 0);
                spawnScript.nextTurn();
                check = false;
                stoped = true;
            }
        }
    }   

    void OnCollisionEnter(Collision collision)
    {
        if(!stoped)
        {
            ContactPoint contact = collision.contacts[0];
            Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
            Vector3 pos = contact.point;
            GameObject effect = Instantiate(sparks, pos, rot) as GameObject;
            effect.transform.GetComponent<ParticleSystemRenderer>().material = mat;
        }
    }

    public void setInfo(int num,Spawn script,Material newMat)
    {
        playernum = num;
        spawnScript = script;
        mat = newMat;
    }

    public void voidSetRb(Rigidbody rBody)
    {
        rb = rBody;
        Invoke("setCheck",1.0f);
    }
    void setCheck()
    {
        check = true;
    }
    public void playExplotion()
    {
        this.transform.gameObject.SetActive(false);
        Vector3 pos = new Vector3(this.transform.position.x,this.transform.position.y,this.transform.position.z);
        Vector3 rot = new Vector3(this.transform.rotation.x,this.transform.rotation.y,this.transform.rotation.z);
        GameObject explotion = Instantiate(explotionObj,pos,Quaternion.Euler(rot));
        explotion.GetComponent<ParticleSystemRenderer>().material = mat;
        explotion.transform.GetChild(0).gameObject.GetComponent<ParticleSystemRenderer>().material = mat;
        explotion.transform.GetChild(1).gameObject.GetComponent<ParticleSystemRenderer>().material = mat;
    }
}
