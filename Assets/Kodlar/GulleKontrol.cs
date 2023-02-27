using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GulleKontrol : MonoBehaviour
{
    Rigidbody2D rb;
    float hiz = 400f;
    public float limit = 2f;
    public Vector3 yon;
    public TopKontrol top;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(yon.normalized * hiz);
    }

    // Update is called once per frame
    void Update()
    {
        //Güllenin oyunda kalma süresi
        limit -= Time.deltaTime;
        if (limit <= 0f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Zemin") || collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("FireBall"))
        {
            Destroy(gameObject);
        }


    }
}
