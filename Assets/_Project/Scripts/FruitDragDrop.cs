using UnityEngine;

public class FruitDragDrop : MonoBehaviour
{
    private Camera mainCamera;
    private bool isDragging = false;
    private GameObject selectedFruit;
    private Vector3 offset;
    private float zDepth;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        // Check for mouse or touch input
        if (Input.GetMouseButtonDown(0))
        {
            RaycastForFruit();
        }

        // If dragging, update the position of the selected fruit
        if (isDragging && selectedFruit != null)
        {
            DragFruit();
        }

        // Stop dragging when the mouse button is released
        if (Input.GetMouseButtonUp(0) && isDragging)
        {
            isDragging = false;
            selectedFruit = null; // Drop the fruit
        }
    }

    // Cast a ray to detect fruits when the player clicks
    void RaycastForFruit()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            // Check if the clicked object has the tag "Fruit"
            if (hit.collider.CompareTag("Fruit"))
            {
                selectedFruit = hit.collider.gameObject;
                isDragging = true;

                // Store the z-depth (distance from camera to object) for accurate dragging
                zDepth = mainCamera.WorldToScreenPoint(selectedFruit.transform.position).z;

                // Calculate the offset between the fruit's world position and the mouse's world position
                offset = selectedFruit.transform.position - mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, zDepth));
            }
        }
    }

    // Drag the fruit according to mouse/touch movement
    void DragFruit()
    {
        // Update mouse position while keeping the z-depth consistent
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, zDepth);

        // Convert mouse position to world space and apply the offset
        Vector3 newPosition = mainCamera.ScreenToWorldPoint(mousePosition) + offset;

        // Update the fruit's position
        selectedFruit.transform.position = newPosition;
    }
}
