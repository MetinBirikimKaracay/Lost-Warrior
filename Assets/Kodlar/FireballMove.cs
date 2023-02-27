using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballMove : MonoBehaviour
{
    public float hiz = 300f;
    Rigidbody2D rb;
    public Vector3 yon;
    public float limit = 2f;
    [SerializeField] Animator animator;
    public int kontrol = 0;
    public AudioSource patlama;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(yon.normalized * hiz);
    }

    void Update()
    {
        limit -= Time.deltaTime;
        if (limit <= 0f)
        {
            Destroy(gameObject);
        }

        if(kontrol == 1)
        {
            Vector3 yon2;
            yon2 = new Vector3((float)0, (float)0, (float)0);
            //alternatif
            Vector2 move;
            move = new Vector2((float)1, (float)0);
            rb.velocity = move * 0;
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Zemin"))
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("CannonBall"))
        {
            kontrol = 1;
            animator.SetBool("isCrash", true);
            patlama.Play();

            Destroy(gameObject, 0.75f);

        }
    }
}
