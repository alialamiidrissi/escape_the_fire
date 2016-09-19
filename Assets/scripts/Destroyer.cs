using UnityEngine;
using System.Collections;

public class Destroyer : MonoBehaviour
{
    GameObject destructionPoint;
    // Use this for initialization
    void Start()
    {
        destructionPoint = GameObject.Find("DestructionPoint");
    }

    // Update is called once per frame
    void  Update()
    {
        if (transform.position.x < destructionPoint.transform.position.x)
        {
            disable();  
        }
    }

    protected virtual void disable()
    {
        
            gameObject.SetActive(false);

    }
}