using UnityEngine;
using TMPro;

public class Menu : MonoBehaviour
{
    public GameObject panelBienvenida; // Panel inicial
    public GameObject panelConfiguracion; // Panel de configuración
    public GameObject foco; // Foco que se moverá
    public TMP_InputField inputX, inputY, inputZ; // Textboxes para posición

    private bool MenuStatus =false;

    void Update()
    {
        // Cambia al panel de configuración al presionar Enter
        if (Input.GetKeyDown(KeyCode.Return))
        {
            panelBienvenida.SetActive(false);
            panelConfiguracion.SetActive(true);

            MenuStatus=true;
        }

        //Activar y desactivar el Menu
        if (Input.GetKeyDown(KeyCode.M)&&MenuStatus)
        {
            panelConfiguracion.SetActive(!panelConfiguracion.activeSelf);
        }
    }

    public void AplicarCambios()
    {
        // Leer los valores de los textboxes
        float x = float.Parse(inputX.text);
        float y = float.Parse(inputY.text);
        float z = float.Parse(inputZ.text);

        // Cambiar la posición del foco
        foco.transform.position = new Vector3(x, y, z);
    }
}
