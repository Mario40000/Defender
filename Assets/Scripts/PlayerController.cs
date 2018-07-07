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
    private float nextFire;

    public float speed;
    public Boundary boundary;
    public float tilt;

    public GameObject basicBolt;
    public Transform mainCannon1;
    public Transform mainCannon2;
    public float fireRate;

	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody>();
	}

    private void Update()
    {
        //Disparamos los cañones si ha pasado el tiempo minimo
        if (Input.GetButton("Jump") & Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(basicBolt, mainCannon1.position, mainCannon1.rotation);
            Instantiate(basicBolt, mainCannon2.position, mainCannon2.rotation);
        }
        
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
