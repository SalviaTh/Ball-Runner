using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float forwardSpeed = 10f;
    public float sideSpeed = 5f;
    public float jumpForce = 5f;
    public Text scoreText;
    public GameObject GameOver;
    private int score = 0;

    public AudioSource coinSound; // Sound for collecting coins
    public AudioClip AudioClip;

    public AudioSource GameOverSound;
    public AudioClip GameOverAudioClip;

    public AudioSource backgroundMusic; // Background music source
    public AudioClip backgroundMusicClip; // Background music clip

    void Start()
    {
        GameOver.SetActive(false); // Hide GameOver UI at start

        // Start background music
        if (backgroundMusic != null && backgroundMusicClip != null)
        {
            backgroundMusic.clip = backgroundMusicClip;
            backgroundMusic.loop = true;
            backgroundMusic.Play();
        }
    }

    void FixedUpdate()
    {
        float moveX = 0f;

        if (Input.GetKey("a"))
            moveX = -sideSpeed;
        if (Input.GetKey("d"))
            moveX = sideSpeed;

        float currentForwardSpeed = forwardSpeed;
        if (Input.GetKey("w"))
            currentForwardSpeed += 2f;

        rb.velocity = new Vector3(moveX, rb.velocity.y, currentForwardSpeed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("COINS") || other.CompareTag("GoldBar"))
        {
            Destroy(other.gameObject);
            if (other.CompareTag("COINS"))
                score++;
            else
                score += 5;

            UpdateScoreUI();

            if (coinSound != null && AudioClip != null)
                coinSound.PlayOneShot(AudioClip);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over! You hit an obstacle.");

            // Stop music before pausing the game
            if (backgroundMusic != null && backgroundMusic.isPlaying)
                backgroundMusic.Stop();

            if (GameOverSound != null && GameOverAudioClip != null)
                GameOverSound.PlayOneShot(GameOverAudioClip);

            GameOver.SetActive(true); // Show GameOver UI
            Time.timeScale = 0; // Pause the game
        }
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = score.ToString();
            Debug.Log("Score updated: " + score);
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; // Resume time
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload current scene
    }
}
