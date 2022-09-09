using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinCollector : MonoBehaviour
{
    private int Coins = 0;
    public TextMeshProUGUI CoinCounter;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Coin")
        {
            Coins++;
            CoinCounter.text = Coins.ToString();
            Destroy(collision.gameObject);
        }
    }

}
