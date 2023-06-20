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

    private void Sale()
    {
        SellAreaImage.color = Color.white;
        SellAreaText.color = Color.white;
        CheckMoney();
    }

    private static void CheckMoney()
    {
        Debug.Log("Check Money");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (isSaled) return;
            Sale();
            isSaled = true;
        }
    }
}