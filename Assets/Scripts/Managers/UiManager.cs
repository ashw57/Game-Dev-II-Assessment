using TMPro;
using UnityEngine;

public class UiManager : Singleton<UiManager>
{
    public TMP_Text scoreText;
    public TMP_Text targetText;

    public void Start()
    {
        UpdateScore(0);
        UpdateTarget(0);

        if (_GM.currentGameState == GameState.Start)
            Cursor.lockState = CursorLockMode.None;
        if (_GM.currentGameState == GameState.Playing)
            Cursor.lockState = CursorLockMode.Locked;
    }

    public void UpdateScore(int _score)
    {
        scoreText.text = "Score: " + _score;
    }

    public void UpdateTarget(int _targetCount)
    {
        targetText.text = "Targets: " + _targetCount;
    }
}
