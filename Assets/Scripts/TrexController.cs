using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrexController : MonoBehaviour
{
    [SerializeField, Range(0, 1000)] private float jumpHeight;

    private Rigidbody2D trexRigid;

    private void Awake()
    {
        trexRigid = this.GetComponentInChildren<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TrexJump();
        }
    }

    private void TrexJump ()
    {
        trexRigid.AddForce(Vector3.up * jumpHeight);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Hurdle")
        {
            Debug.Log("Game Over!");
        }
    }
}
