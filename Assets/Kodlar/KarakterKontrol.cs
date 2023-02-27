using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class KarakterKontrol : MonoBehaviour
{
    int maxCan = 100;
    public int can;
    public Image healthBar;
    public float animTime = 0.3f;
    private float hareketYonu;
    [SerializeField] private float hiz,ziplamaGucu;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] Animator animator;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] AudioSource audioSource;
    public AudioSource ziplamaSesi;
    public AudioSource kosmaSesi, saldiriSesi, olumSesi;
    public bool yerdeMi;
    public Transform spawnerTransform;
    public OyunKontrol oyunKontrol;
    public KameraKontrol kamera;
    public bool hasar = false;
    public GameObject fireballPrefab;
    public Transform attackPoint;
    float sleep = 3f;

    private void Awake()
    {

    }

    void Start()
    {
        can = maxCan;
    }

    void Update()
    {
        if(can >= 0)
        {
            kamera.can = can;
        }
        
        healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, ((float)can / (float)maxCan), Time.deltaTime * 3);

        if (can <= 0)
        {
            sleep -= Time.deltaTime;
            Oldur();
        }

        if(hasar)
        {
            Hurt();
        }

        BallSpawner();

        if (Input.GetKeyDown(KeyCode.Space) && yerdeMi == true && can > 0)
        {
            Zipla();
        }

        if (hareketYonu == 0)  //duruyor
        {
            animator.SetBool("isRunning", false);
        }
        else
        {
            animator.SetBool("isRunning", true);
        }

        if (Input.GetKeyDown(KeyCode.A) && can > 0)
        {
            spriteRenderer.flipX = true;
            kosmaSesi.mute = false;
            kosmaSesi.Play();
            saldiriSesi.mute = true;
            //Kýlýç Menzilini sola alma
            Vector3 sol;
            sol = new Vector3((float)-0.36, (float)0.72, (float)0.00);
            attackPoint.localPosition = sol;
        }
        else if (Input.GetKeyDown(KeyCode.D) && can > 0)
        {
            spriteRenderer.flipX = false;
            kosmaSesi.mute = false;
            kosmaSesi.Play();
            saldiriSesi.mute = true;
            //Kýlýç Menzilini saða alma
            Vector3 sag;
            sag = new Vector3((float)0.36, (float)0.72, (float)0.00);
            attackPoint.localPosition = sag;
        }

        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            kosmaSesi.mute = true;
        }

    }
    private void FixedUpdate()
    {
        if(can > 0)
        {
            hareketYonu = Input.GetAxis("Horizontal");
            transform.Translate(new Vector3(hareketYonu * hiz * Time.fixedDeltaTime, 0));
        }
        
    }

    private void Zipla()
    {
        rb.AddForce(Vector2.up * ziplamaGucu,ForceMode2D.Impulse);
        animator.SetBool("isJumping", true);
        ziplamaSesi.Play();
        kosmaSesi.mute = true;

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (yerdeMi == true)
        {
            animator.SetBool("isJumping", false);
        }

        if (collision.CompareTag("Gem"))
        {
            kamera.elmas += 1;
        }

        if (collision.CompareTag("Fb"))
        {
            kamera.fire += 1;
        }

        if (collision.CompareTag("Meat"))
        {
            int canFarký = can;
            if (can < 100)
            {
                if(can>80)
                {
                    canFarký = 100 - can;
                    can += canFarký;
                } 
                else if(can <= 80)
                {
                    can += 20;
                }
                Destroy(collision.gameObject);
            }
        }

        if (collision.CompareTag("CannonBall") || collision.CompareTag("Tuzak"))
        {
            can -= 5;
            hasar = true;
        }

        if (collision.CompareTag("Diþ") || collision.CompareTag("Frog"))
        {
            can -= 10;
            hasar = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Testere"))
        {
            can -= 1;
            hasar = true;
        }
    }

    public void Hurt()
    {
        animator.SetBool("isTakeDamage", true);
        animTime -= Time.deltaTime;
        if (animTime <= 0)
        {
            animator.SetBool("isTakeDamage", false);
            animTime = 0.3f;
            hasar = false;
        }
        if (can == 0)
        {
            olumSesi.Play();
        }
    }

    public void Oldur()
    {
        animator.SetBool("isDeath", true);
        if (sleep <= 0)
        {
            SceneManager.LoadScene("DeathScene");
        }
        
    }

    public void BallSpawner()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1) && kamera.fire > 0)
        {
            kamera.fire -= 1;
            Instantiate(fireballPrefab, spawnerTransform.position, transform.rotation);
        }
    }
}
