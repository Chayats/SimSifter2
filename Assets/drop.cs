using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drop : MonoBehaviour
{
    Rigidbody2D RB;
    public bool magnetic = false;

    [Range (0,1)]
    public float taint;
    public Color clean;
    public Color dirty;
    public SpriteRenderer SR;
    public bool notliquid;
    public int type;
    
    
    void Awake()
    {
        RB = GetComponent<Rigidbody2D>();
        ColorUpdate();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, Outflow.instance.transform.position) < .7)
        {
            Respawn();
        }
        if (!notliquid)
        {
            if (Vector2.Distance(transform.position, CleanerIN.instance.transform.position) < .3&&CleanerIN.instance.on)
            {
                Vector3 desti = CleanerOut.instance.transform.position;
                desti.z = transform.position.z;
                transform.position = desti;
                RB.velocity = Vector2.zero;
                taint = taint - .5f;
                ColorUpdate();
                if (taint < 0) taint = 0;
            }
        }

    }
    public void Respawn()
    {
        transform.position = Inflow.instance.transform.position;
        RB.velocity = Vector2.zero;
    }
    public void ColorUpdate()
    {
        Color set;
        set.r = Mathf.Lerp(clean.r, dirty.r, taint);
        set.g = Mathf.Lerp(clean.g, dirty.g, taint);
        set.b = Mathf.Lerp(clean.b, dirty.b, taint);
        set.a = Mathf.Lerp(clean.a, dirty.a, taint*taint);
        SR.color = set;
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
