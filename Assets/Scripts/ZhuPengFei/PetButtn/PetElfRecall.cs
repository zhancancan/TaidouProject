using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PetElfRecall : MonoBehaviour {

    Button ElfRecall;

    private void Awake()
    {
        ElfRecall = GameObject.Find("ElfRecall").GetComponent<Button>();
        ElfRecall.onClick.AddListener(ERecall);
    }
    void ERecall()
    {
        SoundManager.Instance.PlayAudio(ConstDates.ButtonSound);
        transform.gameObject.SetActive(false);
        GameObject.Find("Elf(Clone)").transform.Find("Elfmid").gameObject.SetActive(false);
    }
}
