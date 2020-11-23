using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pullo : MonoBehaviour
{
    [SerializeField] GameObject korge;

    public static bool hasCork = true;



    private void FixedUpdate()
    {
        if(!hasCork&&!korge.activeSelf)
        {
            korge.SetActive(false);
        }
    }

    public static void DisableCork()
    {
        hasCork = false;
    }
}