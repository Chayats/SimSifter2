using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drop : MonoBehaviour
{
    Rigidbody2D RB;
    public bool magnetic = false;


    
    
    
    void Awake()
    {
        RB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, Outflow.instance.transform.position) < .7)
        {
            transform.position = Inflow.instance.transform.position;
            RB.velocity = Vector2.zero;
        }
    }

    void FixedUpdate()
    {
        

        if (magnetic)
        {
            foreach (var megnet in MagController.instance.magnetics)
            {
                float distance = Vector2.Distance(megnet.transform.position, this.transform.position);

                float attraction = (1 / Mathf.Pow(distance * MagController.instance.force, 2)) ;

                RB.AddForce((megnet.transform.position - transform.position) * attraction);

                
            }

        }
    }
    
}
