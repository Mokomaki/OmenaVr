using UnityEngine;

public class BaseballBat : MonoBehaviour
{
    private void OnCollisionEnter(Collision otherCol)
    {
        if (otherCol.gameObject.CompareTag("omena") || otherCol.gameObject.CompareTag("paaryna"))
        {
            //Vector3 vel = otherCol.transform.GetComponent<Rigidbody>().velocity;
            otherCol.transform.GetComponent<Rigidbody>().velocity = Vector3.zero;
            otherCol.transform.GetComponent<Rigidbody>().AddForce(-transform.GetComponentInChildren<SpeedTracker>().Movement, ForceMode.Impulse);
        }
    }
}
