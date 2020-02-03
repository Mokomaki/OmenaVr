using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    public Transform bulletSpawn;
    public GameObject bullet;
    public float bulletSpeed = 1;
    public GameObject hand;
    public GameObject[] weaponsHand;
    public GameObject[] weapons;
    public float grabDistance;
    int EQUIPPED = 500;
    public int gunIndex = 3;

    private void Update()
    {
        if(EQUIPPED==500)
        {
            if (!hand.activeSelf)
            {
                hand.SetActive(true);
            }
        }
        else
        {
            if(hand.activeSelf)
            {
                hand.SetActive(false);
            }
        }
    }

    public void OnTrigger()
    {
        if(EQUIPPED==gunIndex)
        {
            GameObject gm = Instantiate(bullet,bulletSpawn);
            gm.GetComponent<Rigidbody>().AddForce(Vector3.forward * bulletSpeed, ForceMode.Impulse);
        }
    }

    public void OnGrab()
    {
        int lowestIndex=200;
        float lowest = 100000;
        for(int i = 0; i<weapons.Length;i++)
        {
            if(Vector3.Distance(transform.position, weapons[i].transform.position)<lowest&&i!=EQUIPPED)
            {
                lowest = Vector3.Distance(transform.position, weapons[i].transform.position);
                lowestIndex = i;
            }
        }
        if (lowest < grabDistance && weapons[lowestIndex].activeSelf)
        {
            if (EQUIPPED != 500)
            {
                weapons[EQUIPPED].transform.position = transform.position;
                weapons[EQUIPPED].transform.rotation = transform.rotation;
                weapons[EQUIPPED].SetActive(true);
                weaponsHand[EQUIPPED].SetActive(false);
            }
            weapons[lowestIndex].SetActive(false);
            weaponsHand[lowestIndex].SetActive(true);
            EQUIPPED = lowestIndex;
        }
    }

    public void OnUnGrab()
    {
        /*
        int lowestIndex = 200;
        float lowest = 100000;
        for (int i = 0; i < weapons.Length; i++)
        {
            if (Vector3.Distance(transform.position, weapons[i].transform.position) < lowest && i != EQUIPPED)
            {
                lowest = Vector3.Distance(transform.position, weapons[i].transform.position);
                lowestIndex = i;
            }
        }*/
        if (EQUIPPED != 500)
        {
            weapons[EQUIPPED].transform.position = transform.position;
            weapons[EQUIPPED].transform.rotation = transform.rotation;
            weapons[EQUIPPED].SetActive(true);
            weaponsHand[EQUIPPED].SetActive(false);
            EQUIPPED = 500;
        }
    }
}