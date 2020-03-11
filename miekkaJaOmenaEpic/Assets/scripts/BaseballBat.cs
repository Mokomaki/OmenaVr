using UnityEngine;

public class BaseballBat : MonoBehaviour
{
    private void OnCollisionEnter(Collision otherCol)
    {
        if (otherCol.gameObject.CompareTag("omena") || otherCol.gameObject.CompareTag("paaryna"))
        {
            otherCol.transform.GetComponent<Rigidbody>().velocity = Vector3.zero;
            otherCol.transform.GetComponent<Rigidbody>().AddForce(/**/Vector3.zero/*muokkaa TÄÄÄÄÄÄÄÄ*/, ForceMode.Impulse);
        }
    }
}
