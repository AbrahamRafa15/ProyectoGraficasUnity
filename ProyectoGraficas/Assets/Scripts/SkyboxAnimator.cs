using UnityEngine;

public class SkyboxAnimator : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 1.0f; // Speed of rotation

    void Update()
    {
        // Rotate the skybox over time
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * rotationSpeed);
    }
}
