using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    [SerializeField] GameObject Panel;

    public void PauseGame()
    {
        Panel.SetActive(true);
        Time.timeScale = 0f;
       
    }
    public void resume()
    {
        Panel.SetActive(false);
        Time.timeScale = 1f;
       
    }
    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
