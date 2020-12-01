using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    public Transform bulletSpawn;
    public GameObject bullet;
    float bulletSpeed = 80;
    public GameObject hand;
    public GameObject[] weaponsHand;
    public GameObject[] weapons;
    public float grabDistance;
    int EQUIPPED = 500; // index of equipped item 500 is none 
    public int gunIndex = 2;
    [SerializeField] GameObject gunEffect;

    private void Update()
    {
        
        //if nothing is equipped hands are visible

        if (EQUIPPED==500)
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
        //if the gun is equipped shoot 
        if (EQUIPPED==gunIndex && StaticVariables.s_gunPowederLevel>0 && StaticVariables.s_canShoot)
        {
            Destroy(Instantiate(gunEffect, bulletSpawn.position,bulletSpawn.rotation),2);
            GameObject gm = Instantiate(bullet,bulletSpawn.transform.position,bulletSpawn.transform.rotation);      
            gm.GetComponent<Rigidbody>().AddForce(bulletSpeed*gm.transform.forward, ForceMode.Impulse);                
            Destroy(gm,3);
            StaticVariables.s_gunPowederLevel--;
        }
    }

    public void OnGrab()
    {
        int lowestIndex=200;                        //declare variables
        float lowest = 100000;                      //make lowest be far away

        //loop through weapons on the scene
        for (int i = 0; i<weapons.Length;i++)       
        {
            //find closest weapon that is not equipped
            if (Vector3.Distance(transform.position, weapons[i].transform.position)<lowest&&i!=EQUIPPED)         
            {
                lowest = Vector3.Distance(transform.position, weapons[i].transform.position);                   
                lowestIndex = i;                                                                                
            }
        }
        //if the lowest distance is within grabbing distance and is active
        if (lowest < grabDistance && weapons[lowestIndex].activeSelf)                                           
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
                //aika nasty mutta menkööt -Risto Haila 24/11/2020
                weapons[EQUIPPED].transform.Rotate(-90f, -90f, 0);
            }
            weapons[EQUIPPED].SetActive(true);          //activate the prop
            weaponsHand[EQUIPPED].SetActive(false);     //deactivate the weapon in hand
            EQUIPPED = 500;                             //mark equipped as empty
        }
    }

}
