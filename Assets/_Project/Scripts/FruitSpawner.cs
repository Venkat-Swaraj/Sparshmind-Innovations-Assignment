using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    public GameObject[] fruitPrefabs;
    public Transform spawnPoint;

    public GameObject currentFruit;

    public AudioClip Clip;
    public AudioSource AudioSource;

    public UITween UITween;
    public void SpawnFruit(int fruitIndex)
    {
        // Check if a fruit is already present in the scene
        if (currentFruit == null)
        {
            AudioSource.clip = Clip;
            AudioSource.Play();
            currentFruit = Instantiate(fruitPrefabs[fruitIndex], spawnPoint.position, Quaternion.identity);
        }
        else
        {
            UITween.Popup();
            Debug.Log("A fruit is already active. Please place it in the basket before spawning a new one.");
        }
    }
}