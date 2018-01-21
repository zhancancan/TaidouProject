using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PetLionRecall : MonoBehaviour {

    Button LionRecall;
    AudioSource LionRecallSource; 
    private void Awake()
    {
        LionRecall = GameObject.Find("LionRecall").GetComponent<Button>();
        LionRecall.onClick.AddListener(LRecall);
    }
    void LRecall()
    { 
        SoundManager.Instance.PlayAudio(ConstDates.ButtonSound);       
        transform.gameObject.SetActive(false);
        GameObject.Find("Lion(Clone)").transform.Find("Lionmid").gameObject.SetActive(false);
    }
}
