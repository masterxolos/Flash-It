using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CamMovementForAd : MonoBehaviour
{
   
    void Start()
    {
        gameObject.transform.DOMove(new Vector3(-0.7f, 9.5f, 9.8f), 2);
        gameObject.transform.DORotate(new Vector3(18.729f, 115.1f, 1.177f), 2);
    }

   
    void Update()
    {
        
    }
}
