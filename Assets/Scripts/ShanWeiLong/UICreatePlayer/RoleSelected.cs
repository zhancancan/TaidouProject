using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoleSelected : MonoBehaviour {

    public  Text PersonName;
    public  Text profession;
    public  Image seximg;
    public Text level;
    private void Awake()
    {
        PersonName = transform.Find("PersonName").GetComponent<Text>();
        profession = transform.Find("PersonPosition").GetComponent<Text>();
        level = transform.Find("PersonLevel").GetComponent<Text>();
        seximg = transform.Find("PersonHead").GetComponent<Image>();
    }
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void UpdateShow()
    {
        string name= PlayerPrefs.GetString("username");
        string profess= PlayerPrefs.GetString("profession");
        PersonName.text = name;
        profession.text = "<color=#F1FF00FF>" + profess+ "</color>";
        
    }
}
