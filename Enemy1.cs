using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    public float Speed = 5;
    public float GroundDist = 2;
    public float WallDist = 1;
    private bool MovingRight = true;
    public LayerMask TurnAway;
    public Transform GroundDetection;
  //  public int MaxHealth = 100;
  //  public int CurrHealth;
  //  public HealthBar healthbar;

    void Start()
    {
    //        CurrHealth = MaxHealth;
    //        healthbar.setMaxHealth(MaxHealth);
    }


    void Update()
    {
        transform.Translate(Vector2.right * Speed * Time.deltaTime);
        RaycastHit2D GroundInfo = Physics2D.Raycast(GroundDetection.position, Vector2.down, GroundDist);
        RaycastHit2D WallInfo = Physics2D.Raycast(GroundDetection.position, Vector2.right, WallDist, TurnAway);
        if (!GroundInfo.collider || WallInfo.collider)
        {
            if(MovingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                MovingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                MovingRight = true;
            }
        }


      //  if (CurrHealth <= 0)
      //  { 
      //      Destroy(gameObject); 
      //  }
        if (gameObject.transform.position.y < -7)
        {
            Destroy(gameObject);
        }

    }
  //  public void TakeDamage(int damage)
  //  {
  //      CurrHealth -= damage;
  //      healthbar.setHealth(CurrHealth);
  //  }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        var player = collision.collider.GetComponent<PlayerAttribs>();
        if (player)
        {
            player.TakeDamage(33);
        }
    }
}

