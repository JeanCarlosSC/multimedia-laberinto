using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jugador : MonoBehaviour {

    public float velocidad = 5;
    public Text tPuntaje;
    public Text tVidas;

    Rigidbody miRigidBody;
    Vector3 posicionInicial;
    int monedas = 0;
    int vidas = 3;

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

        miRigidBody.AddForce(new Vector3(horizontal, 0, vertical) * velocidad * Time.deltaTime);
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
            miRigidBody.angularVelocity = Vector3.zero;
            vidas--;
            tVidas.text = "Vidas: " + vidas;
        }
        else if(collision.CompareTag("Moneda")) {
            collision.gameObject.SetActive(false);
            monedas++;
            tPuntaje.text = "Monedas: " + monedas;
        }
    }
}
