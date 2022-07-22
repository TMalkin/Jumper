using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CoinCounter : MonoBehaviour
{
    public TMP_Text text;
    public Movement m;
    public int coins = 0;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        GameObject extra = GameObject.Find("CoinManager");
        if(extra != gameObject)
        Destroy(extra);
    }

    // Update is called once per frame
    void Update()
    {
        text = GameObject.FindWithTag("CoinText").GetComponent<TMP_Text>();
        text.text = "Coins: " + coins;
    }
}
