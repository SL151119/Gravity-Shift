using UnityEngine.SceneManagement;

public class LevelRestarter : ILevelRestarter
{
    public void RestartLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadSceneAsync(currentSceneIndex);
    }
}
