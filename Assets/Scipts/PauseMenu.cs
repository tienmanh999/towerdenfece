using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject UI;
    public Scenefader scenefader;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Toggle();
        }
    }
    public void pause()
    {
        Toggle();
    }
    public void Toggle()
    {
        if (Gamemanager.GameisOver)
            return;
        UI.SetActive(!UI.activeSelf);
        if (UI.activeSelf)
        {
            Time.timeScale = 0f;
        }
        if(UI.activeSelf == false)
        {
            Time.timeScale = 1f;
        }
    }
    public void Retry()
    {
        Time.timeScale = 1f;
        scenefader.FadeTo(SceneManager.GetActiveScene().name);
    }
    public void Menu()
    {
        Toggle();
        scenefader.FadeTo("mainMenu");
        
    }
}
