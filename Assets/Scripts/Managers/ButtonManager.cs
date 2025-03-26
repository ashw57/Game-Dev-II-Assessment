using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : Singleton<ButtonManager>
{
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("TitleScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
