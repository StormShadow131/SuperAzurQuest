using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Inventory : MonoBehaviour
{
    public int coinsCount;
    public TMP_Text coinsCountText;

    public static Inventory instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de Inventory dans la scène");
            return;
        }

        instance = this;
    }

    public void AddCoins(int count)
    {
        coinsCount += count;
        coinsCountText.text = coinsCount.ToString();
    }
}
