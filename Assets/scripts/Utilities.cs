using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public  static class Utilities {

    public static int choose(float[] probs)
    {

        float total = 0;

        foreach (float elem in probs)
        {
            total += elem;
        }

        float randomPoint = Random.value * total;

        for (int i = 0; i < probs.Length; i++)
        {
            if (randomPoint < probs[i])
            {
                return i;
            }
            else
            {
                randomPoint -= probs[i];
            }
        }
        return probs.Length - 1;
    }
    public static void pauseOrDie(GameObject player,GameObject screen,string reason = null)
    {
        screen.SetActive(true);
        player.SetActive(false);
        if(reason != null)
        {
            Text text = GameObject.Find("Reason").GetComponent<Text>();
            text.text = reason;
            GameObject fireBlast= GameObject.Find("FireBlastDanger");
            GameObject fire = GameObject.Find("FireDanger");
            if (fireBlast != null)
                fireBlast.SetActive(false);
            if (fire != null)
                fire.SetActive(false);
            UIManager.paused = true;
        }
    }
}
