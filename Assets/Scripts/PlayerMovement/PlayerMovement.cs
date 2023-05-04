using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;
    Vector3 nextCamPos, currentCamPos;
    float f;
    public Animator animator;
    public Transform meleeAttackPoint;
    public Transform currentRoom;

    public GameObject meleeAttack;
    public bool camFollowPlayer;

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");
        Vector3 dir = new Vector3(inputX, inputY).normalized;
        transform.position += dir * Time.deltaTime * movementSpeed;

        if (inputX > 0)
            transform.localScale = new Vector3(1, 1, 1);
        else if (inputX < 0)
            transform.localScale = new Vector3(-1, 1, 1);

        if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x < transform.position.x && inputX == 0)
            transform.localScale = new Vector3(-1, 1, 1);
        else if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x > transform.position.x && inputX == 0)
            transform.localScale = new Vector3(1, 1, 1);

        if (inputX != 0 || inputY != 0)
        {
            animator.SetBool("isWalking", true);
            animator.speed = movementSpeed / 3f;
        }
        else
        {
            animator.SetBool("isWalking", false);
            animator.speed = 1;
        }
        if (Input.GetMouseButtonDown(0) && meleeAttackPoint.childCount == 0)
        {
            Instantiate(meleeAttack, meleeAttackPoint.position, Quaternion.identity, meleeAttackPoint);
            meleeAttackPoint.localScale = transform.localScale;
        }
        meleeAttackPoint.position = transform.position + new Vector3(0, 0.65f, 0);

        if (f < 1 && !camFollowPlayer)
        {
            f = Mathf.Clamp01(f + Time.deltaTime * 4);
            Camera.main.transform.position = Vector3.Lerp(currentCamPos, nextCamPos, f);
        }
        if (camFollowPlayer)
        {
            float x = Mathf.Clamp(transform.position.x, -3.25f, 3.25f);
            float y = Mathf.Clamp(transform.position.y, -211, -189);
            Camera.main.transform.position = new Vector3(x, y + 0.25f, -10);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Floor")
        {
            f = 0;
            currentCamPos = Camera.main.transform.position;
            nextCamPos = collision.transform.position - new Vector3(0, 0, 10);
            currentRoom = collision.transform.parent;
        }
    }
}
