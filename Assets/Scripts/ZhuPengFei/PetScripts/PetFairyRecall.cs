using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PetFairyRecall : MonoBehaviour {

    Button FairyRecall;

    private void Awake()
    {
        FairyRecall = GameObject.Find("FairyRecall").GetComponent<Button>();
        FairyRecall.onClick.AddListener(FRecall);
    }
    void FRecall()
    {
        transform.gameObject.SetActive(false);
        GameObject.Find("Fairy(Clone)").transform.Find("Fairymid").gameObject.SetActive(false);
    }
}
