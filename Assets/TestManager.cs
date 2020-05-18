using UnityEngine;
using UnityEngine.SceneManagement;
public class TestManager : MonoBehaviour
{
    public void EndGame()
    {
        Invoke("GotoMenuScene", 2f);
    }

    void GotoMenuScene()
    {
        SceneManager.LoadScene(0);
    }
}
