using System.Collections;
using System.Collections.Generic;
using System.Security.Permissions;
using UnityEngine;

public class posautin : MonoBehaviour
{
    public Omena_spawner spawner;
    public bool Smash;
    public GameObject decal;

    public Pullo pulloRef;

    void Awake()
    {
        
        spawner = GameObject.FindGameObjectWithTag("spawner").GetComponent<Omena_spawner>();    
    }


    private void OnCollisionEnter(Collision otherCol)
    {

        if (otherCol.gameObject.CompareTag("omena") || otherCol.gameObject.CompareTag("paaryna"))
        {
            spawner.DestroyApple(otherCol.gameObject, Smash);
        }
        else if (otherCol.gameObject.CompareTag("JOUTSEN"))                       //if posautin hits a joutsen
        {
            otherCol.gameObject.GetComponentInChildren<ParticleSystem>(true).gameObject.SetActive(true);
            Destroy(otherCol.gameObject.GetComponentInChildren<ParticleSystem>().gameObject, 10);               //taikaa
            for (int i = 0; i < otherCol.transform.childCount; i++)
            {
                if (!otherCol.transform.GetChild(i).GetComponent<ParticleSystem>())
                {
                    Destroy(otherCol.transform.GetChild(i).gameObject);
                }
            }
            otherCol.transform.DetachChildren();
            Destroy(otherCol.transform.gameObject);
        }
        else if (otherCol.gameObject.CompareTag("korkki"))
        {
            Pullo.DisableCork();
            otherCol.transform.parent = null;
            otherCol.gameObject.GetComponent<Rigidbody>().useGravity = true;
            otherCol.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            otherCol.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * 2, ForceMode.Impulse);
        }
        if(gameObject.CompareTag("Bullet"))
        {
            if (otherCol.gameObject.isStatic)
            {
                GameObject dec = Instantiate(decal, otherCol.GetContact(0).point, Quaternion.identity);
                //dec.transform.rotation = Quaternion.FromToRotation(transform.up, otherCol.GetContact(0).normal);
                dec.transform.Translate(0, 0.01f, 0);
                dec.GetComponent<decal>().Orient();
            }
            Destroy(gameObject);

        }
    }
    private void OnCollisionExit(Collision collision)
    {
        
    }
}