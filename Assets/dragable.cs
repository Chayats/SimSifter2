using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragable : MonoBehaviour
{
    public bool beingdragged;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (beingdragged)
        {
            Vector3 v3 = Input.mousePosition;
     
            v3 = Camera.main.ScreenToWorldPoint(v3);
            v3.z = -9.5f;
            Vector3 newpos = v3;

            transform.position = newpos;
        }
    }

    private void OnMouseDown()
    {
        beingdragged = true;
       
    }

    private void OnMouseUp()
    {
        beingdragged = false;
    }
}
