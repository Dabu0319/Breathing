using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectObject : MonoBehaviour
{
    public float lifeTime = 1f;
    
    public bool canBePressed;
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.instance.Play("FootStep");
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject,lifeTime);

        // if (Input.GetKeyDown(KeyCode.UpArrow))
        // {
        //     if (canBePressed)
        //     {
        //         Destroy(gameObject);
        //         Timer.instance.entropy--;
        //     }
        //     else if(!canBePressed)
        //     {
        //         Timer.instance.entropy++;
        //     }
        //
        //     
        // }
    }

    //
    // private void OnTriggerEnter2D(Collider2D other)
    // {
    //     if (other.CompareTag("Trigger"))
    //     {
    //         canBePressed = true;
    //     }
    // }
    //
    // private void OnTriggerExit2D(Collider2D other)
    // {
    //     if (other.CompareTag("Trigger"))
    //     {
    //         canBePressed = false;
    //     }
    // }
}
