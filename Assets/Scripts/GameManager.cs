using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;


    public UnityEvent m_onGameStarted;
    public UnityEvent m_onPlayerDeath;



    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        instance = this;
        m_onPlayerDeath.AddListener(OnDeath);
    }
    private void OnDeath()
    {


    }



}
