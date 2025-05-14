using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LevelManager : MonoBehaviour
{
    private static LevelManager instance = null;
    public int Gold = 100;
    public int LivesLeft = 5;
    public int EnemyLeft = 20;
    public int NextLevel; // Следующий уровень (индекс или название сцены)

    public static LevelManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<LevelManager>();
            }
            return instance;
        }
    }

    [SerializeField] private Transform towerUIParent;
    [SerializeField] private GameObject towerUIPrefab;
    [SerializeField] private Tower[] towerPrefabs;

    private List<Tower> spawnedTowers = new List<Tower>();

    [SerializeField] private GameObject panel;
    [SerializeField] private TMP_Text statusInfo;
    [SerializeField] private TMP_Text LivesText;
    [SerializeField] private TMP_Text TotalEnemyText;
    [SerializeField] private TMP_Text GoldText;
    [SerializeField] private Button nextLevelButton;  // Кнопка для перехода на следующий уровень

    private bool isGameOver = false;

    private void Start()
    {
        InstantiateAllTowerUI();
        nextLevelButton.gameObject.SetActive(false); // Скрываем кнопку на старте
        nextLevelButton.onClick.AddListener(LoadNextLevel); // Привязываем действие к кнопке
    }

    private void Update()
    {
        if (isGameOver) return;

        GoldText.text = "Gold: " + Gold;
        LivesText.text = "Lives: " + LivesLeft;
        TotalEnemyText.text = "Enemies: " + EnemyLeft;

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (LivesLeft <= 0)
        {
            SetGameOver(false); // Проигрыш
        }
        else if (EnemyLeft <= 0)
        {
            SetGameOver(true); // Победа
            Invoke("ShowNextLevelButton", 2f); // Задержка перед появлением кнопки
        }
    }

    private void InstantiateAllTowerUI()
    {
        foreach (Tower tower in towerPrefabs)
        {
            GameObject newTowerUIObj = Instantiate(towerUIPrefab.gameObject, towerUIParent);
            TowerUI newTowerUI = newTowerUIObj.GetComponent<TowerUI>();
            newTowerUI.SetTowerPrefab(tower);
            newTowerUI.transform.name = tower.name;
        }
    }

    public void LoadNextLevel()
    { 
        if (NextLevel >= 0)
        {
            // Загружаем следующий уровень по индексу
            SceneManager.LoadScene(NextLevel);
        }
        else
        {
            Debug.LogError("NextLevel не установлен! Убедитесь, что вы задали индекс или название следующей сцены.");
        }
    }
    
 public void ShowNextLevelButton()
    {
        nextLevelButton.gameObject.SetActive(true); // Показываем кнопку
        statusInfo.text = "You Win!"; // Сообщение о победе
        panel.gameObject.SetActive(true); // Показываем панель с результатами
    }
 
    public void SetGameOver(bool isWin)
    {
        isGameOver = true;
        statusInfo.text = isWin ? "You Win!" : "You Lose!";
        panel.gameObject.SetActive(true); // Показываем панель с состоянием игры
    }
}
