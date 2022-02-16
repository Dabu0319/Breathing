using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public bool canBePressed;
    // Start is called before the first frame update
    public GameObject step;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            GetComponent<SpriteRenderer>().color = Color.gray;

            if (canBePressed)
            {
                
                
                Destroy(step);
                if(Timer.instance.entropy>0)
                     Timer.instance.entropy--;
            }
            else
            {
                Timer.instance.entropy += 2;
            }
            
        }

        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            GetComponent<SpriteRenderer>().color = Color.white;
        }
        
        
    }

    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("FootStep"))
        {
            canBePressed = true;
            step = other.gameObject;
            Timer.instance.entropy++;
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("FootStep"))
        {
            canBePressed = false;
            
        }
    }

}
