using UnityEngine;

public class SpeedTracker : MonoBehaviour
{
    public float Speed;
    public Vector3 Movement;
    public float Multi3D;
    public float Multi1D;

    Vector3 lastPos;

    void Start()
    {
        lastPos = transform.position;
    }

    void Update()
    {
        Movement = (lastPos- transform.position) * Multi3D/Time.deltaTime;
        Speed = (Vector3.Distance(transform.position, lastPos)*Multi1D)/Time.deltaTime;
        lastPos = transform.position;
    }
}