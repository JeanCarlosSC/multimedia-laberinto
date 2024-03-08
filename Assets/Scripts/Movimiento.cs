using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour {

    public float velocidad = 5;
    Rigidbody miRigidBody;
    Vector3 posicionInicial;
    int monedas = 0;

    // Start is called before the first frame update
    void Start()
    {
        miRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        miRigidBody.AddForce(new Vector3(horizontal, 0, vertical) * velocidad);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.CompareTag("Salida"))
        {
            Debug.Log("Muy bien, has finalizado el recorrido");
        }
        else if (collision.CompareTag("Enemigo"))
        {
            miRigidBody.MovePosition(posicionInicial);
            miRigidBody.velocity = Vector3.zero;
        }
        else if(collision.CompareTag("Moneda")) {
            collision.gameObject.SetActive(false);
            monedas = monedas + 1;
        }
    }
}
