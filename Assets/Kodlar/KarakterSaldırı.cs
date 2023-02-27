using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class KarakterSaldırı : MonoBehaviour
{
    public Animator animator;
    public AudioSource saldiriSesi;

    public Transform attackPoint;
    public float menzil = 0.64f;
    public LayerMask enemyLayer;

    public int saldiriHasari = 30;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !(DurdurmaKontrol.durduMu))
        {
            Saldırı();
            saldiriSesi.mute = false;
            saldiriSesi.Play();
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            animator.SetBool("isAttacking", false); // kalkan kaldırmayı eklediğimizde değiştiricez
            saldiriSesi.mute = true;
        }
    }

    void Saldırı()
    {
        //Saldırı animasyonunu aktif eder
        animator.SetBool("isAttacking", true);

        //Menzile giren düşmanı tespit edecek
        Collider2D[] hasar = Physics2D.OverlapCircleAll(attackPoint.position, menzil, enemyLayer);

        //Düşmana vur
        foreach(Collider2D dusman in hasar)
        {
            dusman.GetComponent<DusmanKontrol>().HasarAl(saldiriHasari);
            
            //Debug.Log(dusman.name + " vuruldu");
        }
    
    }

    private void OnDrawGizmosSelected()
    {
        if(attackPoint == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(attackPoint.position, menzil);
    }

}
