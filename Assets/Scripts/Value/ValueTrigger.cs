using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValueTrigger : MonoBehaviour
{
    public static ValueTrigger instance;

    public void Start()
    {
        instance = this;
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag($"Player"))
        {
            if (transform.childCount <= 0) return;
            ValueController.instance.StackObjet(transform.GetChild(0).gameObject,
                ValueController.instance.valuableList.Count - 1);
            transform.GetChild(0).parent = ValueController.instance.transform;
            //StartCoroutine(ValueController.instance.StackValues(gameObject, transform.GetChild(0).gameObject, ValueController.instance.valuableList.Count - 1, 1f));
        }
    }
}