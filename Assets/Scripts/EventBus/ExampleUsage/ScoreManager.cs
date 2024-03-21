using UnityEngine;

//Class for handling the score logic.
public class ScoreManager : MonoBehaviour
{
    [SerializeField] private int score;

    //Method to update the score with the given amount.
    public void UpdateScore(int amount)
    {
        score += amount;
    }

    //Method to get the current score.
    public int GetScore()
    {
        return score;
    }
}
