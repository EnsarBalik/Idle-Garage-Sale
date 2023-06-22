using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuySalesArea : MonoBehaviour
{
    public SalesAreaController saleArea;
    public TextMeshPro SellAreaText;
    public SpriteRenderer SellAreaImage;
    public bool isSaled;
    public int cost;

    private void Sale(int Cost)
    {
        Cost = cost;
        if (PlayerPrefs.GetInt("myCoin") >= Cost)
        {
            SellAreaImage.color = Color.white;
            SellAreaText.color = Color.white;
            GameManager.instance.SpendMoney(cost);
            isSaled = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (isSaled) return;
            Sale(cost);
        }
    }
}