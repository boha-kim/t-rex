using UnityEngine;

public class Hurdle : MonoBehaviour
{
    [SerializeField, Range(0, 1)] private float flowSpeed;

    public HurdleController hurdleController;

    private void FixedUpdate()
    {
        this.transform.position += new Vector3(-flowSpeed, 0);
    }
}
