using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;


    [SerializeField] int leftScore;
    [SerializeField] int rightScore;

    [SerializeField] int maxScore;

    private void Awake()
    {
        Instance = this;
    }
    public void IncreaseScore(bool forRight)
    {
        if (forRight) rightScore++;
        else leftScore++;

        if (rightScore >= maxScore) GameOver(true);
        if (leftScore >= maxScore) GameOver(false);

    }

    void GameOver(bool isRightWin)
    {
        SceneManager.LoadScene("MainMenu");
    }
}
