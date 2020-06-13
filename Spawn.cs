using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{

    public Material[] materials;
    public int[] lives = new int[7];
    public Transform holder;
    public GameObject spawner;
    public GameObject cameraObj;
    GameObject spawned;
    public objects objScript;
    public uitController uiScript;

    public int speed = 20;
    public int weight = 20;
    public int maxLifes = 2;
    public int maxPlayers = 3;
    public int playerTurn = 0;

    bool turn = false;
    bool cubes = false;
    bool randomAngle = false;

    
    public List<GameObject> shapesList = new List<GameObject>();
    public List<float> heights = new List<float>();


    void Start()
    {
        startGame();
    }   

    public void startGame()
    {
        SpawnObj();
        uiScript.setAmountOfPlayers(maxPlayers);
        for(int i=0; i<maxPlayers; i++)
        {
           lives[i] = maxLifes;
           uiScript.setLifes(i,lives[i]);
        }
    }

    void FixedUpdate()
    {
        move();
    }

    void Update()
    {
        if(turn)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                turn = false;
                spawned.transform.parent = null;
                shapesList.Add(spawned);
                heights.Add(3);
                Rigidbody rb = spawned.AddComponent<Rigidbody>();
                spawned.GetComponent<checkStill>().voidSetRb(rb);
                rb.mass =  weight;
            }
        }
    }

    public void nextTurn()
    {
        if(!turn)
        {
            if(playerTurn + 1 >= maxPlayers)
            {
                playerTurn = 0;
            }else{
                playerTurn ++;   
            }
            SpawnObj();
        }
    }

    float angle;
    void SpawnObj()
    {
        if(!turn)
        {
            turn = true;
            Material shapeMat = materials[playerTurn];
            Vector3 pos = new Vector3(this.transform.position.x,this.transform.position.y-5,this.transform.position.z);
            if(randomAngle)
            {
                angle = Random.Range(-90,90);
            }else{
                angle =  0;
            }
            if(cubes)
            {
                spawned = Instantiate(objScript.shapes[Random.Range(0,objScript.cubes.Length)],pos,Quaternion.Euler(0,angle,0));
            }else{
                spawned = Instantiate(objScript.shapes[Random.Range(0,objScript.shapes.Length)],pos,Quaternion.Euler(0,angle,0));
            }
            spawned.GetComponent<checkStill>().setInfo(playerTurn,this,shapeMat);
            spawned.transform.parent = holder;
            spawned.transform.GetChild(0).GetComponent<MeshRenderer>().material = shapeMat;  
            setHeights();
        }
    }

    void setHeights()
    {
        for(int i=0; i<shapesList.Count; i++)
        {
            if(shapesList[i].transform.position.y < 0)
            {
                GameObject destroyObj = shapesList[i];
                shapesList.Remove(shapesList[i]);
                heights.Remove(heights[i]);
                Destroy(destroyObj);
            }else{
                heights[i] = shapesList[i].transform.position.y;
            }
        }
        checkHeight();
    }

    void checkHeight()
    {
        var maxValue = Mathf.Max(heights.ToArray());

        Vector3 newPos1 = new Vector3(this.transform.position.x,maxValue + 10,this.transform.position.z);
        Vector3 newPos2 = new Vector3(cameraObj.transform.position.x,maxValue + 10,cameraObj.transform.position.z);

        spawner.transform.position = newPos1;
        cameraObj.transform.position = newPos2;

    }

    public void loseLife(int player, bool lose)
    {
        if(lose)
        {
            lives[player] --;
            uiScript.setLifes(player,lives[player]);
        }
        setHeights();
        nextTurn();
    }


    public void winScreen()
    {

    }

    void cameraMoveDown()
    {

    }

    float  maxValue = 15; // or whatever you want the max value to be
    float  minValue = -15; // or whatever you want the min value to be
    float currentValue = 0; // or wherever you want to start
    int direction = 1; 

    void move()
    {
        currentValue += Time.deltaTime * speed * direction; // or however you are incrementing the position

        if(currentValue >= maxValue) {
            direction *= -1;
            currentValue = maxValue;
        } else if (currentValue <= minValue){
            direction *= -1; 
            currentValue = minValue;
        }

        transform.position = new Vector3(currentValue, this.transform.position.y, this.transform.position.z);
 
    }
}
