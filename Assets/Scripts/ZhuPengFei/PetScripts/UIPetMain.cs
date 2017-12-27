using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPetMain : MonoBehaviour
{
    private RawImage petHeadIconImg;
    private Text petLevel;
    private Image petHPImg;
    private Text petHPCount;
    private Image petEnergyImg;
    private Text petEnergyCount;

    private void Awake()
    {
        petHeadIconImg = transform.Find("PetHeadBg/PetHeadIconImg").GetComponent<RawImage>();
        petLevel = transform.Find("PetHeadBg/PetLevel").GetComponent<Text>();
        petHPImg = transform.Find("PetHeadBg/PetHPImg").GetComponent<Image>();
        petHPCount = transform.Find("PetHeadBg/PetHPCount").GetComponent<Text>();
        petEnergyImg = transform.Find("PetHeadBg/PetEnergyImg").GetComponent<Image>();
        petEnergyCount = transform.Find("PetHeadBg/PetEnergyCount").GetComponent<Text>();
        //注册事件
        PetInfo._petInstance.OnPetInfoChanged += this.OnPetInfoChangedMain;
    }


    void OnDestroy()
    {
        PetInfo._petInstance.OnPetInfoChanged -= this.OnPetInfoChangedMain;
    }

    void OnPetInfoChangedMain(PetInfoType type)
    {
        if (type == PetInfoType.PetHead || type == PetInfoType.PetHP || type == PetInfoType.PetEnergy || type == PetInfoType.StarLevel || type == PetInfoType.All)
        {
            UpdateShowUIPetMain();
        }
    }

    void UpdateShowUIPetMain()
    {
        PetInfo petInfo = PetInfo._petInstance;
        petHeadIconImg.texture = TextureManager.Instance.GetTexture(ConstDates.ResourceTexturesDirZpf, ConstDates.Head_Elf);
        petLevel.text = petInfo.StarLevelNum.ToString();
        petHPCount.text = petInfo.PetHP+"/100";
        petHPImg.fillAmount = petInfo.PetHP / 100.0f;
        petEnergyCount.text = petInfo.PetEnergy + "/100";
        petEnergyImg.fillAmount = petInfo.PetEnergy / 100.0f;
    }
}
