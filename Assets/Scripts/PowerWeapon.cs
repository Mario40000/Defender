using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerWeapon : MonoBehaviour
{
    //Script para controlar el bonus de armas de la nave
    //destruye el power al cogerlo y controla que no nos pasemos de 
    //velocidad
    private Transform trans;
    private Rigidbody rb;
    private GameObject sound;

    public float speedRotation;
    public float speed;
    public float weaponBonus;
    public float maxWeapon;

    // Use this for initialization
    void Start()
    {
        sound = GameObject.Find("PowerUpSpeedSound");
        trans = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.right * -speed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        trans.Rotate(Vector3.up * Time.deltaTime * speedRotation);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (StaticData.shipFireRate <= maxWeapon)
            {
                StaticData.shipFireRate = maxWeapon;
            }
            else
            {
                StaticData.shipFireRate -= weaponBonus;
            }

            sound.GetComponent<AudioSource>().Play();
            Destroy(gameObject);
        }
    }

}
