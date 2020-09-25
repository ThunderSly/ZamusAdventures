using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool isPaused = false;
    public GameObject pauseMenuUI;
    void Update(){
        if (Input.GetButtonDown("Cancel")){ // esc
            if(isPaused){
                Resume();
            }
            else{
                Pause();
            }
        }
    }
    public void Pause() {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }
    public void Resume() {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void TitleScreen(){
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }


    public void ResumeGame(){
        Resume();
    }

    public void QuitGame(){
        Application.Quit();
    }

}