using UnityEngine;
using System.Collections;

public class CameraSetting : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
        Camera.main.aspect = 3000f / 1024f;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
