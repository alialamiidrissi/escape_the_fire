using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPool : MonoBehaviour {
    protected List<GameObject> pool;
    protected int poolSize;
    public GameObject original_obj;
    // Use this for initialization
   protected virtual void Start() {
        poolSize = 5;
        pool = new List<GameObject>();
        for (int i = 0; i < poolSize; i++) {
            createObject();
        }

    }

    public  GameObject getObject()
    {
        for (int i = 0; i < poolSize; i++)
        {
            if (!pool[i].activeInHierarchy)
                return pool[i];
        }
        poolSize++;
        return createObject();

    }
    protected GameObject createObject()
    {
        GameObject obj =(GameObject) Instantiate(original_obj);
        obj.SetActive(false);
        pool.Add(obj);
        return obj;
    }
}
