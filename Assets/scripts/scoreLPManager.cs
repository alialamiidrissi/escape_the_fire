using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreLPManager : MonoBehaviour
{
    private float lifePoints;
    private int score;
    private int highScore;
    public Text scoreDisp;
    public GameObject screen;
    private HealthBarController healthBarController;
    public GameObject player;
    // Use this for initialization
    void Start()
    {
        lifePoints = 100;
        score = 0;
        highScore = 0;

        healthBarController = FindObjectOfType<HealthBarController>();
    }

    // Update is called once per frame
    void Update()
    {
        highScore = Mathf.Max(score, highScore);
        scoreDisp.text = score.ToString();
    }

    public float LifePoints
    {
        get
        {
            return lifePoints;
        }

    }

    public int Score
    {
        get
        {
            return score;
        }
    }

    public void increaseScore(int amount)
    {
        score += amount;
    }
    public void decreaseLifePoint(float amount)
    {
        if (lifePoints - amount > 0f)
        {
            lifePoints -= amount;
            healthBarController.healthWidth = (int)(lifePoints / 100 * healthBarController.getInitialHealthWidth());
        }
        else
        {
            Utilities.pauseOrDie(player, screen,"You lost all your life points !");
        }
    }
    public void increaseLifePoints(float amount)
    {
        if (lifePoints + amount < 100f)
            lifePoints += amount;
        else
            lifePoints = 100f;
        healthBarController.healthWidth = (int)((lifePoints /100f) * healthBarController.getInitialHealthWidth());
    }
}
