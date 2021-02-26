using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoresession : MonoBehaviour
{
    int score = 0;
    void Awake()
    {
        SetUpSingleton();
    }

    private void SetUpSingleton()
    {
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public int currentscore()
    {
        return score;
    }

    public void UpdateScore(int point)
    {
        score += point;
        print("Gooaaal!");
        if (score == 20)
        {
            FindObjectOfType<winload>().Loadwin();
        }
    }
}
