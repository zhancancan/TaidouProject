using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PetInvokeAndRecall : MonoBehaviour {


    Button invoke;
    Button recall;

    private void Awake()
    {
        invoke = GameObject.Find("PetInvoke").GetComponent<Button>();
        recall = GameObject.Find("PetRecall").GetComponent<Button>();

        invoke.onClick.AddListener(InvokePet);
        recall.onClick.AddListener(RecallPet);
    }

    //宠物召出
    void InvokePet()
    {

    }

    //宠物召回
    void RecallPet()
    {

    }
}
