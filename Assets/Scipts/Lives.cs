using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class Lives : MonoBehaviour
{
    public Text textLives;

    // Update is called once per frame
    void Update()
    {
        textLives.text = "Lives:" + PlayerStart.Lives.ToString();
    }
}
