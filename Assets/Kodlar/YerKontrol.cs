using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YerKontrol : MonoBehaviour
{
    [SerializeField] BoxCollider2D boxCollider2D;
    [SerializeField] KarakterKontrol karakterKontrol;
    [SerializeField] Animator animator;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Zemin"))
        {
            karakterKontrol.yerdeMi = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Zemin"))
        {
            karakterKontrol.yerdeMi = false;
            
        }
    }
}
