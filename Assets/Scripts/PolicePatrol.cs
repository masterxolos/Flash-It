using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class PolicePatrol : MonoBehaviour
{
    public bool boobsAreClosed = true;
    private bool turned = false;

    private void Start()
    {
        StartCoroutine(RotatePolice());
    }

    private void Update()
    {
       
        Debug.Log(turned);
    }

    private IEnumerator RotatePolice()
    {
        while (true)
        {
            if (boobsAreClosed)
            {
                if (turned)
                {
                    gameObject.transform.DORotate(new Vector3(0, 220, 0), 3);
                    yield return new WaitForSeconds(3);
                    
                    
                    turned = false;

                }
                else
                {
                    gameObject.transform.DORotate(new Vector3(0, 100, 0), 3);
                    yield return new WaitForSeconds(3);
                    turned = true;
                }

            }
            else
            {
                gameObject.transform.DORotate(new Vector3(0, 120, 0), 1);
                yield return new WaitForSeconds(2);

            }

            yield return new WaitForSeconds(0.1f);
        }

    }
}
