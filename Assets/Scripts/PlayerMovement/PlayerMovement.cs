using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;
    Vector3 nextCamPos, currentCamPos;
    float f;
    RoomInstance current;

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");
        if (inputX != 0 && inputY == 0)
            transform.position += new Vector3(inputX, 0) * Time.deltaTime * movementSpeed;
        else if (inputX == 0 && inputY != 0)
            transform.position += new Vector3(0, inputY) * Time.deltaTime * movementSpeed;
        else if (inputX != 0 && inputY != 0)
            transform.position += new Vector3(inputX / 1.4f, inputY / 1.4f) * Time.deltaTime * movementSpeed;

        if (f < 1)
        {
            f = Mathf.Clamp01(f + Time.deltaTime * 4);
            Camera.main.transform.position = Vector3.Lerp(currentCamPos, nextCamPos, f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Floor")
        {
            f = 0;
            currentCamPos = Camera.main.transform.position;
            nextCamPos = collision.transform.position - new Vector3(0, 0, 10);
        }
    }
}
