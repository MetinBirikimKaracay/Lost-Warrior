using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuKontrol : MonoBehaviour
{
    public void playButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void quit()
    {
        Application.Quit();
        Debug.Log("Çýkýþ yapýldý!");
    }

    public void mainMenuButton()
    {
        SceneManager.LoadScene("MenuScene");
        PlayerPrefs.DeleteAll();
    }
}
