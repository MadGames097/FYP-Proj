using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_V2 : MonoBehaviour
{
    public float Speed = 20f;
    public Rigidbody2D RB2D;
    public int damage = 30;
    public float distance = 4f;
    public LayerMask WhatIsSolid;
    public GameObject ImpactEffect;

    void Start()
    {
        RB2D.velocity = transform.right * Speed;
    }
    void Update()
    {
        RaycastHit2D HitInfo = Physics2D.Raycast(transform.position, transform.up, distance, WhatIsSolid);
        if (HitInfo.collider)
        {
            if (HitInfo.collider.CompareTag("Enemy"))
            {
                HitInfo.collider.GetComponent<HaveHealth>().TakeDamage(damage);
                //    void OnCollisionEnter2D(Collision2D collision)
                //    {
                //       var Enummy = collision.collider.GetComponent<Enemy1>();
                //       if (Enummy)
                //       {
                //           Enummy.TakeDamage(33);
                //       }
                //   }

            }
            if (HitInfo.collider.CompareTag("BOSS"))
            {
                HitInfo.collider.GetComponent<BossHealth>().TakeDamage(15);
            }
            Instantiate(ImpactEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
   // private void OnTriggerEnter2D(Collider2D collision)
   // {
    //    Enemy1 enemy = collision.GetComponent<Enemy1>();
    //    if (enemy)
    //    {
    //        enemy.TakeDamage(damage);
    //    }
    //    Destroy(gameObject);
    //}

}
