using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DESTROYEROFFRUIT : MonoBehaviour
{
    public Omena_spawner os;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("omena")|| other.gameObject.CompareTag("paaryna"))
        {
            Destroy(other.gameObject);
        }
    }
}
