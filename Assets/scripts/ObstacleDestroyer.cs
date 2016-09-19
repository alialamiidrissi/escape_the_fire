using UnityEngine;
using System.Collections;

public class ObstacleDestroyer : Destroyer {

	// Update is called once per frame
	protected override void disable()
    {
        ObstaclePool.disableObject(gameObject);
    }
}
