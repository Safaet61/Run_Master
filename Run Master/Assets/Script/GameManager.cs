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
    public Button nextButton;

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
        nextButton.gameObject.SetActive(false);
    }

    public void LevelFinished()
    {
        if (isGameOver) return;
        isGameOver = true;

        levelCompleteText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        nextButton.gameObject.SetActive(true);
    }

    public void LevelFail()
    {
        if (isGameOver) return;
        isGameOver = true;
        levelLossText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        nextButton.gameObject.SetActive(false);
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void NextLevel()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        int nextIndex = currentIndex + 1;
        if (nextIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextIndex);
        }
        else
            SceneManager.LoadScene(0);


    }
}
