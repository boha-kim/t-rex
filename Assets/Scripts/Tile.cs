using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField, Range(0, 1)] private float flowSpeed;

    public BackgroundController backgroundController;

    private void FixedUpdate()
    {
        this.transform.position += new Vector3(-flowSpeed, 0);
    }
}
