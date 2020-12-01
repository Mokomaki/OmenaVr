using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ruuti : MonoBehaviour
{
    GameObject[] pistoolit = new GameObject[2];
    [SerializeField] float m_threshold = 0.45f;
    void FixedUpdate()
    {
        pistoolit = GameObject.FindGameObjectsWithTag("Pistooli");
        for(int i = 0; i< pistoolit.Length; i++)
        {
            if(pistoolit.Length>0)
            {
                if (Vector3.Distance(pistoolit[i].transform.position,transform.position)<m_threshold)
                {
                    Debug.Log("juuu");
                    if (StaticVariables.s_gunPowederLevel < 3) StaticVariables.s_gunPowederLevel = 3;
                    StaticVariables.s_canShoot = false;
                }
                else
                {
                    StaticVariables.s_canShoot = true;
                }
            }
        }
    }
}
