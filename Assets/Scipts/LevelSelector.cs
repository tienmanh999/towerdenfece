using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    public Scenefader fader;
    public Button[] levelButon;
    void Start()
    {
        int levelWon = PlayerPrefs.GetInt("levelWon", 1);
        for (int i = 0; i < levelButon.Length; i++)
        {
            if(i + 1 > levelWon)
            {
                levelButon[i].interactable = false;
            }
            else if(i + 1 == levelWon)
            {
                levelButon[i].interactable = true;
            }
        }    
    }
    public void Select(string loadLevel) 
    {
        fader.FadeTo(loadLevel);
    }
}
