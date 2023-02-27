using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DusmanKontrol : MonoBehaviour
{
    int maxCan = 100;
    public int can;
    public Image healthBar;
    [SerializeField] Animator animator;
    public SpriteRenderer sp;
    public float idleTime = 3f;
    public Transform AttackPointTransform;
    public KameraKontrol kamera;

    public float hiz = 5f;
    int yon = -1;

    private void Update()
    {
        healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, ((float)can / (float)maxCan), Time.deltaTime*3);

        if (gameObject.CompareTag("Rat"))
        {
            gameObject.transform.Translate(yon * hiz * Time.deltaTime, 0, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Engel") || collision.gameObject.CompareTag("Rat"))
        {
            if (yon == -1)
            {
                yon = 1;
                sp.flipX = true;
                //Fare sola döndüðünde diþinden hasar almamýz için diþ pozisyonu düzenlemesi
                Vector3 sol;
                sol = new Vector3((float)0.13,(float) -0.06, (float)0.01);
                AttackPointTransform.localPosition = sol; 

            }
            else if(yon == 1)
            {
                yon = -1;
                sp.flipX = false;
                //Fare saða döndüðünde diþinden hasar almamýz için diþ pozisyonu düzenlemesi
                Vector3 sag;
                sag = new Vector3((float)-0.175, (float)-0.06, (float)0.01);
                AttackPointTransform.localPosition = sag;
            }
        }
    }

    void Start()
    {
        can = maxCan;
    }

    public void HasarAl(int damage)
    {
        can -= damage;
        Debug.Log("Dusman "+ damage+" hasar aldi");

        if (can <= 0)
        {
            Oldur();
        }
    }

    void Oldur()
    {
        Debug.Log("Dusman Oldu!");

        //Ölüm Animasyonu
        animator.SetBool("isDeath", true);

        //Düþmaný sahneden yok et
        Destroy(gameObject, 0.75f);
        
    }
}
