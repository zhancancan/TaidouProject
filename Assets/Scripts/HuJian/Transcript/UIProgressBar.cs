using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIProgressBar : MonoBehaviour
{
    private Slider slider;
    private Text txt;
    private bool isAsyn;
    private float loadingSpeed = 1;
    private float targetValue;
    private AsyncOperation operation;
    private void Awake()
    {
        slider = transform.Find("BG/ProgressBG").GetComponent<Slider>();
        txt = transform.Find("BG/ProgressTxt_01").GetComponent<Text>();
    }
    void Start()
    {
        slider.value = 0.0f;       
        //启动协程  
        StartCoroutine(AsyncLoading());       
    }
    IEnumerator AsyncLoading()
    {
        operation = SceneManager.LoadSceneAsync(4);
        //阻止当加载完成自动切换  
        operation.allowSceneActivation = false;

        yield return operation;
    } 
    void Update()
    {
        targetValue = operation.progress;

        if (operation.progress >= 0.9f)
        {
            //operation.progress的值最大为0.9  
            targetValue = 1.0f;
        }

        if (targetValue != slider.value)
        {
            //插值运算  
            slider.value = Mathf.Lerp(slider.value, targetValue, Time.deltaTime * loadingSpeed);
            if (Mathf.Abs(slider.value - targetValue) < 0.01f)
            {
                slider.value = targetValue;
            }
        }

        txt.text = ((int)(slider.value * 100)).ToString() + "%";

        if ((int)(slider.value * 100) == 100)
        {
            //允许异步加载完毕后自动切换场景  
            operation.allowSceneActivation = true;
        }
    }
   
}
