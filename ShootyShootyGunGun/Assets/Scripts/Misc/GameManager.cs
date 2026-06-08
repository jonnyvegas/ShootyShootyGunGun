using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] TMP_Text enemiesLeftText;
    [SerializeField] GameObject youWinText;
    const string ENEMIES_LEFT = "Enemies Left: ";
    int enemiesLeft = 0;

    public void RestartLevelButton()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
        youWinText.SetActive(false);
    }

    public void QuitButton()
    {
        Debug.LogWarning("This does not work in the Unity Editor! Will work in build tho. KEKW");
        Application.Quit();
    }

    public void AdjustEnemiesLeft(int amt)
    {
        enemiesLeft += amt;
        enemiesLeftText.text = ENEMIES_LEFT + enemiesLeft;
        if(enemiesLeft <= 0)
        {
            youWinText.SetActive(true);
        }
    }
}
