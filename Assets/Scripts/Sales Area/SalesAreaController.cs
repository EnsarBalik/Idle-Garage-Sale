using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class SalesAreaController : MonoBehaviour
{
    public BuySalesArea BuySalesArea;

    public Transform place;

    public bool occupied;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !occupied && BuySalesArea.isSold)
        {
            var valuableList = ValueController.instance.valuableList;
            if (valuableList.Count > 1)
            {
                valuableList[^1].transform.DOJump(place.position, 0.5f, 0, 0.5f);
                valuableList[^1].transform.parent = transform;
                valuableList[^1].transform.rotation = quaternion.identity;
                valuableList.Remove(valuableList[^1]);
                occupied = true;
            }
        }
    }
}