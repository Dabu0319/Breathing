using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public float spawnWaitTime= 8;
    public float spawnRepeatTime=8 ;

    public GameObject footStep;
    public Transform footStepPos01;

    public static SpawnManager instance;

    public float stepRepeatTime = .8f;
    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("StartSpawn",spawnWaitTime,spawnRepeatTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartSpawn()
    {
        StartCoroutine(SpawnFootStep());
    }
    
    public  IEnumerator SpawnFootStep()
    {
        Instantiate(footStep, footStepPos01.position, footStep.transform.rotation);
        yield return new WaitForSeconds(stepRepeatTime);
        Instantiate(footStep, footStepPos01.position+new Vector3(3.5f,0,0), footStep.transform.rotation);
        yield return new WaitForSeconds(stepRepeatTime);
        Instantiate(footStep, footStepPos01.position+new Vector3(7f,0,0), footStep.transform.rotation);
        yield return new WaitForSeconds(stepRepeatTime);
        Instantiate(footStep, footStepPos01.position+new Vector3(10.5f,0,0), footStep.transform.rotation);
        yield return new WaitForSeconds(stepRepeatTime);
        Instantiate(footStep, footStepPos01.position+new Vector3(14f,0,0), footStep.transform.rotation);
    }
}
