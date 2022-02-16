using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_New : MonoBehaviour
{
    public GameObject upLeftArrow;
    public GameObject upArrow;
    public GameObject upRightArrow;

    public GameObject upLeftFootS;
    public GameObject upRightFootS;
    public GameObject upFootS;

    // private Color uLArrowColor;
    // private Color uArrowColor;
    // private Color uRArrowColor;

    public bool isUpLeft;
    public bool isUpRight;
    public bool isUp;
    void Start()
    {
        // uLArrowColor = upLeftArrow.GetComponent<SpriteRenderer>().color;
        // uRArrowColor = upRightArrow.GetComponent<SpriteRenderer>().color;
        // uArrowColor = upArrow.GetComponent<SpriteRenderer>().color;
    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.UpArrow))
        // {
        //     GetComponent<SpriteRenderer>().color = Color.gray;
        //     
        //     
        // }
        //
        // if (Input.GetKeyUp(KeyCode.UpArrow))
        // {
        //     GetComponent<SpriteRenderer>().color = Color.white;
        // }

        
        
        //按左+上则UpLeft
        if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.UpArrow))
        {
            isUpLeft = true;
            upLeftArrow.GetComponent<SpriteRenderer>().color = Color.black;
            upLeftFootS.SetActive(true);
        }
        else
        {
            isUpLeft = false;
            upLeftArrow.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            upLeftFootS.SetActive(false);
        }

        //单上无其他则Up
        if (!Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.RightArrow))
        {
            isUp = true;
            upArrow.GetComponent<SpriteRenderer>().color = Color.black;
            upFootS.SetActive(true);
        }
        else
        {
            isUp = false;
            upArrow.GetComponent<SpriteRenderer>().color = Color.white;
            upFootS.SetActive(false);
        }

        //右+上则UpRight
        if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.UpArrow))
        {
            isUpRight = true;
            upRightArrow.GetComponent<SpriteRenderer>().color = Color.black;
            upRightFootS.SetActive(true);
        }
        else
        {
            isUpRight = false;
            upRightArrow.GetComponent<SpriteRenderer>().color = Color.white;
            upRightFootS.SetActive(false);
        }

    }
}
