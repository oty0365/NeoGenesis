using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb2D;
    public static PlayerController instance;
    public bool canMove;
    public bool canInteract;
    public Animator ani;
    public SpriteRenderer sr;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        canMove = true;
        canInteract = true;
    }
    private void Update()
    {
       
    }
    public void DemandMoves(int code)
    {
        switch (code)
        {
            case 0:
                canMove = true;
                canInteract = true;
                break;
            case 1:
                canMove = false;
                canInteract = true;
                break;
            case 2:
                canInteract = false;
                canMove = true;
                break;
            case 3:
                canMove = false;
                canInteract = false;
                break;
        }
    }
    public void Move(InputAction.CallbackContext vecterValue)
    {
        if (canMove)
        {
            var dir = vecterValue.ReadValue<Vector2>();
            if (vecterValue.started || vecterValue.performed)
            {
                dir = vecterValue.ReadValue<Vector2>();
                Debug.Log(dir + rb2D.linearVelocity.ToString());
            }
            else if (vecterValue.canceled)
            {
                Debug.Log("canceled");
            }

            rb2D.linearVelocity = dir.normalized * PlayerStatus.instance.moveSpeed;
            if (dir == Vector2.zero)
            {
                ani.SetInteger("Behave", 0);
            }
            else
            {
                ani.SetInteger("Behave", 1);
                sr.flipX = dir.x < 0;
            }

        }
    }
    
}
