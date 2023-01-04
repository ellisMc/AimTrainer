using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public void Hit()
    {
        transform.position = TargetBounds.Instance.GetRandomPosition();
        ScoreManager.instance.AddScore();
        ScoreManager.instance.AccuracyCalc(true);
    }
}
