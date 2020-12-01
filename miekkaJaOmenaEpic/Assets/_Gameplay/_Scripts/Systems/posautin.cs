using System.Collections;
using System.Collections.Generic;
using System.Security.Permissions;
using UnityEngine;

public class posautin : MonoBehaviour
{
    Omena_spawner spawner;
    public bool Smash;

    //To be changed with pullo update
    public Pullo pulloRef;

    void Awake()
    {   
        spawner = GameObject.FindGameObjectWithTag("spawner").GetComponent<Omena_spawner>();    
    }


    private void OnCollisionEnter(Collision otherCol)
    {
        if(otherCol.gameObject.CompareTag("Terrain"))
        {
            //Add decal on hit
        }

        if (otherCol.gameObject.CompareTag("omena") || otherCol.gameObject.CompareTag("paaryna"))
        {
            spawner.DestroyApple(otherCol.gameObject, Smash);
        }
        else if (otherCol.gameObject.CompareTag("korkki"))
        {
            Pullo.DisableCork();
            otherCol.transform.parent = null;
            Rigidbody rb = otherCol.gameObject.GetComponent<Rigidbody>();
            rb.useGravity = true;
            rb.constraints = RigidbodyConstraints.None;
            rb.AddForce(Vector3.up * 2, ForceMode.Impulse);
        }
        else if(gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }
    }
}