using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class ValueTrigger : MonoBehaviour
{
    public Image fillImage;
    private bool isCoolDown;
    private float coolDownSec = 1f;
    

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag($"Player"))
        {
            if (transform.childCount <= 0) return;
            if (isCoolDown) return;
            ValueController.instance.StackObjet(transform.GetChild(0).gameObject, ValueController.instance.valuableList.Count - 1);
            transform.GetChild(0).parent = ValueController.instance.transform;
            isCoolDown = true;
            coolDownTest();
            //StartCoroutine(ValueController.instance.StackValues(gameObject, transform.GetChild(0).gameObject, ValueController.instance.valuableList.Count - 1, 1f));
        }
    }

    private void coolDownTest()
    {
        if (isCoolDown)
        {
            fillImage.fillAmount -= 1 / coolDownSec * Time.deltaTime;
            if (fillImage.fillAmount <= 0)
            {
                fillImage.fillAmount = 0;
                isCoolDown = false;
            }
        }
    }
    
}