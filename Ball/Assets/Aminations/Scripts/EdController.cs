using UnityEngine;
using UnityEngine.InputSystem;

public class EdController : MonoBehaviour
{
    Animator animator;
    CharacterController controller;

    private float speed = 2f;
    private float jumpHight = 2f;
    private float gravity = -9.81f;

    Vector2 moveInput;
    Vector3 velocity;


    private void Start()
    {
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        Debug.Log($"Move Input: {moveInput}");


    }

    public void OnJump(InputAction.CallbackContext context)
    {
        Debug.Log($"Jumpping: {context.performed} - Is Grounded: {controller.isGrounded}");
        if (context.performed && controller.isGrounded)
        {
            Debug.Log("Character is supposed to jump");
            velocity.y = Mathf.Sqrt(jumpHight * -2f * gravity);
        }
    }

    void Update()
    {
        //Movement logic
        Vector3 move = transform.right * moveInput.x + transform.forward * moveInput.y;
        controller.Move(move * speed * Time.deltaTime);

        //Jump logic
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        animator.SetBool("isWalking", moveInput != Vector2.zero);
        animator.SetFloat("VelocityX", moveInput.x );
        animator.SetFloat("VelocityZ", moveInput.y);
    }
}
