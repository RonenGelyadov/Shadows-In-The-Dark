using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    Scene scene;
    public GameObject pauseMenu;
    public GameObject hud;
    public GameObject gameOver;
    bool isPaused;

    void Start()
    {
        Time.timeScale = 1;
        scene = SceneManager.GetActiveScene();
        hud.SetActive(true);
        pauseMenu.SetActive(false);
        gameOver.SetActive(false);

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }

        if (PlayerEngine.health <= 0)
        {           
            gameOver.SetActive(true);
            pauseMenu.SetActive(false);
            hud.SetActive(false);
            Time.timeScale = 0;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void MenuButtons(string action)
    {
        if (action == "Start")
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(sceneName: "Game");
        }

        if (action == "Quit")
        {
            Application.Quit();
        }

        if (action == "Menu")
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("Menu");
        }
    }

    void Pause()
    {
        if (!isPaused)
        {
            isPaused = true;
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
            hud.SetActive(false);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            isPaused = false;
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
            hud.SetActive(true);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
