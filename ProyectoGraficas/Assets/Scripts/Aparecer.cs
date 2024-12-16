using UnityEngine;

public class Aparecer2 : MonoBehaviour
{
    [SerializeField] float tiempoEspera = 2f; // Tiempo antes de que el objeto aparezca

    Rigidbody myRigidBody;

    void Start()
    {
        // Obtener el componente Rigidbody si existe
        myRigidBody = GetComponent<Rigidbody>();

        if (myRigidBody != null)
        {
            // Desactivar gravedad inicialmente si el objeto es un "Player"
            if (CompareTag("Player"))
            {
                myRigidBody.useGravity = false;
            }
        }

        // Desactivar el objeto al iniciar
        gameObject.SetActive(false);

        // Llamar al método para activarlo después del tiempo especificado
        Invoke("EnableObject", tiempoEspera);
    }

    private void EnableObject()
    {
        // Activar el objeto
        gameObject.SetActive(true);

        // Activar gravedad si es un "Player"
        if (myRigidBody != null && CompareTag("Player"))
        {
            myRigidBody.useGravity = true;
        }
    }
}
