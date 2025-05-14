using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgain : MonoBehaviour
{
    // Перезапуск текущей сцены
    public void playAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Загрузка следующей сцены по порядку в Build Settings
    public void nextScene()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;

        // Если текущая сцена — Level3, загружаем Win
        if (currentSceneName == "Level3")
        {
            SceneManager.LoadScene("Win");
            return;
        }

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.Log("Следующей сцены не существует. Убедись, что она добавлена в Build Settings.");
        }
    }

    // Загрузка предыдущей сцены по порядку
    public void prevScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int prevSceneIndex = currentSceneIndex - 1;

        if (prevSceneIndex >= 0)
        {
            SceneManager.LoadScene(prevSceneIndex);
        }
        else
        {
            Debug.Log("Предыдущей сцены не существует.");
        }
    }

    // При необходимости — явная загрузка Level3
    public void LoadLevel3()
    {
        SceneManager.LoadScene("Level3");
    }

    // Явная загрузка сцены победы
    public void LoadWinScene()
    {
        SceneManager.LoadScene("Win");
    }
}
