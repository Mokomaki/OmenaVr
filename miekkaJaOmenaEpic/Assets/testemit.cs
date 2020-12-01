using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testemit : MonoBehaviour
{
    public float Rate = 2;
    float t2t = 0;
    public GameObject emit;

    // Update is called once per frame
    void Update()
    {
        if(t2t<=0)
        {
            Destroy(Instantiate(emit), 3);
            t2t = Rate;
        }
        t2t -= Time.deltaTime;
    }
}
