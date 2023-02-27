using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class OyunKontrol : MonoBehaviour
{
    public TextMeshProUGUI scoreBoard;
    public int elmas;
    public int can;

    private void Start()
    {
        if(SceneManager.GetActiveScene().buildIndex == 5)
        {
            scoreBoard.text = (PlayerPrefs.GetInt(nameof(elmas)) * 128).ToString();
        }
        
    }

    void Update()
    {

    }

}
