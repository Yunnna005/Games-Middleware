using UnityEngine;

public class EdController : MonoBehaviour
{
    public Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {

        animator.SetBool("isWalking", Input.GetKey(KeyCode.W));
      
    }
}
