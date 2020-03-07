using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanerIN : MonoBehaviour
{
    public static CleanerIN instance;
    public bool on;
    public float timermax;
    public float time;
    bool recharge;
    public dragable myparent;
    public SpriteRenderer SR;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (on)
        {
            SR.color = Color.green;
        }
        else
            SR.color = Color.red;



        if (recharge)
        {
            time -= Time.deltaTime;
        }
        if(!on && time < 0)
        {
            on = true;
        }

        if (myparent.beingdragged)
        {
            down();
        }
        else
        {
            up();
        }

    }
    void down()
    {
        recharge = false;
        on = false;
        time = timermax;
    }

    private void up()
    {
        recharge = true;
    }

}
