using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerSpeed : MonoBehaviour
{
    //Script para controlar el bonus de velocidad de la nave
    //destruye el power al cogerlo y controla que no nos pasemos de 
    //velocidad
    private Transform trans;
    private Rigidbody rb;
    private GameObject sound;

    public float speedRotation;
    public float speed;
    public float speedBonus;
    public float maxSpeed; 

	// Use this for initialization
	void Start ()
    {
        sound = GameObject.Find("PowerUpSpeedSound");
        trans = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.right * -speed;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        trans.Rotate(Vector3.up * Time.deltaTime * speedRotation);
	}

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(StaticData.shipSpeed >= maxSpeed)
            {
                StaticData.shipSpeed = maxSpeed;
            }
            else
            {
                StaticData.shipSpeed += speedBonus;
            }
       
            sound.GetComponent<AudioSource>().Play();
            Destroy(gameObject);
        }
    }

    
}
