using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellCharge : MonoBehaviour
{
    public float Offset;
    public GameObject Projectile;
    public Transform ShotPoint;
    private float TimeBtwShots;
    public float StartTimeBtwShots;
    private void Update()
    {
        Vector3 Difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float RotZ = Mathf.Atan2(Difference.y, Difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, RotZ + Offset);
        //    Vector2 SpellPos = transform.position;
        //    Vector2 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //    Vector2 Direction = MousePos - SpellPos;
        //    transform.right = Direction;

        if (TimeBtwShots <= 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(Projectile, ShotPoint.position, transform.rotation);
                TimeBtwShots -= StartTimeBtwShots;
            }
        }
        else
        {
            TimeBtwShots -= Time.deltaTime;
        }
    }
    
}
