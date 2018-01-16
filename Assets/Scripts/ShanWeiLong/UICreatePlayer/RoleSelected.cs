using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoleSelected : MonoBehaviour {

    public  Text PersonName;
    public  Text profession;
    public  Image seximg;
    public Text level;
    public GameObject[] go;
    GameObject born;
    Button show;
    private void Awake()
    {
        PersonName = transform.Find("PersonName").GetComponent<Text>();
        profession = transform.Find("PersonPosition").GetComponent<Text>();
        level = transform.Find("PersonLevel").GetComponent<Text>();
        seximg = transform.Find("PersonHead").GetComponent<Image>();
        born = GameObject.Find("born").gameObject;
        show = GetComponent<Button>();
        show.onClick.AddListener(UpdateShow);
    }
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    GameObject showrole;
    void UpdateShow()
    {
        if (GameObject.FindGameObjectWithTag("Role"))
        {
            showrole = GameObject.FindGameObjectWithTag("Role");
            Destroy(showrole);
        }


        if (profession.text.Contains("战士"))
        {
            if (!GameObject.FindGameObjectWithTag("Role"))
            {
                if (seximg.sprite.name.Contains("女性"))
                {
                    Instantiate(go[4], born.transform.position, Quaternion.Euler(0, -180, 0));
                }
                else
                {
                    Instantiate(go[5], born.transform.position, Quaternion.Euler(0, -180, 0));
                }
            }
        }
        else if(profession.text.Contains("法师") )
        {
            if (seximg.sprite.name.Contains("女性"))
            {
                Instantiate(go[2], born.transform.position, Quaternion.Euler(0, -180, 0));
            }
            else
            {
             Instantiate(go[3], born.transform.position, Quaternion.Euler(0, -180, 0));
            }
        }
        else if(profession.text.Contains("弓箭手") )
        {
            if (seximg.sprite.name.Contains("女性"))
            {
              Instantiate(go[0], born.transform.position, Quaternion.Euler(0, -180, 0));
            }
            else
            {
               Instantiate(go[1], born.transform.position, Quaternion.Euler(0, -180, 0));
            }
        }
        else
        {
            return;
        }
        
    }
}
