using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DurdurmaKontrol : MonoBehaviour
{
    public static bool durduMu = false;
    public GameObject pauseMenu;
    public GameObject panel;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (durduMu)
            {
                DevamEt();
            }
            else
            {
                Durdur();
            }
        }
    }

    public void DevamEt()
    {
        pauseMenu.SetActive(false);
        panel.SetActive(false);
        Time.timeScale = 1f;
        durduMu = false;    
    }

    public void Durdur()
    {
        pauseMenu.SetActive(true);
        panel.SetActive(true);
        Time.timeScale = 0f;
        durduMu = true;
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MenuScene");
    }
}
