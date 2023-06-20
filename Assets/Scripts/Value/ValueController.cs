using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using DG.Tweening;

public class ValueController : MonoBehaviour
{
    public static ValueController instance;

    public List<GameObject> valuableList;
    public int value;

    public void Start()
    {
        instance = this;
    }

    public void StackObjet(GameObject other, int index)
    {
        valuableList.Add(other);
        other.transform.rotation = transform.rotation;
        other.GetComponent<Value>().ID = value;
        value++;
        Vector3 newPos = valuableList[index].transform.position;
        newPos.y += 1.3f;
        //other.transform.DOJump(newPos, 1, 1, 0.5f).OnComplete(() => { newPos.y += 1.3f; });
        other.transform.position = newPos;
    }
}