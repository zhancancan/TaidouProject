using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PetEquipPopup : MonoBehaviour
{
    public static PetEquipPopup _petEquipPopup;
    
     
    private InventoryItem it;
    private Image petEquipBG;
    private Text petEquipText;
    private Text petQualityText;
    private Text petDamageText;
    private Text petHpText;
    private Text petDesText;
    private Text petPowerText;
    private Text petLevelText;
    private Button petEquipbtn;
    private Button closeBtn;

  
    void Awake()
    {
        _petEquipPopup = this;
        petEquipBG = transform.Find("PetEquiptInf/PetEquipBg").GetComponent<Image>();
        petEquipText = transform.Find("PetEquiptInf/PetIntroduction/PetEquipText").GetComponent<Text>();
        petQualityText= transform.Find("PetEquiptInf/PetIntroduction/PetQualityText/Text").GetComponent<Text>();
        petDamageText= transform.Find("PetEquiptInf/PetIntroduction/PetDamageText/Text").GetComponent<Text>();
        petHpText= transform.Find("PetEquiptInf/PetIntroduction/PetHpText/Text").GetComponent<Text>();
        petDesText= transform.Find("PetEquiptInf/PetIntroduction/PetDesText").GetComponent<Text>(); 
        petPowerText= transform.Find("PetEquiptInf/PetIntroduction/PetPowerText/Text").GetComponent<Text>();
        petLevelText= transform.Find("PetEquiptInf/PetIntroduction/PetLevelText/Text").GetComponent<Text>();
        petEquipbtn = transform.Find("PetEquiptInf/Petequipbtn").GetComponent<Button>();
        closeBtn = transform.Find("PetEquiptInf/Close").GetComponent<Button>();
    }

    public void Show(object[] objectarray)
    {
        InventoryItem it = objectarray[0] as InventoryItem;
        gameObject.SetActive(true);
        this.it = it;
        petEquipBG.sprite = it.Inventory.Icon;
        petEquipText.text = it.Inventory.Name;
        petQualityText.text = it.Inventory.Quality.ToString() ;
        petDamageText.text = it.Inventory.Damage.ToString();
        petHpText.text = it.Inventory.Hp.ToString();
        petDesText.text = it.Inventory.Des;
        petPowerText.text = it.Inventory.Power.ToString();
        petLevelText.text = it.Inventory.Startlevel.ToString();

        petEquipbtn.onClick.AddListener(Unload);
        closeBtn.onClick.AddListener(closeWindow);
    }

    void Unload()
    {
        transform.Find("PetEquiptInf").gameObject.SetActive(false);
        transform.parent.Find("Panel/EquipBG/PetWeapon").SendMessage("CleanPetEquipUI");
        
        if (IsClothBtnDown._isBtnDown.btnDown)
        {
            transform.parent.Find("Panel/EquipBG/PetCloth").SendMessage("CleanPetEquipUI");
            
        }
        IsClothBtnDown._isBtnDown.btnDown = false;
    }
    void closeWindow()
    {
        transform.Find("PetEquiptInf").gameObject.SetActive(false);
    }
}
