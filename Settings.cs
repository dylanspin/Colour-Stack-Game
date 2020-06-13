using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    public GameObject[] valuesobj;
    public static int players = 2;
    public static int lives = 2;
    public static int speed = 13;
    public static float size = 1.0f;
    public bool cubes = false;
    public bool rotations = false;
    public Spawn spawnScript;


    void Start()
    {
        if(spawnScript)
        {
            spawnScript.startGame();
        }    
    }


    public void moreLives()
    {
        if(lives + 1 > 4)
        {
            lives = 0;
        }else{
            lives ++;
        }
        valuesobj[0].GetComponent<TMPro.TextMeshProUGUI>().text = ""+lives;
    }

    public void lessLives()
    {
        if(lives - 1 < 0)
        {
            lives = 4;
        }else{
            lives ++;
        }
        valuesobj[0].GetComponent<TMPro.TextMeshProUGUI>().text = ""+lives;
    }

    public void morePlayers()
    {
        if(players + 1 > 7)
        {
            players = 0;
        }else{
            players ++;
        }
        valuesobj[1].GetComponent<TMPro.TextMeshProUGUI>().text = ""+players;
    }

    public void lessPlayers()
    {
        if(players - 1 < 0)
        {
            players = 0;
        }else{
            players ++;
        }
        valuesobj[1].GetComponent<TMPro.TextMeshProUGUI>().text = ""+players;
    }
    
}
