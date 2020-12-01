using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bounceBack : MonoBehaviour
{
    [SerializeField] Transform respawn;
    private void FixedUpdate()
    {
        if (transform.position.y < -5)
        {
            transform.position = respawn.position;
        }
    }
}