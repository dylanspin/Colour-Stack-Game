using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttons : MonoBehaviour
{
    
    //moet op deze manier voor de buttons

    void playSound()
    {
        this.transform.root.transform.GetComponent<AudioSource>().Play();
    }

    void playAnim()
    {
        this.transform.GetComponent<Animation>().Play();
    }

    public void doAnimations()
    {
        playSound();
        playAnim();
    }

    public void goMain()
    {
        doAnimations();
        Invoke("loadMain",0.15f);
    }

    public void goMatchOptions()
    {
        doAnimations();
        Invoke("loadmatch",0.15f);
    }

    public void StartGame()
    {
        doAnimations();
        Invoke("loadGame",0.15f);
    }

    public void goOptions()
    {
        doAnimations();
        Invoke("loadOptions",0.15f);
    }

    public void restartGame()
    {
        SceneManager.LoadScene(2);
    }

    public void quitGame()
    {
        Application.Quit();
    }

    void loadmatch()
    {
        SceneManager.LoadScene(1);
    }

    void loadGame()
    {
        SceneManager.LoadScene(2);
    }

    void loadMain()
    {
        SceneManager.LoadScene(0);
    }

    void loadOptions()
    {
        SceneManager.LoadScene(3);
    }
}
