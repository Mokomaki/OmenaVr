using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    void Update()
    {
        StaticVariables.VariableUpdate();
    }
}

static class StaticVariables
{
    public static bool s_canShoot = true; 
    public static short s_gunPowederLevel = 0;

    public static void VariableUpdate()
    {

    }
}