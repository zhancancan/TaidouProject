using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SystemSetting : UIBase {
    private Button exitBtn;             //系统设置界面相关按钮
    
    private Toggle volumeTog;           //声音按钮
    private GameObject volumeBg;        //声音设定界面
    private Slider volumeSliderMain;    //主音量滑动条
    private Slider volumeSliderBm;      //背景音量

    //背景音乐源
    private AudioSource audioSourceBm;

    void Awake()
    {
        //QualitySettings.SetQualityLevel(1);
        exitBtn = transform.Find("SettingBg/Exit").GetComponent<Button>();
        volumeTog = transform.Find("SettingBg/ScrollView/Viewport/Content/Volume").GetComponent<Toggle>();
        volumeBg = transform.Find("SettingBg/ScrollView/Viewport/Content/VolumeBg").gameObject;
        volumeSliderMain = transform.Find("SettingBg/ScrollView/Viewport/Content/VolumeBg/SliderMain").GetComponent<Slider>();
        volumeSliderBm = transform.Find("SettingBg/ScrollView/Viewport/Content/VolumeBg/SliderBm").GetComponent<Slider>();

        //获取UIManager上的AudioSource源
        audioSourceBm = SoundManager.Instance.audioMgr;
        AudioListener.volume = audioSourceBm.volume;
        volumeSliderMain.value = AudioListener.volume;
        volumeSliderBm.value = audioSourceBm.volume;

        //初始化每个设定界面的显示状态
        volumeBg.SetActive(volumeTog.isOn);
    }

    void Start()
    {
        exitBtn.onClick.AddListener(OnExitBtnClick);
        volumeTog.onValueChanged.AddListener(OnVolumeTogChanged);
        volumeSliderMain.onValueChanged.AddListener(OnMainSliderChanged);
        volumeSliderBm.onValueChanged.AddListener(OnBgSliderChanged);
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

    //点击退出按钮
    void OnExitBtnClick()
    {
        UIManager.Instance.PopUIPanel();
    }

    //点击音量设定按钮
    void OnVolumeTogChanged(bool isOn)
    {
        volumeBg.SetActive(isOn);
    }

    //主音量滑动条变化
    void OnMainSliderChanged(float mainVolume)
    {
        AudioListener.volume = volumeSliderMain.value;
    }

    //背景音量滑动条变化
    void OnBgSliderChanged(float bgVolume)
    {
        audioSourceBm.volume = bgVolume;
    }

}
