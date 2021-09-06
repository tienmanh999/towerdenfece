using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CompletedLevel : MonoBehaviour
{
    public string nextLevel = "Level02";
    public Scenefader fader;
    public int levelToUnclock;

    public void Continue()
    {
        PlayerPrefs.SetInt("levelWon", levelToUnclock);
        fader.FadeTo(nextLevel);
    }
    public void Menu()
    {
        PlayerPrefs.SetInt("levelWon", levelToUnclock);
        fader.FadeTo("mainMenu");
    }

}
