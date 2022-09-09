using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerAttribs : MonoBehaviour
{
    public int MaxHealth =100;
    public static int CurrHealth;
    public HealthBar healthbar;
    public PlayerMovement Player;
    public Level_changer LC;
    void Start()
    {
        CurrHealth = MaxHealth;
        healthbar.setMaxHealth(MaxHealth);
    }

    
    void Update()
    {
        if (CurrHealth <= 0)
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Player.animator.SetBool("isDead", true);
            StartCoroutine(WaitFirst());
            Destroy(gameObject);
            StartCoroutine(WaitFirst());
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (gameObject.transform.position.y < -7)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            TakeDamage(20);
        }

    }

    public IEnumerator WaitFirst()
    {
        yield return new WaitForSeconds(3f);

    }
    

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Teleporter")
        {
            LC.FadetoLevel();
        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            TakeDamage(5);
        }
        if (collision.transform.tag == "Spikes")
        {
            TakeDamage(20);
        }
        if (collision.transform.tag == "Boulder")
        {
            TakeDamage(105);
        }
        if (collision.transform.tag == "Debris")
        {
            TakeDamage(5);
        }
    }

    public void TakeDamage(int damage)
    {
        CurrHealth -= damage;
        healthbar.setHealth(CurrHealth);
    }
        
}
