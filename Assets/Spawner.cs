using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject drop;
    public int amount;
    int spawned;
    public GameObject parent;
    public GameObject[] items;
    public int rate;
    int item = 0;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (spawned < amount)
        {
            GameObject bob;
            if (spawned%rate != 0)
            {
                 bob = Instantiate(drop);
            }
            else
            {
                 bob = Instantiate(items[item]);
                item++;
                    if (item == items.Length)
                {
                    item = 0;
                }
            }

            
            bob.transform.position = this.transform.position;
            bob.transform.Translate(Vector3.left * Mathf.Sin(Time.time) * .001f);
            bob.transform.parent = parent.transform;
            spawned++;
        }
    }
}
