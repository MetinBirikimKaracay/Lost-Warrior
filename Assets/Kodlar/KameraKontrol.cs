using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KameraKontrol : MonoBehaviour
{
    //Karakterin Can barýndaki sayýyý ve topladýðý elmaslarýn sayýsýný yazdýrmak için tanýmladýðým TextMeshler
    public TextMeshProUGUI scoreBoard;
    public TextMeshProUGUI health;
    public TextMeshProUGUI fireBall;

    public int elmas;
    public int can;
    public int fire;

    void Start()
    {
        elmas = PlayerPrefs.GetInt(nameof(elmas));
        fire = PlayerPrefs.GetInt(nameof(fire));
    }

    void Update()
    {
        scoreBoard.text = elmas.ToString();
        PlayerPrefs.SetInt(nameof(elmas), elmas);
        health.text = can.ToString();
        fireBall.text = fire.ToString();
        PlayerPrefs.SetInt(nameof(fire), fire);
    }
}
