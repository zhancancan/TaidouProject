using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShortCutItem : MonoBehaviour {
    private Transform uiTop;//UI界面的最上层

    public CanvasGroup canvasGroup;
    public Image shutCutImg;
    public int shutCutGoodsId = 0;
    public ShutCutType shutCutType = ShutCutType.None;

    void Awake()
    {
        uiTop = GameObject.FindGameObjectWithTag(Tags.UITop).transform;
        shutCutImg = transform.Find("ShutCut").GetComponent<Image>();
        shutCutImg.gameObject.tag = Tags.ShutCut;
        canvasGroup = shutCutImg.GetComponent<CanvasGroup>();
       
        EventTriggerListener.GetListener(shutCutImg.gameObject).onBeginDrag += OnBeginDrag;
        EventTriggerListener.GetListener(shutCutImg.gameObject).onDrag += OnDrag;
        EventTriggerListener.GetListener(shutCutImg.gameObject).onEndDrag += OnEndDrag;
    }

    //通过Id，添加技能
    public void AddSkillIcon(int id)
    {
        Skill skill = SkillInfoData.GetInstance().GetSkillInfoById(id);

        this.shutCutGoodsId = id;
        this.shutCutType = ShutCutType.Skill;
        this.shutCutImg.sprite = TextureManager.Instance.GetSprite(ConstDates.ResourceSpritesDirSwl, skill.iconName);
        this.canvasGroup.alpha = 1;
        this.shutCutImg.transform.SetParent(this.transform);
        this.shutCutImg.transform.localPosition = Vector3.zero;
    }

    //移除技能
    public void RemoveSkill()
    {
        this.shutCutGoodsId = 0;
        this.shutCutType = ShutCutType.None;
        this.shutCutImg.sprite = null;
        this.canvasGroup.alpha = 0;
        this.shutCutImg.transform.SetParent(this.transform);
        this.shutCutImg.transform.localPosition = Vector3.zero;
    }

    ////通过Id，添加药品
    //public void AddDrugIcon(int id)
    //{
    //    ObjectsInfoClass info = ObjectsInfo._instance.GetObjectsInfoById(id);
    //    if (info.type == ObjectsTypeInfo.Drug)
    //    {
    //        UISprite sprite = this.transform.Find("ShutCutIcon").GetComponent<UISprite>();
    //        sprite.enabled = true;
    //        sprite.spriteName = info.icon_name;

    //        this.id = id;
    //        type = ShutCutType.drug;
    //    }
    //}

    ////移除药品
    //public void RemoveDrug()
    //{
    //    UISprite sprite = this.transform.Find("ShutCutIcon").GetComponent<UISprite>();
    //    sprite.enabled = false;
    //}

    //开始拖拽
    private void OnBeginDrag(GameObject go, PointerEventData eventData)
    {
        this.shutCutImg.transform.SetParent(uiTop);
        this.shutCutImg.GetComponent<CanvasGroup>().blocksRaycasts = false;//忽略射线
    }

    //拖拽中
    private void OnDrag(GameObject go, PointerEventData eventData)
    {
        this.shutCutImg.transform.position = eventData.position;//创建的图标跟随随便移动
    }

    //拖拽结束
    private void OnEndDrag(GameObject go, PointerEventData eventData)
    {
        GameObject point = eventData.pointerEnter;//拖拽结束后，判断鼠标点击到的物体
        if (null != point && point.tag == Tags.ShutCut)//判断是否放在了技能背景框上
        {
            CanvasGroup groupOther = point.GetComponent<CanvasGroup>();//获取点击到快捷键图片上的CanvasGroup
            ShortCutItem otherShutCutItem = point.transform.parent.GetComponent<ShortCutItem>(); //获取快捷键上的ShutCutItem脚本
            if (0 == groupOther.alpha)//当前快捷键为空，将之前快捷键移到现在的位置
            {
                otherShutCutItem.AddSkillIcon(this.shutCutGoodsId);//显示快捷
                this.RemoveSkill();//将被拖动的快捷键信息滞空
            }
            else//已经有快捷键，调换快捷键位置
            {
                switch (this.shutCutType)//当前快捷键类型
                {
                    case ShutCutType.Skill:
                        if (ShutCutType.Skill == otherShutCutItem.shutCutType)//替换位置快捷键类型
                        {
                            int shutCutGoodsIdTemp = otherShutCutItem.shutCutGoodsId;
                            otherShutCutItem.AddSkillIcon(this.shutCutGoodsId);
                            this.AddSkillIcon(shutCutGoodsIdTemp);
                        }
                        else if (ShutCutType.Drug == otherShutCutItem.shutCutType)
                        {
                            
                        }
                        break;
                    case ShutCutType.Drug:
                        if (ShutCutType.Skill == otherShutCutItem.shutCutType)
                        {

                        }
                        else if (ShutCutType.Drug == otherShutCutItem.shutCutType)
                        {

                        }
                        break;
                }
            }
        }
        else//拖放到了快捷键其他的位置
        {
            this.shutCutImg.transform.SetParent(this.transform);
            this.shutCutImg.transform.localPosition = Vector3.zero;
        }
        shutCutImg.GetComponent<CanvasGroup>().blocksRaycasts = true;//忽略射线
    }
}
