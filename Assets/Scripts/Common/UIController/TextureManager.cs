﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureManager : MonoBehaviour
{
    //单例
    private static TextureManager _instance;
    public static TextureManager Instance
    {
        get
        {
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }

    public Texture GetTexture(string selfPath,string name)
    {
        string path = selfPath + "/" + name;
        Texture texture = Resources.Load<Texture>(path);
        return texture;
    }

}