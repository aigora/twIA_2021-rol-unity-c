using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GamePaused = false;
    public GameObject PauseMenuUI;
    private static bool PauseMenuExists;

    void Start()
    {
        PauseMenuUI.SetActive(false);
        if (!PauseMenuExists)
        {
            PauseMenuExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GamePaused = false;
    }
    void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GamePaused = true;
    }
    public void MainMenu()
    { 
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
        PauseMenuUI.SetActive(false);
        GamePaused = false;
    }
    public void QuitGame()
    {
        Debug.Log("Closes");
        Application.Quit();
    }
}
