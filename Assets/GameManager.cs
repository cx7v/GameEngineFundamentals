using UnityEngine;
using TMPro; // Required for TextMeshPro

public class GameManager : MonoBehaviour
{
    // This allows other scripts to find the GameManager easily
    public static GameManager Instance { get; private set; }

    [SerializeField] private TextMeshProUGUI killCountText;
    private int killCount = 0;

    private void Awake()
    {
        // Set up the Singleton instance
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        UpdateKillUI();
    }

    // Call this function from any script to add a kill
    public void AddKill()
    {
        killCount++;
        UpdateKillUI();
    }

    private void UpdateKillUI()
    {
        if (killCountText != null)
        {
            killCountText.text = "Kills: " + killCount;
        }
    }
}
