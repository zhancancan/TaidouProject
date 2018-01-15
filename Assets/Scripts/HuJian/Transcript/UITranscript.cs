using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UITranscript : UIBase
{
    private Button exit;
    private Button one;
    private void Awake()
    {
        exit = transform.Find("MapBG/BackBtn").GetComponent<Button>();
        one = transform.Find("MapBG/CustomBtn").GetComponent<Button>();

    }
    private void Start()
    {
        exit.onClick.AddListener(() => { UIManager.Instance.PopUIPanel(); });
        one.onClick.AddListener(() => { UIManager.Instance.PushUIPanel("UIProgressBar"); });        
    }
    public override void OnEntering()
    {
        gameObject.SetActive(true);
    }

    public override void OnPausing()
    {
        gameObject.SetActive(false);
    }

    public override void OnResuming()
    {

    }

    public override void OnExiting()
    {
        gameObject.SetActive(false);
    }
}
