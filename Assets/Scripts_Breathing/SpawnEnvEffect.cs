using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class SpawnEnvEffect : MonoBehaviour
{
    public static SpawnEnvEffect instance;

    public GameObject EnvEffectParent;
    public GameObject[] normalEffects;
    public GameObject[] heavyEffects;

    public GameObject upFire;
    public GameObject upLeftFire;
    public GameObject upRightFire;

    public bool isUpFire;
    public bool isUpLeftFire;
    public bool isUpRightFire;
    public bool noFire;

    public float fireTime;
    
    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    
    void Start()
    {
        InvokeRepeating("RandomFire",0,fireTime);

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnNormalEffect()
    {
        //再次记一下random 其实是0 到 index-1
        int effectIndex = Random.Range(0, normalEffects.Length);
        Instantiate(normalEffects[effectIndex], EnvEffectParent.transform.position, transform.rotation,
            EnvEffectParent.transform);
    }
    
    public void SpawnHeavyEffect()
    {
        //再次记一下random 其实是0 到 index-1
        int effectIndex = Random.Range(0, heavyEffects.Length);
        Instantiate(heavyEffects[effectIndex], EnvEffectParent.transform.position, transform.rotation,
            EnvEffectParent.transform);
    }

    public void RandomFire()
    {
        if (Timer_New.instance.isStarted)
        {
            int fireNum = 4;
            int activeFire = Random.Range(0, fireNum);

            Debug.Log(activeFire);
            StartCoroutine(ActiveFire(activeFire));
        }


    }

    public IEnumerator ActiveFire(int activeFireNum)
    {

        switch (activeFireNum)
        {
            case 0:
                noFire = true;
                break;
            
            case 1:
                upFire.SetActive(true);
                isUpFire = true;
                break;
            
            case 2:
                upLeftFire.SetActive(true);
                isUpLeftFire = true;
                break;
            case 3:
                upRightFire.SetActive(true);
                isUpRightFire = true;
                break;
        }
        
        yield return new WaitForSeconds(fireTime);
        
        switch (activeFireNum)
        {
            case 0:
                noFire = false;
                break;
            
            case 1:
                upFire.SetActive(false);
                isUpFire = false;
                break;
            
            case 2:
                upLeftFire.SetActive(false);
                isUpLeftFire = false;
                break;
            case 3:
                upRightFire.SetActive(false);
                isUpRightFire = false;
                break;
        }
        
        
    }
    
}
