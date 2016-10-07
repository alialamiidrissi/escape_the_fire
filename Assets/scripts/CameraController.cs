using UnityEngine;
using System.Collections;
using System;

public class CameraController : MonoBehaviour
{
    private PlayerController player;

    private Vector3 lastpos;
    private float dx;
    public float shift;
    public float toShift;
    public Rigidbody2D rb;
    // Use this for initialization
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        lastpos = player.transform.position;
        rb = GetComponent<Rigidbody2D>();
    }

    public void shiftRight(float v)
    {
        if (shift - v > 0)
        {
            toShift += v;
            //cameraD.transform.Translate(new Vector3(-2.5f, 0, 0));
        }
        else
        {
            // cameraD.transform.Translate(new Vector3(-cameraD.shift, 0, 0));
            toShift = shift;
        }
    }

    // Update is called once per frame
    void Update()
    {
        dx = player.transform.position.x - lastpos.x;
        transform.position = new Vector3(transform.position.x + dx, transform.position.y, transform.position.z);
        lastpos = player.transform.position;
        if (toShift > 0)
        {
            float shiftValue = Time.deltaTime * 2.5f;
            if (toShift - shiftValue > 0)
                toShift -= shiftValue;
            else
                shiftValue = toShift;
            toShift-=shiftValue;
            shift -= shiftValue;

            transform.Translate(new Vector3(-shiftValue, 0, 0));
        }
    }
}
