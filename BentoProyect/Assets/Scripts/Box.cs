using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public bool canDes = false;

    public void OnTriggerStay(Collider other)
    {
        if (canDes)
        {
            Destroy(other.gameObject);
            canDes = false;
        }

    }
}
