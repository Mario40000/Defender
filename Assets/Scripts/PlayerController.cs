using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, yMin, yMax;
}

public class PlayerController : MonoBehaviour
{
    //Clase para controlar al jugador y sus estados
    //Variables

    private Rigidbody rb;

    public float speed;
    public Boundary boundary;
    public float tilt;

	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody>();
	}
	

    private void FixedUpdate()
    {
        //Recogemos las pulsaciones del teclado o mando
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        //Movemos nuestra nave aplicando la velocidad deseada
        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f);
        rb.velocity = movement * speed;

        //Impedimos salir a nuestra nave de las dimensiones que le digamos
        rb.position = new Vector3(
            Mathf.Clamp (rb.position.x, boundary.xMin, boundary.xMax),
            Mathf.Clamp (rb.position.y, boundary.yMin, boundary.yMax),
            0.0f);

        //hacemos que nuestra nave alabee ligeramente
        rb.rotation = Quaternion.Euler(0.0f, 90f, rb.velocity.y * tilt);
    }
}
