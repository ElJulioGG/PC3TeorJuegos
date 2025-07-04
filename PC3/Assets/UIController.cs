using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public TextMeshProUGUI healthText1;
    public TextMeshProUGUI healthText2;
    public TextMeshProUGUI timeText1;
    public TextMeshProUGUI timeText2;

    public TextMeshProUGUI gameOverText;   
    public Button tryAgainButton;         

    private bool gameEnded = false;

    private void Start()
    {
        gameOverText.gameObject.SetActive(false);
        tryAgainButton.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (GameManager.instance == null || gameEnded) return;

       
        GameManager.instance.playerTime += Time.deltaTime;

        
        string healthStr = $"HP: {GameManager.instance.playerHealth}";
        healthText1.text = healthStr;
        healthText2.text = healthStr;

    
        int totalSeconds = Mathf.FloorToInt(GameManager.instance.playerTime);
        int minutes = totalSeconds / 60;
        int seconds = totalSeconds % 60;

        string timeStr = $"Time: {minutes}m {seconds}s";
        timeText1.text = timeStr;
        timeText2.text = timeStr;

        if (GameManager.instance.playerHealth <= 0)
        {
            gameEnded = true;

         
            gameOverText.gameObject.SetActive(true);

           
            tryAgainButton.gameObject.SetActive(true);

            Time.timeScale = 0f;
        }
    }

    public void TryAgain()
    {
       GameManager.instance.playerHealth = 1;
        GameManager.instance.playerTime = 0f;
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex
        );
    }
}
