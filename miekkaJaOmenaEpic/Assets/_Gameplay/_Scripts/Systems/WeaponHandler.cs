using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    public Transform bulletSpawn;           //declearing variables
    public GameObject bullet;
    float bulletSpeed = 80;
    public GameObject hand;
    public GameObject[] weaponsHand;
    public GameObject[] weapons;
    public float grabDistance;
    int EQUIPPED = 500;
    public int gunIndex = 2;

    private void Update()
    {
        if(EQUIPPED==500)                   //if nothing is equipped hands are visible
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
        //Debug.Log("OnTrigger");
        if(EQUIPPED==gunIndex)                      //if the gun is equipped
        {
            //Debug.Log("same index");
            GameObject gm = Instantiate(bullet,bulletSpawn.transform.position,bulletSpawn.transform.rotation);      //instansiate bullet at bullet spawn location and rotation
            gm.GetComponent<Rigidbody>().AddForce(bulletSpeed*gm.transform.forward, ForceMode.Impulse);                  //add force to bullet
            Destroy(gm,3);
        }
    }

    public void OnGrab()
    {
        int lowestIndex=200;                        //declare variables
        float lowest = 100000;                      //make lowet be far away

        for(int i = 0; i<weapons.Length;i++)        //loop through weapons on the scene
        {
            if(Vector3.Distance(transform.position, weapons[i].transform.position)<lowest&&i!=EQUIPPED)         //if weapons distance is lower than the previuos distance and is not equipped
            {
                lowest = Vector3.Distance(transform.position, weapons[i].transform.position);                   //make lowest ditance that distance
                lowestIndex = i;                                                                                //save the index of the closest weapon
            }
        }
        if (lowest < grabDistance && weapons[lowestIndex].activeSelf)                                           //if the lowest distance is within grabbing distance and is active
        {
            if (EQUIPPED != 500)                                                //if we have something equipped
            {
                weapons[EQUIPPED].transform.position = transform.position;      //set the prop weapons location 
                weapons[EQUIPPED].transform.rotation = transform.rotation;
                weapons[EQUIPPED].SetActive(true);                              //activate the prop
                weaponsHand[EQUIPPED].SetActive(false);                         //deactivate the weapon in hand
            }
            weapons[lowestIndex].SetActive(false);                              //disable the prop of the new weapon
            weaponsHand[lowestIndex].SetActive(true);                           //activate the weapon in hand
            EQUIPPED = lowestIndex;                                             //mark EQUIPPED as the new weapons index
        }
    }

    public void OnUnGrab()
    {
        if (EQUIPPED != 500)                        //if someting is equipped
        {
            weapons[EQUIPPED].transform.position = weaponsHand[EQUIPPED].transform.position;        //set the props location to the weapons loaction
            weapons[EQUIPPED].transform.rotation = weaponsHand[EQUIPPED].transform.rotation;
            if (EQUIPPED == gunIndex)                                                               //if the prop is a gun we have to rotate it
            {
                weapons[EQUIPPED].transform.Rotate(-90f, -90f, 0);
            }
            weapons[EQUIPPED].SetActive(true);          //activate the prop
            weaponsHand[EQUIPPED].SetActive(false);     //deactivate the weapon in hand
            EQUIPPED = 500;                             //mark equipped as empty
        }
    }

}

