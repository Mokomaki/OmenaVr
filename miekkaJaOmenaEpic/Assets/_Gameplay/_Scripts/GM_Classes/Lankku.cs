using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lankku : MonoBehaviour
{

    [SerializeField] Vector3 direction;
    [SerializeField] float speed;

    bool inWater = false;
    bool landed = false;

    BoxCollider BC;
    Rigidbody rb;
    float timer = 3.0f;

    void Start()
    {
        BC = GetComponent<BoxCollider>();
        rb = GetComponent<Rigidbody>();
    }   

    void Update()
    {
        if(inWater && !landed)
        {
            rb.velocity = direction * speed * Time.deltaTime;
        }
        if (landed && timer > 0)
        {
            rb.velocity = direction * speed * Time.deltaTime*2;
            //BC.material = null;
            timer--;
        }
    }
        
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Water"))
        {
            inWater = true;
        }else 
        if(collision.gameObject.CompareTag("Terrain"))
        {
            landed = true;
        }
    }
}
