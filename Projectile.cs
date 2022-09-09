using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float Speed;
    public float LifeTime;
    public GameObject DestroyEffect;
    public LayerMask Solid;
    public float distance;
    public int damage;

    void Start()
    {
        Invoke("DestroyProjectile", LifeTime);
    }

    
    void Update()
    {
        RaycastHit2D HitInfo = Physics2D.Raycast(transform.position, transform.up, distance, Solid);
        transform.Translate(transform.up * Speed * Time.deltaTime);
        if (HitInfo.collider)
        {
            if (HitInfo.collider.CompareTag("Enemy"))
            {
                // HitInfo.collider.GetComponent<Enemy1>().TakeDamage(damage);
                //    void OnCollisionEnter2D(Collision2D collision)
                //    {
                //       var Enummy = collision.collider.GetComponent<Enemy1>();
                //       if (Enummy)
                //       {
                //           Enummy.TakeDamage(33);
                //       }
                //   }

            }
            Destroy(gameObject);
        }
    }
    void DestroyProjectile()
    {
        Instantiate(DestroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
