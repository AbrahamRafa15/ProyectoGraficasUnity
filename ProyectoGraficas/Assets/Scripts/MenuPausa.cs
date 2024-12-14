using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class MenuPausa : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject foco;
    public GameObject pauseButton;
    public TMP_InputField coordXField;
    public TMP_InputField coordYField;
    public TMP_InputField coordZField;
    public TMP_Text textoAnuncio;
    public static bool isGamePaused = true; // Global variable to track pause state

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PauseGame();
    }

    // Update is called once per frame
    void Update()
    {
        //  Resume with the Escape key
        if (Input.GetKeyDown(KeyCode.Escape) && isGamePaused)
        {
            ResumeGame();
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        pauseButton.SetActive(false);
        Time.timeScale = 0f;
        isGamePaused = true; // Update global pause state
        // Limpia el menú
        coordXField.text = "";
        coordYField.text = "";
        coordZField.text = "";
        textoAnuncio.text = ""; 
        textoAnuncio.gameObject.SetActive(false); 
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        pauseButton.SetActive(true);
        Time.timeScale = 1f;
        isGamePaused = false; // Update global pause state
    }

    public void DesplazaFoco(){ 
        // Leer y validar los valores de los InputFields
        if (float.TryParse(coordXField.text, out float coordX) &&
            float.TryParse(coordYField.text, out float coordY) &&
            float.TryParse(coordZField.text, out float coordZ))
        {
            foco.transform.position = new Vector3(coordX, coordY, coordZ);
            ShowMessage("El objeto ha sido desplazado exitosamente!", Color.green);
        }
        else
        {
            // Mostrar un mensaje de error en caso de que algún valor no sea válido
            ShowMessage("Uno o más valores ingresados no son válidos. Asegúrate de introducir números decimales.", Color.red);
        }
    }

    private void ShowMessage(string message, Color color)
    {
        textoAnuncio.color = color; // Actualiza el color del texto
        textoAnuncio.text = message; // Actualizar el mensaje
        textoAnuncio.gameObject.SetActive(true); // Asegurarse de que el Text esté visible
    }
}
