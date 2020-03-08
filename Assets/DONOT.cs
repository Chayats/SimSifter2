using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DONOT : MonoBehaviour
{
    public static DONOT instance;
    public SpriteRenderer SR;
    public bool fadein;
    public bool fadeout;
    public float timer;
    public bool loading;
    public Color bob; 
    // Start is called before the first frame update
    void Start()
    {
        bob = Color.black;
        bob.a = 0;
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    public void ReturnToMENU()
    {
        if (loading) return;
        //fade out
        fadeout = true;
        loading = true;
        Debug.Log("LOAD NEW");
        Invoke("load", .9f);
    }

    private void Update()
    {
        if (fadeout)
        {
            timer += Time.deltaTime;

             

            bob.a = Mathf.Lerp(0, 1, timer);

            
            if(timer > 1)
            {
                timer = 0;
                fadein = true;
                fadeout = false;
                loading = false;
            }
        }
        if (fadein)
        {
            timer += Time.deltaTime;
           bob.a = Mathf.Lerp(1,0, timer);
            if (timer > 1)
            {
                timer = 0;
                fadein = false;
                fadeout = false;
            }
        }

        SR.color = bob;

    }
    void load()
    {
        SceneManager.LoadScene(5);
    }

}
