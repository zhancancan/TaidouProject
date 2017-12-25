using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PowerShow : MonoBehaviour {

    float startvalue;
    float endvalue=0;
    bool isstart=false;
    Text pstxt;
    Image showpower;
    bool isup = true;
    public   int speed = 1000;
    
    private void Awake()
    {
        pstxt = transform.Find("pstxt").GetComponent<Text>();
        showpower = GetComponent<Image>();
        gameObject.SetActive(false);
        

    }
    public void Finished()
    {
        if (isstart == false)
        {
            gameObject.SetActive(false);
        }
    }
    private void Update()
    {
        if (isstart)
        {
            if (isup)
            {
                startvalue += speed * Time.deltaTime;
                if (startvalue > endvalue)
                {
                    isstart = false;
                    startvalue = endvalue;
                    showpower.DOFade(0, 0.2f).OnComplete(Finished);
                }
            }
            else
            {
                startvalue -= speed * Time.deltaTime;
                if (startvalue < endvalue)
                {
                    isstart = false;
                    startvalue = endvalue;
                    showpower.DOFade(0, 0.2f).OnComplete(Finished);
                }
            }
            pstxt.text = (int)startvalue + "";
        }
    }
    public void ShowPowerChange(int startvalue,int endvalue)
    {
        gameObject.SetActive(true);
        showpower.DOFade(1, 0.2f);
        this.startvalue = startvalue;
        this.endvalue = endvalue;
        if (endvalue > startvalue)
        {
            isup = true;
        }
        else
        {
            isup = false;
        }
        isstart = true;
    }
  
}
