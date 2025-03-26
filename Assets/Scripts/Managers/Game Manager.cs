using UnityEngine;

public enum GameState
{
    Start,
    Playing,
    Paused
}

public enum Difficulty
{
    Easy,
    Medium,
    HardOn
}
public class GameManager : Singleton<GameManager>
{

    [SerializeField]
    public GameState currentGameState;
    [SerializeField]
    private Difficulty difficulty;
    [SerializeField]
    private int score;

public void AddScore(int _score)
    {
        score += _score;
        _UI.UpdateScore(score);
    }
}
