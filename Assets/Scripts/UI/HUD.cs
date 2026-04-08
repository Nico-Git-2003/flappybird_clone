using System;
using UnityEngine;
using TMPro;

public class HUD : MonoBehaviour
{
    public TMP_Text scoreText;

    private void Start()
    {
        GameManager.Instance.ResetScore();
    }

    private void Update()
    {
        scoreText.text = "Score: " + GameManager.Instance.Score;
    }
}
