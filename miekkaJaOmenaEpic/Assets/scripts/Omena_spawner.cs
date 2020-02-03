using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Omena_spawner : MonoBehaviour
{
    //public List<GameObject> apples = new List<GameObject>();
    public GameObject[] prefabs;
    public GameObject[] OnDestroyEffect_SLICE;
    public GameObject[] OnDestroyEffect_SMASH;
    public Transform tynnyri;
    bool canSpawn = true;
    public float cooldownmin = 0.7f;
    public float cooldownmax = 0.7f;
    public float spawnForceUPmin = 3f;
    public float spawnForceUPmax = 3f;
    public float spawnForceFORWARDmin = 3f;
    public float spawnForceFORWARDmax = 3f;
    public float duration = 7f;
    public float RotationSpeed = 50f;
    public float explosionDuration = 4f;

    public float TS = 1f;

    void Update()
    {
       // Debug.Log(Time.timeScale);
        /*if(Input.GetKeyUp(KeyCode.UpArrow))
        {
            TS += 0.25f;
        }
        if (Input.GetKeyUp(KeyCode.DownArrow)&&Time.timeScale > 0.25f)
        {
            TS -= 0.25f;
        }*/


        Time.timeScale = TS;
        /*
        foreach(GameObject apple in apples)
        {

            Vector3 dir = new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), Random.Range(-5, 5));
            apple.transform.Rotate(dir * RotationSpeed * Time.deltaTime);
        }
        */
        if (canSpawn)
        {
            StartCoroutine(SPAWN(Random.Range(cooldownmin,cooldownmax)));
        }
    }
    IEnumerator SPAWN(float cd)
    {
        canSpawn = false;
        GameObject obj = Instantiate(prefabs[Random.Range(0,prefabs.Length)],transform.position,transform.rotation   );
        obj.GetComponent<Rigidbody>().AddForce((-Vector3.forward * Random.Range(spawnForceFORWARDmin,spawnForceFORWARDmax))+(Vector3.up*Random.Range(spawnForceUPmin,spawnForceUPmax)), ForceMode.Impulse);
        //apples.Add(obj);
        obj.GetComponent<Rigidbody>().AddTorque(new Vector3(Random.Range(-5, 5) * RotationSpeed, Random.Range(-5, 5) * RotationSpeed, Random.Range(-5, 5) * RotationSpeed), ForceMode.Impulse);
        //StartCoroutine(DESTROYAFTERTIME(duration,obj));
        yield return new WaitForSeconds(cd);
        canSpawn = true;
    }
    IEnumerator DESTROYAFTERTIME(float duration,GameObject obj)
    {
        yield return new WaitForSeconds(duration);
        if(obj != null)
        {
            //apples.Remove(obj);
            Destroy(obj);
        } 
    }

    public void DestroyApple(GameObject appleboi,bool smash)
    {
        //apples.Remove(appleboi);
        if(smash)
        {
            if(appleboi.CompareTag("omena"))
            {
                GameObject explo = Instantiate(OnDestroyEffect_SMASH[0], appleboi.transform.position, appleboi.transform.rotation);
                StartCoroutine(delExp(explosionDuration, explo));
            }
            if (appleboi.CompareTag("paaryna"))
            {
                GameObject explo = Instantiate(OnDestroyEffect_SMASH[1], appleboi.transform.position, appleboi.transform.rotation);
                StartCoroutine(delExp(explosionDuration, explo));
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
                StartCoroutine(delExp(explosionDuration, explo));
            }
            if (appleboi.CompareTag("paaryna"))
            {
                GameObject explo = Instantiate(OnDestroyEffect_SLICE[1], appleboi.transform.position, Quaternion.identity);
                Rigidbody[] allChildren = explo.GetComponentsInChildren<Rigidbody>();
                foreach (Rigidbody child in allChildren)
                {
                    child.velocity = new Vector3(appleboi.GetComponent<Rigidbody>().velocity.x, 0/*appleboi.GetComponent<Rigidbody>().velocity.y*/, appleboi.GetComponent<Rigidbody>().velocity.z);
                }
                StartCoroutine(delExp(explosionDuration, explo));
            }

        }

        Destroy(appleboi);
    }

    IEnumerator delExp(float cd, GameObject obj)
    {
        yield return new WaitForSeconds(cd);

            Destroy(obj);

        
    }
}
