using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PetInvokeAndRecall : MonoBehaviour {


    Button invoke;     //召出
    Button recall;     //召回
    Transform hero;    //英雄位置

    GameObject l;      //宠物UI模型--狮子
    GameObject e;
    GameObject f;

    private void Awake()
    {
        invoke = GameObject.Find("PetInvoke").GetComponent<Button>();
        recall = GameObject.Find("PetRecall").GetComponent<Button>();
        hero = GameObject.FindGameObjectWithTag("Player").transform ;
        invoke.onClick.AddListener(InvokePet);
        recall.onClick.AddListener(RecallPet);
    }

    //宠物召出（如果当宠物面板点击狮子的时候，通过判断狮子UI是存在的即判断当前页面是召唤狮子的页面，然后在来生成狮子）
    void InvokePet()
    {
        l = GameObject.Find("UILion");        
        e = GameObject.Find("UIElf");
        f = GameObject.Find("UIFairy");
        if (l!=null)      //如果宠物UI面板是狮子  
        {
            PrefabManager.Instance.GetPrefabInstance(ConstDates.Lion,new Vector3(hero.position.x-2,hero.position.y, hero.position.z-2),Quaternion.identity);     //生成狮子模型
            UIPetManager._uiPetManager.lion = false;
        }
        if (e!=null)
        {
            PrefabManager.Instance.GetPrefabInstance(ConstDates.Elf, new Vector3(hero.position.x - 3, hero.position.y, hero.position.z - 3), Quaternion.identity);
            UIPetManager._uiPetManager.elf = false;
        }
        if (f!=null)
        {
            PrefabManager.Instance.GetPrefabInstance(ConstDates.Fairy, new Vector3(hero.position.x - 4, hero.position.y, hero.position.z - 2), Quaternion.identity);
            UIPetManager._uiPetManager.fairy = false;
        }
    }

    //宠物召回
    void RecallPet()
    {
        l = GameObject.Find("UILion");
        e = GameObject.Find("UIElf");
        f = GameObject.Find("UIFairy");
        if (l != null)
        {
            GameObject.Find("Lion(Clone)").gameObject.SetActive(false);
        }
        if (e != null)
        {
            GameObject.Find("Elf(Clone)").gameObject.SetActive(false);
        }
        if (f != null)
        {
            GameObject.Find("Fairy(Clone)").gameObject.SetActive(false);
        }
    }
}
