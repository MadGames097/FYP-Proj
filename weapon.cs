using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{
    public Transform Shotpoint;
    public GameObject Bullet;
    public float TimeToShoot;
    private float CurrTime;

    private void Start()
    {
        CurrTime = TimeToShoot;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && CurrTime <= 0)
        {
            Shoot();
            CurrTime = TimeToShoot;
        }
        else
        {
            CurrTime -= Time.deltaTime;
        }
    }


    void Shoot() 
    {
        Instantiate(Bullet, Shotpoint.position, Shotpoint.rotation);
    }
}
