using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagController : MonoBehaviour
{
    public static MagController instance;

    public GameObject[] magnetics;

    [Range(0.4f, .1f)]
    public float force = .2f;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    public void UpdateForce(float x)
    {
        force = x;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
