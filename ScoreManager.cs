using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public Text scoreCount;
    int score = 0;
    public Text accuracyText;
    float accuracy = 100;
    float shots = 0;
    float hits = 0;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        scoreCount.text = score.ToString();
        accuracyText.text = "Accuracy: " + accuracy.ToString() + "%";
    }

    public void AddScore()
    {
        score += 1;
        scoreCount.text = score.ToString();
    }

    public void ShotCount()
    {
        shots += 1;
    }

    public void HitCount()
    {
        hits += 1;
    }
    
    public void AccuracyCalc(bool holder)
    {
        if (holder)
        {
            hits += 1;
        }
        else
        {
            shots += 1;
        }
        accuracy = Mathf.Round((hits / shots) * 100);
        accuracyText.text = "Accuracy: " + accuracy.ToString() +"%";
    }
}
