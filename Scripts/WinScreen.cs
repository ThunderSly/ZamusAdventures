using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    public GameObject YouWinUI;
    public void Win() {
        YouWinUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void TitleScreen(){
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void QuitGame(){
        Application.Quit();
    }
}
