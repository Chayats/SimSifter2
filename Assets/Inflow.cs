using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inflow : MonoBehaviour
{
    public static Inflow instance;

    void Awake()
    {
        instance = this;
    }
}
