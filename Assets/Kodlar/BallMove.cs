using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour
{
    public float hiz = 10f;
    //public Vector3 yon;
    public float limit = 2f;

    void Start()
    {
        //yeni ballprefab oluþtur içine topkontrol scriptini at yoksa olmayacak gibi...
        
        //Debug.Log(yon.x);
        Rigidbody2D rigidbody2d = gameObject.GetComponent<Rigidbody2D>();
        //rigidbody2d.AddForce(yon.normalized* hiz);
        //rigidbody2d.AddForce( * hiz);
        rigidbody2d.velocity = transform.right * hiz;
    }

    // Update is called once per frame
    void Update()
    {
        limit -= Time.deltaTime;
        if(limit <= 0f)
        {
            Destroy(gameObject);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Zemin"))
        {
            Destroy(gameObject);
        }
    }


}
