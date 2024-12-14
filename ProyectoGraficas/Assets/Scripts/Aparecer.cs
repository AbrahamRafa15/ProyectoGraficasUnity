using UnityEditor.SceneManagement;
using UnityEngine;

public class Aparecer : MonoBehaviour
{
    public GameObject objeto;
    [SerializeField] float tiempoEspera = 2f;

    MeshRenderer myMeshRender;
    Rigidbody myRigidBody;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        if (objeto == null) {
            Debug.LogError("El objeto no ha sido asignado en el Inspector.");
            return;
        }

        myMeshRender = GetComponent<MeshRenderer>();
        myMeshRender.enabled = false;
        if(objeto.gameObject.tag == "Player"){
            myRigidBody = GetComponent<Rigidbody>();
            myRigidBody.useGravity = false;
        }

    }

    private void Update() {
        if (Time.time > tiempoEspera){
            //gameObject.SetActive(true);
            myMeshRender.enabled = true;
            if(objeto.gameObject.tag == "Player"){
                myRigidBody.useGravity = true;
            }
        }
    }

    
}
