using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolProperty : MonoBehaviour {
    public PoolObjectType poType;
    public bool isUsed;

    public PoolObjectType PoType
    {
        get { return poType; }
        set { poType = value; }
    }

    public bool IsUsed
    {
        get { return isUsed; }
        set { isUsed = value; }
    }

    public void init(bool isUsed,Vector3 position, Quaternion rotation, Vector3 scale, Transform parent = null)
    {
        this.isUsed = isUsed;
        transform.position = position;
        transform.rotation = rotation;
        transform.localScale = scale;
        if (null != parent) transform.parent = parent;
    }
}
