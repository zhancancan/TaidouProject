using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISkill : UIBase
{
    private PlayerStatus playerStatus;

    private GameObject palyer;
    private Transform skillItemParent;//技能的父层级
    private Button exit;

    private List<Image> skillMaskList = new List<Image>();//技能遮罩

    void Awake()
    {
        palyer = GameObject.FindGameObjectWithTag(Tags.Player);
        playerStatus = palyer.GetComponent<PlayerStatus>();

        skillItemParent = transform.Find("SkillWindow/SkillBg/Skill/Content");
        exit = transform.Find("SkillWindow/CloseBTN").GetComponent<Button>();

        //查找所有技能的遮罩
        foreach (Transform item in skillItemParent.transform)
        {
            skillMaskList.Add(item.Find("SkillMask").GetComponent<Image>());
        }

        InitSkillUI();//测试放在start，之后放在awake，因为技能加载慢了
    }

	void Start () {
	    exit.onClick.AddListener(()=> {UIManager.Instance.PopUIPanel();});
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

    //根据角色类型初始化技能面板
    void InitSkillUI()
    {
        switch (playerStatus.roleType)
        {
            case RoleType.Mage: //法师技能
                AddSkill(SkillInfoData.GetInstance().mageSkillIdArr, skillItemParent);
                break;
            case RoleType.Warrior://战士技能
                AddSkill(SkillInfoData.GetInstance().warriorSkillIdArr, skillItemParent);
                break;
            case RoleType.Archer://射手技能
                AddSkill(SkillInfoData.GetInstance().archerSkillIdArr, skillItemParent);
                break;
        }
    }

    //添加技能到技能面板
    void AddSkill(List<int> skillList,Transform parent)
    {
        for (int i = 0; i < skillList.Count; i++)
        {
            GameObject skillTemp = UIManager.Instance.GetUIPrefabInstance(ConstDates.UISkillItem,parent, ConstDates.UISkillItem);
//            skillTemp.GetComponent<UISkillItem>().enabled = false;//实例化skillItem之后，之后先运行Awake
            skillTemp.GetComponent<SkillItem>().SkillId = skillList[i];//赋值Id
//            skillTemp.GetComponent<UISkillItem>().enabled = true;//skillItem，运行Start，这时候才根据技能Id，加载获取技能初始化界面
        }
    }
}
