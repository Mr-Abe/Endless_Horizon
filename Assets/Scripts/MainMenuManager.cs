using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void LoadGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void LoadOptions()
    {
        Debug.Log("Options menu not yet implemented.");
        //SceneManager.LoadScene("");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
