using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Omena_spawner : MonoBehaviour
{
    [SerializeField] GameObject[] prefabs;
    [SerializeField] GameObject[] OnDestroyEffect_SLICE;
    [SerializeField] GameObject[] OnDestroyEffect_SMASH;
    [SerializeField] Transform tynnyri;
    [SerializeField] float cooldownmin = 0.7f;
    [SerializeField] float cooldownmax = 0.7f;
    [SerializeField] float spawnForceUPmin = 3f;
    [SerializeField] float spawnForceUPmax = 3f;
    [SerializeField] float spawnForceFORWARDmin = 3f;
    [SerializeField] float spawnForceFORWARDmax = 3f;
    [SerializeField] float duration = 7f;
    [SerializeField] float RotationSpeed = 50f;
    [SerializeField] float explosionDuration = 4f;
    
    bool canSpawn = true;

    void Update()
    {
        if (canSpawn)
        {
            StartCoroutine(SPAWN(Random.Range(cooldownmin,cooldownmax)));
        }
    }
    IEnumerator SPAWN(float cd)
    {
        canSpawn = false;

        GameObject obj = Instantiate(prefabs[Random.Range(0,prefabs.Length)],transform.position,transform.rotation);
        Rigidbody rb = obj.GetComponent<Rigidbody>();

        Vector3 forwardForce = -Vector3.forward * Random.Range(spawnForceFORWARDmin, spawnForceFORWARDmax);
        Vector3 upForce = Vector3.up * Random.Range(spawnForceUPmin, spawnForceUPmax);
        Vector3 torqueForce = new Vector3(Random.Range(-5, 5) * RotationSpeed, Random.Range(-5, 5) * RotationSpeed, Random.Range(-5, 5) * RotationSpeed);

        rb.AddForce(forwardForce + upForce, ForceMode.Impulse);
        rb.AddTorque(torqueForce, ForceMode.Impulse);

        yield return new WaitForSeconds(cd);
        canSpawn = true;
    }

    public void DestroyApple(GameObject appleboi,bool smash)
    {
        if(smash)
        {
            if(appleboi.CompareTag("omena"))
            {
                GameObject explo = Instantiate(OnDestroyEffect_SMASH[0], appleboi.transform.position, appleboi.transform.rotation);
                Destroy(explo, explosionDuration);
            }
            if (appleboi.CompareTag("paaryna"))
            {
                GameObject explo = Instantiate(OnDestroyEffect_SMASH[1], appleboi.transform.position, appleboi.transform.rotation);
                Destroy(explo, explosionDuration);
            }

        }
        else
        {
            if (appleboi.CompareTag("omena"))
            {
                GameObject explo = Instantiate(OnDestroyEffect_SLICE[0], appleboi.transform.position, Quaternion.identity);
                Rigidbody[] allChildren = explo.GetComponentsInChildren<Rigidbody>();
                foreach (Rigidbody child in allChildren)
                {
                    child.velocity = new Vector3(appleboi.GetComponent<Rigidbody>().velocity.x, 0/*appleboi.GetComponent<Rigidbody>().velocity.y*/,     appleboi.GetComponent<Rigidbody>().velocity.z);
                }
                Destroy(explo, explosionDuration);
            }
            if (appleboi.CompareTag("paaryna"))
            {
                GameObject explo = Instantiate(OnDestroyEffect_SLICE[1], appleboi.transform.position, Quaternion.identity);
                Rigidbody[] allChildren = explo.GetComponentsInChildren<Rigidbody>();
                foreach (Rigidbody child in allChildren)
                {
                    child.velocity = new Vector3(appleboi.GetComponent<Rigidbody>().velocity.x, 0/*appleboi.GetComponent<Rigidbody>().velocity.y*/, appleboi.GetComponent<Rigidbody>().velocity.z);
                }
                Destroy(explo, explosionDuration);
            }

        }

        Destroy(appleboi);
    }
}
