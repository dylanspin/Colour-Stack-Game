using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class uitController : MonoBehaviour
{
    public GameObject[] players;

    public void setAmountOfPlayers(int amount)
    {
        for(int i=0; i<amount; i++)
        {
            players[i].SetActive(true);
        }
    }

    public void setLifes(int player, int amount)
    {
        if(amount > 0)
        {
            players[player].transform.GetChild(0).transform.GetComponent<TMPro.TextMeshProUGUI>().text = ""+amount;
        }else{
            players[player].transform.GetChild(0).transform.GetComponent<TMPro.TextMeshProUGUI>().text = ""+0;
        }
    }       

    public void setpoints(int player, int amount)
    {
        players[player].transform.GetChild(2).transform.GetComponent<TMPro.TextMeshProUGUI>().text = ""+amount;
    }
}
