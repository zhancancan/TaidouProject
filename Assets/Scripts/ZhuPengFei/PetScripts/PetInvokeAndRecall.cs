using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PetInvokeAndRecall : MonoBehaviour {

    public static PetInvokeAndRecall _petInvokeAndRecall;
    Button invoke;     //召出
    Button recall;     //召回
    Transform hero;    //英雄位置

    GameObject l;      //宠物UI模型--狮子
    GameObject e;
    GameObject f;

    GameObject Lionmid;  
    GameObject Elfmid;
    GameObject Fairymid;

    //判断第几次召出宠物，第一次只生成新的，之后就只控制隐藏和显示
    int i = 0;
    int y = 0;
    int z = 0;
    private void Awake()
    {
        _petInvokeAndRecall = this;
        invoke = transform.Find("PetInvoke").GetComponent<Button>();
        recall = transform.Find("PetRecall").GetComponent<Button>();
        hero = GameObject.FindGameObjectWithTag("Player").transform ;
        invoke.onClick.AddListener(InvokePet);
        recall.onClick.AddListener(RecallPet);
    }
    #region 宠物召出
    //宠物召出（如果当宠物面板点击狮子的时候，通过判断狮子UI是存在的即判断当前页面是召唤狮子的页面，然后在来生成狮子）
    public void InvokePet()
    {
        l = GameObject.Find("UILion");
        e = GameObject.Find("UIElf");
        f = GameObject.Find("UIFairy");

        Lionmid = GameObject.Find("Lion(Clone)/Lionmid");
        Elfmid = GameObject.Find("Elf(Clone)/Elfmid");
        Fairymid = GameObject.Find("Fairy(Clone)/Fairymid");

        if (l != null && Lionmid == null)      //如果宠物UI面板是狮子  
        {
            //如果召出次数大于1
            if (i >= 1)
            {
                //显示出狮子
                GameObject.Find("Lion(Clone)").transform.Find("Lionmid").gameObject.SetActive(true);
            }
            else
            {
                PrefabManager.Instance.GetPrefabInstance(ConstDates.Lion, new Vector3(hero.position.x - 2, hero.position.y, hero.position.z - 2), Quaternion.identity);     //生成狮子模型
            }
            //让lion置为false，防止多个UILion出现
            UIPetManager._uiPetManager.lion = false;
            //宠物左上角状态面板的显示
            GameObject.Find("UIPetMain/Panel/PetHeadLionBg").gameObject.SetActive(true);
            //召出按钮次数增加
            i++;
        }
        if (e != null && Elfmid == null)
        {
            if (y >= 1)
            {
                GameObject.Find("Elf(Clone)").transform.Find("Elfmid").gameObject.SetActive(true);
            }
            else
            {
                PrefabManager.Instance.GetPrefabInstance(ConstDates.Elf, new Vector3(hero.position.x - 3, hero.position.y, hero.position.z - 3), Quaternion.identity);
            }
            UIPetManager._uiPetManager.elf = false;
            GameObject.Find("UIPetMain/Panel/PetHeadElfBg").gameObject.SetActive(true);
            y++;
        }
        if (f != null && Fairymid == null)
        {
            if (z >= 1)
            {
                GameObject.Find("Fairy(Clone)").transform.Find("Fairymid").gameObject.SetActive(true);
            }
            else
            {
                PrefabManager.Instance.GetPrefabInstance(ConstDates.Fairy, new Vector3(hero.position.x - 4, hero.position.y, hero.position.z - 2), Quaternion.identity);
            }
            UIPetManager._uiPetManager.fairy = false;
            GameObject.Find("UIPetMain/Panel/PetHeadFairyBg").gameObject.SetActive(true);
            z++;
        }
    }
    #endregion

    #region 宠物召回
    //宠物召回
    public void RecallPet()
    {
        l = GameObject.Find("UILion");
        e = GameObject.Find("UIElf");
        f = GameObject.Find("UIFairy");
        Lionmid = GameObject.Find("Lion(Clone)/Lionmid");
        Elfmid = GameObject.Find("Elf(Clone)/Elfmid");
        Fairymid = GameObject.Find("Fairy(Clone)/Fairymid");

        if (l != null&&Lionmid!=null)
        {
            GameObject.Find("Lion(Clone)/Lionmid").gameObject.SetActive(false);
            GameObject.Find("UIPetMain/Panel/PetHeadLionBg").gameObject.SetActive(false);
        }
        if (e != null&& Elfmid != null)
        {
            GameObject.Find("Elf(Clone)/Elfmid").gameObject.SetActive(false);
            GameObject.Find("UIPetMain/Panel/PetHeadElfBg").gameObject.SetActive(false);
        }
        if (f != null&& Fairymid != null)
        {
            GameObject.Find("Fairy(Clone)/Fairymid").gameObject.SetActive(false);
            GameObject.Find("UIPetMain/Panel/PetHeadFairyBg").gameObject.SetActive(false);
        }
    }
    #endregion

}
