using UnityEngine;

public class DragAnyObjectPerspective : MonoBehaviour
{
    private Camera mainCamera;           // Reference to the main camera
    private Transform draggedObject;     // The currently dragged object
    private Vector3 offset;              // Offset between object and mouse
    private float depth;                 // Depth of the object relative to the camera

    private void Start()
    {
        mainCamera = Camera.main;       // Cache the main camera
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left mouse button down
        {
            TryPickObject();
        }

        if (Input.GetMouseButton(0) && draggedObject != null) // While dragging
        {
            DragObject();
        }

        if (Input.GetMouseButtonUp(0) && draggedObject != null) // Mouse button released
        {
            ReleaseObject();
        }
    }

    private void TryPickObject()
    {
        // Create a ray from the camera to the mouse position
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            // Check if the object or its parents are tagged as "Unmovable"
            if (IsParentTaggedUnmovable(hit.transform))
            {
                return; // Skip this object
            }

            // Set the dragged object
            draggedObject = hit.transform;

            // Calculate the depth of the object relative to the camera
            depth = Vector3.Distance(mainCamera.transform.position, hit.point);

            // Calculate the offset between the object and the mouse
            offset = draggedObject.position - GetMouseWorldPositionAtDepth();
        }
    }

    private void DragObject()
    {
        // Calculate the new position in world space based on the mouse
        Vector3 targetPosition = GetMouseWorldPositionAtDepth() + offset;

        // Update the position of the dragged object
        draggedObject.position = targetPosition;
    }

    private void ReleaseObject()
    {
        // Clear the reference to the dragged object
        draggedObject = null;
    }

    private Vector3 GetMouseWorldPositionAtDepth()
    {
        // Get the mouse position in screen space
        Vector3 mouseScreenPosition = Input.mousePosition;

        // Add the depth to the z-coordinate
        mouseScreenPosition.z = depth;

        // Convert the screen position to world position
        return mainCamera.ScreenToWorldPoint(mouseScreenPosition);
    }

    private bool IsParentTaggedUnmovable(Transform obj)
    {
        // Traverse up the hierarchy to check for the "Unmovable" tag
        while (obj != null)
        {
            if (obj.CompareTag("Unmovable"))
            {
                return true; // Found an unmovable parent
            }
            obj = obj.parent; // Move up to the parent
        }
        return false; // No unmovable parent found
    }
}
