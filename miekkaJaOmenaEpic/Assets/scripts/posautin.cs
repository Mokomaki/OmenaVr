using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class posautin : MonoBehaviour
{
    public Omena_spawner spawner;
    public bool Smash;

    void Awake()
    {
        spawner = GameObject.FindGameObjectWithTag("spawner").GetComponent<Omena_spawner>();    
    }

    private void OnCollisionEnter(Collision otherCol)
    {

        if (otherCol.gameObject.CompareTag("omena")|| otherCol.gameObject.CompareTag("paaryna"))
        {
            spawner.DestroyApple(otherCol.gameObject,Smash);
        }

    }
}