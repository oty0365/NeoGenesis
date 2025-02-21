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
    private Vector2 _dir;
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
                _dir = Vector2.zero;
                canMove = false;
                canInteract = true;
                break;
            case 2:
                canInteract = false;
                canMove = true;
                break;
            case 3:
                _dir = Vector2.zero;
                canMove = false;
                canInteract = false;
                break;
        }
    }
    public void Move(InputAction.CallbackContext vecterValue)
    {
        if (canMove)
        {

            if (vecterValue.performed)
            {
                _dir = vecterValue.ReadValue<Vector2>();
                ani.SetInteger("Behave", 1);
                if (_dir.x > 0)
                {
                    sr.flipX = false;
                }
                else if(_dir.x<0)
                {
                    sr.flipX = true;
                }
            }
            else
            {
                _dir = Vector2.zero;
                ani.SetInteger("Behave", 0);
            }

        }
    }
    private void FixedUpdate()
    {
        rb2D.linearVelocity = _dir.normalized * PlayerStatus.instance.moveSpeed;
    }

}
