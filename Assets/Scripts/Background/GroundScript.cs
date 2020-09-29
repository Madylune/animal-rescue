using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScript : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D target)
    {
        target.transform.GetComponent<PlayerMovement>().onLanding();
    }
}
