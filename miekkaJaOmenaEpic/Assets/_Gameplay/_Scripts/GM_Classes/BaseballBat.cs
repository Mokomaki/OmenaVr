using UnityEngine;

public class BaseballBat : MonoBehaviour
{
    [SerializeField] float BounceMultiplier = 1;
    private void OnCollisionEnter(Collision otherCol)
    {
        if (otherCol.gameObject.CompareTag("omena") || otherCol.gameObject.CompareTag("paaryna"))
        {
            Rigidbody rb = otherCol.transform.GetComponent<Rigidbody>();
            rb.velocity = Vector3.zero;
            rb.AddForce(-transform.GetComponentInChildren<SpeedTracker>().Movement*BounceMultiplier, ForceMode.Impulse);
        }
    }
}
