using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lintu : MonoBehaviour
{
    public float speed;
    public Vector3 Rotation;
    void Update()
    {
        transform.Rotate(Rotation);
        transform.localPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z + speed);
    }
}
