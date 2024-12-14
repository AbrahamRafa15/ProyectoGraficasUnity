using UnityEngine;
using TMPro;

public class Menu : MonoBehaviour
{
    
    public GameObject panelBienvenida; // Panel inicial
    public GameObject panelConfiguracion; // Panel de configuración
    public GameObject foco; // Foco que se moverá
    public TMP_InputField inputX, inputY, inputZ; // Textboxes para posición
    public TextMeshProUGUI textoError;


     public MonoBehaviour[] scriptsADesactivar; // Lista de scripts a desactivar

     public GameObject listner;



    public Transform Personas; 
    public Transform bardas;

    public Transform estrella;

    private bool MenuStatus =false;


   
    void Awake()
    {
        CambiarEstadoScripts(false);
        CambiarEstadoGravedad(Personas,false);
        CambiarEstadoGravedad(bardas,false);
        estrella.GetComponent<Rigidbody>().useGravity=false;

    }
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

            if(!panelConfiguracion.activeSelf){
                // Ocultar el texto de error
                textoError.gameObject.SetActive(false);

                // Limpiar los textboxes
                inputX.text = "";
                inputY.text = "";
                inputZ.text = "";

                listner.SetActive(false);
                CambiarEstadoScripts(true);
                CambiarEstadoGravedad(Personas,true);
                CambiarEstadoGravedad(bardas,true);
                estrella.GetComponent<Rigidbody>().useGravity=true;
            }
            else{
                listner.SetActive(true);
                CambiarEstadoScripts(false);
                CambiarEstadoGravedad(Personas,false);
                CambiarEstadoGravedad(bardas,false);
                estrella.GetComponent<Rigidbody>().useGravity=false;
            }
        }
    }

    public void AplicarCambios()
    {


        try{
            // Leer los valores de los textboxes
            float x = float.Parse(inputX.text);
            float y = float.Parse(inputY.text);
            float z = float.Parse(inputZ.text);

            // Cambiar la posición del foco
            foco.transform.position = new Vector3(x, y, z);

            textoError.gameObject.SetActive(false);
        }
        catch(System.Exception){
            textoError.gameObject.SetActive(true);
        }

        
    }

    // Cambia el estado de los scripts
    private void CambiarEstadoScripts(bool estado)
    {
        foreach (MonoBehaviour script in scriptsADesactivar)
        {
            script.gameObject.SetActive(estado);
            script.enabled = estado;
        }
    }


    private void CambiarEstadoGravedad(Transform grupo, bool estado)
    {
        foreach (Transform child in grupo)
        {
            Rigidbody rb = child.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.useGravity = estado;
            }
        }
    }
}
