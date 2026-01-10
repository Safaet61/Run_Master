using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public TextMeshProUGUI levelCompleteText;
    public TextMeshProUGUI levelLossText;
    public Button restartButton;

    private bool isGameOver;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        isGameOver = false;

        levelCompleteText.gameObject.SetActive(false);
        levelLossText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
    }

    public void LevelFinished()
    {
        if (isGameOver) return;
        isGameOver = true;

        levelCompleteText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }

    public void LevelFail()
    {
        if (isGameOver) return;
        isGameOver = true;

        levelLossText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
