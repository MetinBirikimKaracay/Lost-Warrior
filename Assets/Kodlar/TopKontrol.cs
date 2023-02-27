using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopKontrol : MonoBehaviour
{
    public GameObject cannon;
    public float cooldown = 3f;
    public Transform spawnerTransform;
    [SerializeField] SpriteRenderer spriteRenderer;
    public GulleKontrol gulle;
    public OyunKontrol oyunKontrol;

    void Start()
    {

    }

    void Update()
    {

        if (cooldown >= 0f)
        {
            cooldown -= Time.deltaTime;
        }
        CannonSpawner();
        
    }

    public void CannonSpawner()
    {
        if (cooldown <= 0f)
        {
            Instantiate(cannon, spawnerTransform.position, spawnerTransform.rotation);
            cooldown = 3f;
        }
    }
}
