using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lintuspwan : MonoBehaviour
{
    public GameObject joutsen;
    public float spawnRate = 0.5f;

    private void Start()
    {
        InvokeRepeating("spawn", Random.Range(0,3),spawnRate);
    }

    void spawn()
    {
        Instantiate(joutsen,transform.position,transform.localRotation);
    }
}
