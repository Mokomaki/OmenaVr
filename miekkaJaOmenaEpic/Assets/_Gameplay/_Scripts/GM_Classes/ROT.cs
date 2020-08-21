using UnityEngine;

public class ROT : MonoBehaviour
{
    public Vector3 Rotation;
    void Update()
    {
        transform.Rotate(Rotation * Time.deltaTime);
    }
}
