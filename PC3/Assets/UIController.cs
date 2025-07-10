using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class UIController : MonoBehaviour
{
    public Follow follow;
    public AudioSource deathMusic;
    public AudioSource gameMusic;
    public AudioSource deathSfxAudio;
    public Sprite brokenHeartSprite; 

    public GameObject canvasBlackScreen;
    public GameObject heartImg;             
    public GameObject deathParticlesPrefab; 
    public Transform particleSpawnPoint;    

    public TextMeshProUGUI healthText1;
    public TextMeshProUGUI healthText2;
    public TextMeshProUGUI timeText1;
    public TextMeshProUGUI timeText2;
    public TextMeshProUGUI gameOverText;
    public Button tryAgainButton;

    private bool gameEnded = false;

    private void Start()
    {
        GameManager.instance.playerHealth = 1;
        GameManager.instance.playerTime = 0f;
        follow.StartFollowing();
        gameMusic.Play();
        deathMusic.Stop();
        gameOverText.gameObject.SetActive(false);
        tryAgainButton.gameObject.SetActive(false);
        canvasBlackScreen.SetActive(false);
        heartImg.SetActive(false);
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
            StartCoroutine(HandleDeathSequence());
        }
    }

    private IEnumerator HandleDeathSequence()
    {
        follow.StopFollowing();
        gameMusic.Stop();

        canvasBlackScreen.SetActive(true);
        heartImg.SetActive(true);

        deathSfxAudio.Play();
        yield return new WaitForSeconds(0.5f);

        SpriteRenderer heartSprite = heartImg.GetComponent<SpriteRenderer>();
        if (heartSprite != null && brokenHeartSprite != null)
        {
            heartSprite.sprite = brokenHeartSprite;
        }
        yield return new WaitForSeconds(1.5f);

        heartImg.SetActive(false);

        if (deathParticlesPrefab != null && particleSpawnPoint != null)
            Instantiate(deathParticlesPrefab, particleSpawnPoint.position, Quaternion.identity);

       yield return new WaitForSeconds(2f);


        canvasBlackScreen.transform.SetSiblingIndex(1);

        gameOverText.gameObject.SetActive(true);
        tryAgainButton.gameObject.SetActive(true);

        deathMusic.Play();
        //Time.timeScale = 0f;


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
