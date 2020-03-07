using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class popper : MonoBehaviour
{
    public bool metal; // type 1
    public bool glass; // type 2

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        drop drop = collision.gameObject.GetComponent<drop>();

        if (drop != null)
        {
            Debug.Log("pop it?");

            if (drop.type == 1 && metal)
            {
                Score(drop);
            }
            else

            if (drop.type == 2 && glass)
            {
                Score(drop);
            }
            else

                drop.Respawn();

        }

    }

    void Score(drop drop)
    {
        GameObject.Destroy(drop.gameObject);
    }


}
