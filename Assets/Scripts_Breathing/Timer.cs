using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 倒计时
/// </summary>
public class Timer : MonoBehaviour
{
    public static Timer instance;
    
    private int _totalTime;
    [SerializeField]
    public int tmp = 5;
    //public Transform[] tf;

    public Text timerText;

    public bool isInhale = true;

    public GameObject breatheInText;
    public GameObject breatheOutText;

    public int entropy = 0;

    public GameObject panel;
    private float _panelAlpha;
    private Color _panelColor;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        AudioManager.instance.Play("BG");
        
        timerText.GetComponent<Text>().text =  Convert.ToString(tmp);
        
        _totalTime = tmp;
        
        InvokeRepeating("StartTimer",0,_totalTime);

        //StartTimer();

        //tf = GetComponentsInParent<Transform>();

        _panelAlpha = panel.gameObject.GetComponent<Image>().color.a;
        _panelColor = panel.gameObject.GetComponent<Image>().color;
        
    }


    private void Update()
    {
        //成功吸气, 吸气阈值内按下或呼气最后按下
        if ((isInhale && tmp == _totalTime) || (!isInhale && tmp == 1))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                BreatheSucceed();
            }
        }
        //成功呼气, 吸气最后阈值松开或者呼气开始松开
        else if ((isInhale && tmp == 1) || (!isInhale && tmp == _totalTime))
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                BreatheSucceed();
            }
        }
        else if(Input.GetKeyUp(KeyCode.Space)||Input.GetKeyDown(KeyCode.Space)) 
        {
            BreatheFail();
        }


        if (isInhale)
        {
            breatheInText.SetActive(true);
            breatheOutText.SetActive(false);
        }
        else
        {
            breatheInText.SetActive(false);
            breatheOutText.SetActive(true);
        }
        
        
        EntropyDetect();
        
        
        panel.gameObject.GetComponent<Image>().color = new Color(1,1,1,_panelAlpha);
        

    }

    public void  StartTimer()
    {
        StartCoroutine(ChangeTime());

    }


    public IEnumerator ChangeTime()
    {

        if (isInhale)
        {
            AudioManager.instance.Play("BreatheIn");
        }

        
        
        
        while (tmp > 0)
        {

   
            yield return new WaitForSeconds(1);
            
            tmp--;

            timerText.GetComponent<Text>().text =  Convert.ToString(tmp);
            
            
        }


        if (tmp == 0)
        {
            tmp = _totalTime;
            timerText.GetComponent<Text>().text =  Convert.ToString(tmp);
            isInhale = !isInhale;
            PlayBreatheSound();
        }
    }

    private void TimeOver()
    {

        tmp = _totalTime;
        //Debug.Log("倒计时结束");
        //GetComponent<Text>().text = "倒计时结束";

        //关闭子物体的父物体
        //GetComponentsInParent<Transform>()[1].gameObject.SetActive(false);

    }


    //呼吸成功
    public void BreatheSucceed()
    {
        Debug.Log("Succeed");
        if (entropy > 0)
        {
            entropy--;
        }
    }
    
    //呼吸失败
    public void BreatheFail()
    {
        
        Debug.Log("Fail");
        entropy++;
    }

    //检测熵值并且根据数值改变画面
    public void EntropyDetect()
    {

//        Debug.Log(_panelAlpha);
        if (entropy > 7)
        {
            _panelAlpha = 1f;
        }
        else if (entropy > 6 && entropy <= 7)
        {
            _panelAlpha = .9f;
        }
        else if(entropy >5 && entropy <=6)
        {
            _panelAlpha = .8f;
        }
        else if(entropy >4 && entropy <=5)
        {
            _panelAlpha = .7f;
        }
        else if(entropy >3 && entropy <=4)
        {
            _panelAlpha = .6f;
        }
        else if(entropy >2 && entropy <=3)
        {
            _panelAlpha = .5f;
        }
        else if(_panelAlpha<=2 &&_panelAlpha>=0)
        {
            _panelAlpha = 0;
        }

        
    }

    //播放音效
    public void PlayBreatheSound()
    {
        if (isInhale)
        {
            AudioManager.instance.Play("BreatheIn");
        }
        if (!isInhale)
        {
            AudioManager.instance.Play("BreatheOut");
        }
    }
}