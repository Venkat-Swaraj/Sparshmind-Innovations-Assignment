using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public FruitSpawner fruitSpawner;
    public Button[] fruitButtons;

    void Start()
    {
        for (int i = 0; i < fruitButtons.Length; i++)
        {
            int index = i; // Local variable to avoid closure issue
            fruitButtons[i].onClick.AddListener(() => fruitSpawner.SpawnFruit(index));
        }
    }
}