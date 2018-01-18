using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SkillItem : MonoBehaviour
{
    private GameObject player;
    private Transform uiTop;//UI界面的最上层
    private PlayerStatus playerStatus;

    private GameObject skillImgObj;//技能对应的图片实例
    private Image skillImage;
    private Image skillMask;
    private Text skillName;
    private Text skillLevel;

    public int SkillId { get; set; }

	void Awake ()
	{
	    uiTop = GameObject.FindGameObjectWithTag(Tags.UITop).transform;
        player = GameObject.FindGameObjectWithTag(Tags.Player).gameObject;
	    playerStatus = player.GetComponent<PlayerStatus>();

	    skillMask = transform.Find("SkillMask").GetComponent<Image>();
	    skillImage = transform.Find("SkillImg").GetComponent<Image>();
	    skillName = transform.Find("SkillName").GetComponent<Text>();
	    skillLevel = transform.Find("SkillLevel").GetComponent<Text>();
    }

    void Start()
    {
        Init();
        EventTriggerListener.GetListener(skillImage.gameObject).onBeginDrag += OnBeginDrag;
        EventTriggerListener.GetListener(skillImage.gameObject).onDrag += OnDrag;
        EventTriggerListener.GetListener(skillImage.gameObject).onEndDrag += OnEndDrag;
    }

    //初始化技能Item界面的显示
    void Init()
    {
        Skill skill = SkillInfoData.GetInstance().GetSkillInfoById(SkillId);
        skillImage.sprite = TextureManager.Instance.GetSprite(ConstDates.ResourceSpritesDirSwl,skill.iconName);
        skillName.text = skill.name;
        skillLevel.text = skill.level.ToString();
        if (playerStatus.level >= skill.level)
            skillMask.enabled = false;
        else
            skillMask.enabled = true;
    }

    //开始拖拽
    private void OnBeginDrag(GameObject go, PointerEventData eventData)
    { 
        //创建一个对应于该技能的图标
        skillImgObj = UIManager.Instance.GetUIPrefabInstance(ConstDates.UISkillPic, eventData.position, Quaternion.identity, uiTop, ConstDates.UISkillPic);
        skillImgObj.GetComponent<Image>().sprite = skillImage.sprite;
        skillImgObj.GetComponent<CanvasGroup>().blocksRaycasts = false;//忽略射线
        skillImgObj.transform.localScale = Vector3.one;
    }

    //拖拽中
    private void OnDrag(GameObject go, PointerEventData eventData)
    {
        skillImgObj.transform.position = eventData.position;//创建的图标跟随随便移动
    }

    //结束拖拽
    private void OnEndDrag(GameObject go, PointerEventData eventData)
    {
        GameObject point = eventData.pointerEnter;//拖拽结束后，判断鼠标点击到的物体
        if (null != point && point.tag == Tags.ShutCut)//判断是否放在了技能背景框上
        {
            //CanvasGroup shutCutCanvaGroup = point.GetComponent<CanvasGroup>();//获取点击到快捷键图片上的CanvasGroup
            point.transform.parent.GetComponent<ShutCutItem>().AddSkillIcon(this.SkillId);//添加技能到快捷键
        }
        Destroy(skillImgObj);//销毁跟随鼠标的技能图片对象
    }
}
