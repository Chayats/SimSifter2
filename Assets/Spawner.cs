using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    public static Spawner instance;
    public GameObject drop;
    public int amount;
    int spawned;
    public GameObject parent;
    public GameObject[] items;
    public int rate;
    int item = 0;
    public List<GameObject> drops;
    public Slider cleanness;
    public float taint = 0;
    void Start()
    {
        instance = this;

        drops = new List<GameObject>();
        cleanness.maxValue = amount;

    }

    // Update is called once per frame
    void Update()
    {
        if (spawned < amount)
        {
            GameObject bob;
            if (spawned % rate != 0 || items.Length == 0)
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

            drops.Add(bob);
            bob.transform.position = this.transform.position;
            bob.transform.Translate(Vector3.left * Mathf.Sin(Time.time) * .001f);
            bob.transform.parent = parent.transform;
            spawned++;
        }

 




    }

    private void FixedUpdate()
    {
        taint = 0;
        foreach (var item in drops)
        {
            if (item == null)
            {
                drops.Remove(item);
            }

            taint += item.GetComponent<drop>().taint;
        }
        cleanness.value = amount - taint;

        if(taint <29 &&spawned>30)
        {
            DONOT.instance.ReturnToMENU();
        }
    }


}
