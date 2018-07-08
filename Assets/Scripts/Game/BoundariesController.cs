using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundariesController : MonoBehaviour
{
    //Clase para destruir todo lo que salga de los límites

    void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
    }

}
