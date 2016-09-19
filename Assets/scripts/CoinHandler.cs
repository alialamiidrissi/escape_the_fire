using UnityEngine;
using System.Collections;

public class CoinHandler : MonoBehaviour {

	// Use this for initialization

   void OnCollisionEnter2D(Collision2D coll)
    {
            print("entered");
            gameObject.SetActive(false);
    }
}
