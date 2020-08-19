using System.Collections;
using System.Collections.Generic;
using System.Security.Permissions;
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
        if(otherCol.gameObject.CompareTag("terrain"))
        {
            //Add decal on hit
        }
        if (otherCol.gameObject.CompareTag("omena")|| otherCol.gameObject.CompareTag("paaryna"))
        {
            spawner.DestroyApple(otherCol.gameObject,Smash);
        }
        else
        if(otherCol.gameObject.CompareTag("JOUTSEN"))                       //if posautin hits a joutsen
        {
            otherCol.gameObject.GetComponentInChildren<ParticleSystem>(true).gameObject.SetActive(true);
            Destroy(otherCol.gameObject.GetComponentInChildren<ParticleSystem>().gameObject, 10);               //taikaa
            for(int i = 0; i<otherCol.transform.childCount;i++)
            {
                if(!otherCol.transform.GetChild(i).GetComponent<ParticleSystem>())
                {
                    Destroy(otherCol.transform.GetChild(i).gameObject);
                }
            }
            otherCol.transform.DetachChildren();
            Destroy(otherCol.transform.gameObject);
        }
        if(gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        
    }
}