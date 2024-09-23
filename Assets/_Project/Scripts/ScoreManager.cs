using UnityEngine;
using System.IO;

public class ScoreManager : MonoBehaviour
{
    public int currentScore;
    private string filePath;
    
    public TMPro.TextMeshProUGUI scoreText; // Reference to the TextMeshProUGUI for score display

    void Start()
    {
        filePath = Application.persistentDataPath + "/score.json";
        LoadScore();
        UpdateScoreUI();
    }

    // Call this to update the score and save
    public void AddScore(int points)
    {
        currentScore += points;
        SaveScore();
        UpdateScoreUI();
    }

    // Save score to a JSON file
    public void SaveScore()
    {
        string json = JsonUtility.ToJson(this);
        File.WriteAllText(filePath, json);
    }

    // Load score from a JSON file
    public void LoadScore()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            JsonUtility.FromJsonOverwrite(json, this);
        }
    }

    // Update the score display in UI
    private void UpdateScoreUI()
    {
        scoreText.text = "Score: " + currentScore;
    }

    void OnApplicationQuit()
    {
        SaveScore();
    }
}