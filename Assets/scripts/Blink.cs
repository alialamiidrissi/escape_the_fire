using UnityEngine;
using System.Collections;
using System;

public class Blink : MonoBehaviour {
    private GameObject [] childs;
    private float startTime;
    private float startActiveTime;
    private PlayerController player;
    int toBlink;
	// Use this for initialization
	void Start () {
        player = FindObjectOfType<PlayerController>();
        childs = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            childs[i] = transform.GetChild(i).gameObject;
            childs[i].SetActive(false);
        }
        startTime = Time.time;
        startActiveTime = -1;
        toBlink = player.HitCount > 0 ? 0 : 1;

	}
	
	// Update is called once per frame
	void Update () {
        float timeAc = Time.time;
        toBlink = player.HitCount > 0 ? 1 : 0;
        childs[Math.Abs(toBlink - 1)].SetActive(false);
        if (timeAc-startTime > 0.2)
        {
            childs[toBlink].SetActive(true);
            startTime = timeAc+0.2f;
            startActiveTime = timeAc;
  
        }
        if(childs[toBlink].activeSelf && timeAc-startActiveTime >0.2)
        {
            childs[toBlink].SetActive(false);
            startActiveTime = -1;
        }
	}
}
