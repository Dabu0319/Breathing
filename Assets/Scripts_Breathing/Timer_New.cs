using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Timer_New : MonoBehaviour
{
    public float breathTime;
    public bool isInhale;
    public float _currentTime;

    public bool isStarted;

    public Text timeText;

    public float inhaleTime;
    public float exhaleTime;
    
    
    //熵
    public int entropy = 0;
    
    //阈值
    public float threshold = 0.1f;

    public static Timer_New instance;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {

        AudioManager.instance.Play("BG");
        _currentTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.anyKeyDown)
        {
            isStarted = true;
        }

        

        if (Input.GetKeyDown(KeyCode.Space))
        {
            isInhale = true;
            AudioManager.instance.Play("BreatheIn");
            AudioManager.instance.Stop("BreatheOut");
            
            inhaleTime = 0f;
            
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            isInhale = false;
            AudioManager.instance.Play("BreatheOut");
            AudioManager.instance.Stop("BreatheIn");
            
            exhaleTime = 0f;
            
        }

        if (isStarted)
        {
            //Timer
            _currentTime = _currentTime + Time.deltaTime;
            
            TimeSpan time = TimeSpan.FromSeconds(_currentTime);
            //currentTimeText.text = time.Minutes.ToString() + ":" + time.Seconds.ToString();
            //timeText.text = time.ToString(@"mm\:ss\:fff");
            timeText.text = time.ToString(@"mm\:ss");
            
            
            
            if (isInhale)
            {
                //四秒内按或五秒后没吸都算失败
                //四秒后阈值内呼气算成功
                        
                inhaleTime += Time.deltaTime;
                        
                if(Input.GetKeyDown(KeyCode.Space))
                {
                    if ((exhaleTime > 0 && exhaleTime < breathTime))
                    {
                        BreatheFail();
                    }
                    else if (exhaleTime>=breathTime && exhaleTime < breathTime + threshold)
                    {
                        BreatheSucceed();
                                
                    }
                    // else if(exhaleTime > breathTime + threshold)
                    // {
                    //     BreatheFail();
                    //     
                    // }
                            
                }
            
                if (inhaleTime > breathTime + threshold)
                {
                    BreatheFail();
                    inhaleTime = 0;
                }

                        
                        
            }
            
            if (!isInhale)
            {
                //四秒内按或五秒后没呼气都算失败
                //四秒后阈值内呼气算成功
                        
                exhaleTime += Time.deltaTime;
                        
                if(Input.GetKeyUp(KeyCode.Space))
                {
                    if ((inhaleTime > 0 && inhaleTime < breathTime))
                    {
                        BreatheFail();
                    }
                    else if (inhaleTime>=breathTime && inhaleTime < breathTime + threshold)
                    {
                        BreatheSucceed();
                                
                    }
                    // else
                    // {
                    //     BreatheFail();
                    // }
                }
            
                if (exhaleTime > breathTime + threshold)
                {
                    BreatheFail();
                    exhaleTime = 0;
                }         
            
            }
        }
        
        
        


    }
    
    
    //呼吸成功
    public void BreatheSucceed()
    {
        Debug.Log("Succeed");
        
        SpawnEnvEffect.instance.SpawnNormalEffect();
        
        if (entropy > 0)
        {
            entropy--;
        }
    }
    
    //呼吸失败
    public void BreatheFail()
    {
        
        Debug.Log("Fail");
        
        SpawnEnvEffect.instance.SpawnHeavyEffect();
        
        entropy++;
    }
}
