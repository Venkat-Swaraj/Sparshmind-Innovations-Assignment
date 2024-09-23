using UnityEngine;

public class BasketScore : MonoBehaviour
{
    private ScoreManager scoreManager; // Reference to ScoreManager
    private FruitSpawner fruitSpawner;

    public AudioSource AudioSource;
    public AudioClip Clip;
    
    void Start()
    {
        // Find the ScoreManager and FruitSpawner in the scene
        scoreManager = FindObjectOfType<ScoreManager>();
        fruitSpawner = FindObjectOfType<FruitSpawner>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fruit"))
        {
            AudioSource.clip = Clip;
            AudioSource.Play();
            other.gameObject.GetComponent<Rigidbody>().useGravity = false;
            other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            if (other.gameObject.GetComponent<SphereCollider>())
            {
                other.gameObject.GetComponent<SphereCollider>().enabled = false;
            }
            else
            {
                other.gameObject.GetComponent<MeshCollider>().enabled = false;
            }
            // Notify ScoreManager to add points (1 point for each fruit)
            scoreManager.AddScore(1);

            // Destroy the fruit and allow new fruit spawning
            // Destroy(other.gameObject);
            fruitSpawner.currentFruit = null; // Set currentFruit to null after destruction
        }
    }
}