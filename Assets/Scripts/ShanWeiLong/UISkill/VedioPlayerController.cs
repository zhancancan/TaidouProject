using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class VedioPlayerController : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler {
    
    VideoPlayer vedioPlayer;
    AudioSource ass;
    Button playerBtn;
    Image playerIm;

    Sprite VideoPlay;
    Sprite VideoPause;

    VideoClip vc;
    VideoClip vc1;
    VideoClip vc2;
    VideoClip vc3;
    VideoClip vc4;
    VideoClip vc5;

    GameObject player;

    Button[] btn;

    private void Awake()
    {
        vedioPlayer = GetComponent<VideoPlayer>();
        ass = GetComponent<AudioSource>();

        player = transform.Find("Player").gameObject;
        playerIm = player.GetComponent<Image>();
        playerBtn = player.GetComponent<Button>();
        playerBtn.onClick.AddListener(VedioPlayOrPause);
        player.SetActive(false);

        btn = new Button[6];
        btn[0] = transform.parent.Find("Skill/Content/Skill1").GetComponent<Button>();
        btn[1] = transform.parent.Find("Skill/Content/Skill2").GetComponent<Button>();
        btn[2] = transform.parent.Find("Skill/Content/Skill3").GetComponent<Button>();
        btn[3] = transform.parent.Find("Skill/Content/Skill4").GetComponent<Button>();
        btn[4] = transform.parent.Find("Skill/Content/Skill5").GetComponent<Button>();
        btn[5] = transform.parent.Find("Skill/Content/Skill6").GetComponent<Button>();
        btn[0].onClick.AddListener(FirstVedioPlay);
        btn[1].onClick.AddListener(SecondVedioPlay);
        btn[2].onClick.AddListener(ThirdVedioPlay);
        btn[3].onClick.AddListener(FourthVedioPlay);
        btn[4].onClick.AddListener(FifthVedioPlay);
        btn[5].onClick.AddListener(SixthVedioPlay);

        vc = Resources.Load<VideoClip>("ghyjn");
        vc1 = Resources.Load<VideoClip>("hx");
        vc2 = Resources.Load<VideoClip>("lmm");
        vc3 = Resources.Load<VideoClip>("mwqn");
        vc4 = Resources.Load<VideoClip>("wzb");
        vc5 = Resources.Load<VideoClip>("");

        VideoPlay = Resources.Load<Sprite>(ConstDates.ResourceSpritesDirSwl+ConstDates.VideoPlay);
        VideoPause = Resources.Load<Sprite>(ConstDates.ResourceSpritesDirSwl + ConstDates.VideoPause);

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
            playerIm.sprite = VideoPlay;
        }
        else if (vedioPlayer.isPlaying == false)
        {
            vedioPlayer.Play();
            playerIm.sprite = VideoPause;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (vedioPlayer.isPlaying == true)
        {
            playerIm.sprite = VideoPause;
        }
        else if (vedioPlayer.isPlaying == false)
        {
            playerIm.sprite = VideoPlay;
        }
        player.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        player.SetActive(false);
    }
}
