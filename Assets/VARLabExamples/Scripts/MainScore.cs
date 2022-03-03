using System.Collections;
using System.Collections.Generic;
using TigerTail;
using UnityEngine;
using TMPro;
public class MainScore : MonoBehaviour
{
    private int totalScore = 0;
    private string message = string.Empty;

    [SerializeField] private TextMeshProUGUI mScore;
    [SerializeField] private TextMeshProUGUI msgLabel;
    [SerializeField] private GameObject enemyGenerator;


    private void Awake()
    {
        SetScoreUI();
    }

    private void SetScoreUI()
    {
        mScore.text = $"Score: {totalScore}";
        StartCoroutine(Feedback());
       
        
    }

    IEnumerator Feedback()
    {
        msgLabel.text = message;
        yield return new WaitForSeconds(3f);
        msgLabel.text = "";
    }

    public void AddScore(int score, string msg)
    {

        totalScore += score;
        if (enemyGenerator.GetComponent<EnemyGenerator>().maxEnemies==totalScore)
        {
            message = "WINNER !!!";
            Time.timeScale = 0;
        }

        else
        {
            message = msg;
        }
        
        SetScoreUI();
        StopCoroutine(Feedback());
    }
}