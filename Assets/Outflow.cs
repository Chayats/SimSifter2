using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Outflow : MonoBehaviour
{
    public static Outflow instance;

    void Awake()
    {
        instance = this;
    }
}
