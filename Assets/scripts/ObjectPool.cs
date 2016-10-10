using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPool : MonoBehaviour {
    protected List<GameObject> pool;
    protected int poolSize;
    public GameObject original_obj;
    private GameObject bigContainer;
    // Use this for initialization
    protected virtual void Start() {
        bigContainer = GameObject.Find("GameComponent");
        pool = new List<GameObject>();
        for (int i = 0; i < poolSize; i++) {
            createObject();
        }

    }

    public GameObject getObject()
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
        GameObject obj = (GameObject)Instantiate(original_obj);
        obj.transform.parent = bigContainer.transform;
       // obj.transform.localScale = new Vector3(obj.transform.localScale.x * 0.5f, obj.transform.localScale.y * 0.5f, obj.transform.localScale.z * 0.5f);
        obj.SetActive(false);
        pool.Add(obj);
        return obj;
    }
    public virtual void enableObject(GameObject obstacle)
    {
        obstacle.SetActive(true);
    }

}

