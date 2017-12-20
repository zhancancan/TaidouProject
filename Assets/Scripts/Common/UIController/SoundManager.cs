using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    //单例
    private static SoundManager _instance;
    public static SoundManager Instance
    {
        get
        {
            return _instance;
        }
    }

    [HideInInspector]
    public AudioSource audioMgr;

    private void Awake()
    {
        _instance = this;
        audioMgr = this.GetComponent<AudioSource>();
        //设置循环
        audioMgr.loop = true;
        //关闭自动播放
        audioMgr.playOnAwake = false;
    }

    //设置静音
    public bool Mute
    {
        get
        {
            return audioMgr.mute;
        }
        set
        {
            audioMgr.mute = value;
        }
    }

    //设置背景声音大小
    public float BGSound
    {
        get
        {
            return audioMgr.volume;
        }
        set
        {
            audioMgr.volume = value;
        }
    }

    //播放背景音
    //public void PlayBGSound(string name)
    //{
    //    string path = ConstDates.ResourceAudiosDir + "/" + name;
    //    AudioClip ac = Resources.Load<AudioClip>(path);

    //    //设置播放音频的片段
    //    audioMgr.clip = ac;

    //    //播放音频
    //    audioMgr.Play();
    //}

    public void PlayBGSound(string selfPath,string name)
    {
        string path = selfPath + "/" + name;
        AudioClip ac = Resources.Load<AudioClip>(path);

        //设置播放音频的片段
        audioMgr.clip = ac;

        //播放音频
        audioMgr.Play();
    }

    //停止播放
    public void StopBGSound()
    {
        audioMgr.clip = null;
        audioMgr.Stop();
    }

    //播放音频
    //public void PlayAudio(string name)
    //{
    //    string path = ConstDates.ResourceAudiosDir + "/" + name;
    //    AudioClip ac = Resources.Load<AudioClip>(path);
    //    AudioSource.PlayClipAtPoint(ac, Vector2.zero);
    //}

    public void PlayAudio(string selfPath,string name)
    {
        string path = selfPath + "/" + name;
        AudioClip ac = Resources.Load<AudioClip>(path);
        AudioSource.PlayClipAtPoint(ac, Vector2.zero);
    }
}
