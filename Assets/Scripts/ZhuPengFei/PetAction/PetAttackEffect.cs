using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetAttackEffect : MonoBehaviour {

    GameObject Enemy;
    private void Awake()
    {
        Enemy = GameObject.FindGameObjectWithTag("Enemy");
    }

    public void Elf(GameObject obj)
    {
        if (Enemy == null)
        {
            Enemy = GameObject.FindGameObjectWithTag("Enemy");
        }

        GameObject l = PrefabManager.Instance.GetPrefabInstance(ConstDates.ElfEffect, Enemy.transform.position, Quaternion.identity);
        Destroy(l, 0.5f);

    }

    public void Fairy(GameObject obj)
    {
        if (Enemy == null)
        {
            Enemy = GameObject.FindGameObjectWithTag("Enemy");
        }
        GameObject l = PrefabManager.Instance.GetPrefabInstance(ConstDates.FairyEffect, Enemy.transform.position, Quaternion.identity);      
        Destroy(l, 0.5f);

    }

    public void Lion(GameObject obj)
    {
        if (Enemy == null)
        {
            Enemy = GameObject.FindGameObjectWithTag("Enemy");
        }
        GameObject l = PrefabManager.Instance.GetPrefabInstance(ConstDates.LionEffect, Enemy.transform.position, Quaternion.identity);
        Destroy(l, 0.5f);

    }
}
