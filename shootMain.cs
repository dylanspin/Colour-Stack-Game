using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootMain : MonoBehaviour
{
    public GameObject explotionObj;
    void Update()
    {
        if ( Input.GetMouseButtonDown (0)){ 
            RaycastHit hit; 
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); 
            if ( Physics.Raycast (ray,out hit,200.0f)) {
                if(hit.transform.root.transform.tag == "shape")
                {
                    GameObject hitObj = hit.transform.gameObject;
                    Vector3 pos = new Vector3(hitObj.transform.position.x,hitObj.transform.position.y,hitObj.transform.position.z);
                    Vector3 rot = new Vector3(hitObj.transform.rotation.x,hitObj.transform.rotation.y,hitObj.transform.rotation.z);
                    Material mat = hitObj.transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().material;
                    GameObject explotion = Instantiate(explotionObj,pos,Quaternion.Euler(rot));
                    explotion.GetComponent<ParticleSystemRenderer>().material = mat;
                    explotion.transform.GetChild(0).gameObject.GetComponent<ParticleSystemRenderer>().material = mat;
                    explotion.transform.GetChild(1).gameObject.GetComponent<ParticleSystemRenderer>().material = mat;
                    Destroy(hitObj);
                }
            }
        }
    }
}
