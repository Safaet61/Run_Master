using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Button playButton;
    public GameObject PlayPanel;
    public TextMeshProUGUI levelCompleteText;
    public TextMeshProUGUI levelLossText;
    public Button restartButton;
    public Button nextButton;
    public Button ExitButton;

    public bool isGameStarted { get; private set; }
    private bool isGameOver;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            isGameStarted = false;
        }
        else
            Destroy(gameObject);


        isGameOver = false;
    }

    private void Start()
    {
        if (!isGameStarted)
            PlayPanel.gameObject.SetActive(true);
        else
            PlayPanel.gameObject.SetActive(false);


        levelCompleteText.gameObject.SetActive(false);
        levelLossText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
        nextButton.gameObject.SetActive(false);
        ExitButton.gameObject.SetActive(false);
    }

    public void LevelFinished()
    {
        if (isGameOver) return;
        isGameOver = true;
        PlayPanel.gameObject.SetActive(false);
        levelCompleteText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        nextButton.gameObject.SetActive(true);
        ExitButton.gameObject.SetActive(true);
    }

    public void LevelFail()
    {
        if (isGameOver) return;
        isGameOver = true;
        PlayPanel.gameObject.SetActive(false);
        levelLossText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        nextButton.gameObject.SetActive(false);
        ExitButton.gameObject.SetActive(true); ;
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
    public  void StartGame()
    {

        isGameStarted = true;
        PlayPanel.gameObject.SetActive(false);

    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
