using UnityEngine;
using UnityEngine.SceneManagement;

public class InputManager : Singleton<InputManager>
{
    // Update is called once per frame
    void Update()
    {
        if (_GM.currentGameState == GameState.Playing)
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                print("Cheese");
                _TM.SpawnTarget();
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene("TitleScene");
                _GM.currentGameState = GameState.Start;
            }
                
        }
            
    }
}
