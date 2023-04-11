using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;


    public UnityEvent m_onGameStarted;
    public UnityEvent m_onPlayerDeath;
    public UnityEvent m_onRetry;


    [SerializeField] FloatSO m_score;
    [SerializeField] FloatSO m_highScore;


    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        instance = this;
        m_onPlayerDeath.AddListener(OnDeath);
        m_onRetry.AddListener(ResetGame);
    }


    /// <summary>
    /// When player dies update highscore if its higher than current.
    /// </summary>
    private void OnDeath()
    {
        if (m_score._float > m_highScore._float)
        {
            m_highScore._float = m_score._float;
        }
    }


    void ResetGame()
    {
        SceneManager.LoadScene("SampleScene");
    }


}
