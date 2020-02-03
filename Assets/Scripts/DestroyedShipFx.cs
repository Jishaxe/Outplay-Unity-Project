using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyedShipFx : MonoBehaviour
{
    public GameObject[] pieces;

    public void DestroyFrom(Vector3 velocity)
    {
        foreach (GameObject piece in pieces)
        {
            // transfer velocity
            piece.GetComponent<Rigidbody2D>().AddForce(velocity);

            // add explosion effect from behind ship
            piece.GetComponent<Rigidbody2D>().AddForceAtPosition(velocity * 5, this.transform.position - velocity);
        }
    }
}
