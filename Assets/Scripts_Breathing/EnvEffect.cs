﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvEffect : MonoBehaviour
{
    public float speed=0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate((Vector3.down * speed * Time.deltaTime));
    }
}
