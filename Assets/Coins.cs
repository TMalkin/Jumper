using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Coins : MonoBehaviour
{
    public static int coins;
    public TMP_Text text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Coins: " + coins;
    }
        void OnTriggerEnter2D(Collider2D coal) {
        if(coal.tag == "Coin") {
            Destroy(coal.gameObject);
            coal.tag = "dot";
            coins = coins+1;
        }
    }
}
