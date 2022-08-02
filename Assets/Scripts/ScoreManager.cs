using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    [SerializeField] int leftScore;
    [SerializeField] int rightScore;

    [SerializeField] int maxScore;


    [SerializeField] Text rightScore_text, leftScore_text;
    [SerializeField] Text maxScore_text;
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        maxScore_text.text = maxScore.ToString();
    }
    public void IncreaseScore(bool forRight)
    {
        if (forRight) rightScore++;
        else leftScore++;

        if (rightScore >= maxScore) GameOver(true);
        if (leftScore >= maxScore) GameOver(false);

        rightScore_text.text = rightScore.ToString();
        leftScore_text.text = leftScore.ToString();

    }

    void GameOver(bool isRightWin)
    {
        SceneManager.LoadScene("MainMenu");
    }
}
