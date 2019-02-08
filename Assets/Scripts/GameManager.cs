using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    // Use this for initialization
    public float currentStageTime;
    public float maxStageTime = 30f;
    public bool canMoveOn { get; private set; }
    private float healthIncrementor = 1;
    public float level, Score;
    public Text scoreText;
    public float delaynewStagestartMax=5;
    public float currentdelaytStageStart;
    void Start () {
        currentdelaytStageStart = delaynewStagestartMax;
        canMoveOn = false;
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        currentStageTime = maxStageTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentStageTime <= 0)
        {
            currentStageTime = maxStageTime;
            canMoveOn = true;
        }
        if (canMoveOn)
        {
            currentdelaytStageStart -= Time.deltaTime;
            if (currentdelaytStageStart <= 0)
            {
                ResetCanMove();
                currentdelaytStageStart = delaynewStagestartMax;
            }
        }
        if (!canMoveOn)
        {
            currentStageTime -= Time.deltaTime;
        }
    }
    public void ResetCanMove () {
        canMoveOn = false;
    }
    public float GetHealthLevel () {
        return healthIncrementor;
    }
    public void UpdateScore(int amount)
    {
        Score+=amount;
        scoreText.text = Score.ToString();
    }
}