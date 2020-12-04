using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Contoroller : MonoBehaviour
{
    [SerializeField]
    private CharacterController controller;
    [SerializeField]
    private Vector3 moveDirection = Vector3.zero;
    [SerializeField]
    private float horizon, vertical;
    [SerializeField]
    private float speed = 3.0f;
    [SerializeField]
    public float rotatespeed = 3.0f;
    [SerializeField]
    private float jumpspeed = 8.0f;
    [SerializeField]
    private float dashspeed = 3.0f;
    [SerializeField]
    private float gravity = 20.0f;
    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }
    void Update()
    {
        horizon = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(horizon, 0, vertical);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpspeed;
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (speed >= 6.0f)
            {
                speed *= 1.0f;
            }
            else
            {
                speed += dashspeed;
            }
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            if (speed <= 3.0f)
            {
                speed *= 1.0f;
            }
            else
            {
                speed -= dashspeed;
            }
        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
        transform.Rotate(0, Input.GetAxis("Horizontal") * rotatespeed, 0);
        Vector3 forward = transform.forward;
        float curspeed = speed * Input.GetAxis("Vertical");
        controller.SimpleMove(forward * curspeed);
    }
}
