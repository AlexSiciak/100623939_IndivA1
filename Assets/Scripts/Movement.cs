using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
    public float movementSpeed = 1;

    void Update()
    {
        // Movement script
        // https://answers.unity.com/questions/505385/how-do-i-move-an-object-in-c.html

        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.Translate(Vector3.up * movementSpeed);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.Translate(Vector3.right * movementSpeed);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.Translate(Vector3.down * movementSpeed);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.Translate(Vector3.left * movementSpeed);
        }
    }
}