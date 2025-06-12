using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour, ICanMove
{
    [Header("Movement")]
    [SerializeField] private float baseSpeed = 3f;
    [SerializeField] private float sprintSpeed = 5f;
    private float currentSpeed;

    private float moveX, moveY;

    public float MoveY => moveY;
    public float MoveX => moveX;
    public bool IsSprinting;
    private bool canMove = false, canMove2 = false;

    private void Start()
    {
        canMove = true;
        canMove2 = true;
        DialogueManager.Instance.AddObserverForMove(this);
    }

    private void Update()
    {
        if (canMove && canMove2)
        {
            moveY = Input.GetAxisRaw("Vertical");
            moveX = Input.GetAxisRaw("Horizontal");

            Flip(moveX);


            if (Input.GetKey(KeyCode.LeftShift))
            {
                currentSpeed = sprintSpeed;
                IsSprinting = true;
            }
            else
            {
                currentSpeed = baseSpeed;
                IsSprinting = false;
            }

        }
        else
        {
            moveY = 0;
            moveX = 0;
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector2 movement = new Vector2 (moveX, moveY).normalized;
        transform.Translate(movement * currentSpeed * Time.deltaTime);
    }

    private void Flip(float move)
    {
        if(move < 0f)
            gameObject.transform.localScale = new Vector3(-1f, 1f, 1f);
        else if(move > 0f)
            gameObject.transform.localScale = new Vector3(1f, 1f, 1f);

    }

    public void CanMove(bool state)
    {
        canMove = state;
    }
    public void CanMove2(bool state)
    {
        canMove2 = state;
    }
}
