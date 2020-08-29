using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    int score = 0;
    // Start is called before the first frame update
    void Awake()
    {
        SetUpSingleton();
    }
    public void SetUpSingleton()
    {
        int numberGameSessions = FindObjectsOfType<GameSession>().Length;
        if (numberGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public int GetScore()
    {
        return this.score;
    }
    public void AddToScore(int points)
    {
        score = score + points;
    }
    public void ResetGame()
    {
        Destroy(gameObject);
    }
}
