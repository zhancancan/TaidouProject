using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class VedioPlayerController : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler {
    
    VideoPlayer vedioPlayer;
    AudioSource ass;
    Button playerBtn;
    Image playerIm;

    Sprite s;
    Sprite s1;

    VideoClip vc;
    VideoClip vc1;
    VideoClip vc2;
    VideoClip vc3;
    VideoClip vc4;
    VideoClip vc5;

    GameObject vedio;
    GameObject player;

    public Button[] btn;

    private void Awake()
    {
        vedio = GameObject.Find("AnimationDisplay");
        vedioPlayer = vedio.GetComponent<VideoPlayer>();
        ass = vedio.GetComponent<AudioSource>();

        player = GameObject.Find("Player");
        playerIm = player.GetComponent<Image>();
        playerBtn = player.GetComponent<Button>();
        playerBtn.onClick.AddListener(VedioPlayOrPause);
        player.SetActive(false);
        
        btn[0].onClick.AddListener(FirstVedioPlay);
        btn[1].onClick.AddListener(SecondVedioPlay);
        btn[2].onClick.AddListener(ThirdVedioPlay);
        btn[3].onClick.AddListener(FourthVedioPlay);
        btn[4].onClick.AddListener(FifthVedioPlay);
        btn[5].onClick.AddListener(SixthVedioPlay);

        vc = Resources.Load<VideoClip>("");
        vc1 = Resources.Load<VideoClip>("");
        vc2 = Resources.Load<VideoClip>("");
        vc3 = Resources.Load<VideoClip>("");
        vc4 = Resources.Load<VideoClip>("");
        vc5 = Resources.Load<VideoClip>("");

        s = Resources.Load<Sprite>("播放");
        s1 = Resources.Load<Sprite>("暂停");

    }

    void FirstVedioPlay()
    {
        vedioPlayer.clip = vc;
        vedioPlayer.SetTargetAudioSource(0, ass);
        vedioPlayer.Play();
        ass.Play();
    }

    void SecondVedioPlay()
    {
        vedioPlayer.clip = vc1;
        vedioPlayer.SetTargetAudioSource(0, ass);
        vedioPlayer.Play();
        ass.Play();
    }
    void ThirdVedioPlay()
    {
        vedioPlayer.clip = vc2;
        vedioPlayer.SetTargetAudioSource(0, ass);
        vedioPlayer.Play();
        ass.Play();
    }
    void FourthVedioPlay()
    {
        vedioPlayer.clip = vc3;
        vedioPlayer.SetTargetAudioSource(0, ass);
        vedioPlayer.Play();
        ass.Play();
    }
    void FifthVedioPlay()
    {
        vedioPlayer.clip = vc4;
        vedioPlayer.SetTargetAudioSource(0, ass);
        vedioPlayer.Play();
        ass.Play();
    }
    void SixthVedioPlay()
    {
        vedioPlayer.clip = vc5;
        vedioPlayer.SetTargetAudioSource(0, ass);
        vedioPlayer.Play();
        ass.Play();
    }

    void VedioPlayOrPause()
    {
        if (vedioPlayer.isPlaying == true)
        {
            vedioPlayer.Pause();
            playerIm.sprite = s;
        }
        else if (vedioPlayer.isPlaying == false)
        {
            vedioPlayer.Play();
            playerIm.sprite = s1;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (vedioPlayer.isPlaying == true)
        {
            playerIm.sprite = s1;
        }
        else if (vedioPlayer.isPlaying == false)
        {
            playerIm.sprite = s;
        }
        player.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        player.SetActive(false);
    }
}
