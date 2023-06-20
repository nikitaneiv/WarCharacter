using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;
    [SerializeField] private FixedJoystick _stick;
    [SerializeField] private float speed;

    private Animator animator;

    public bool isRun = true;
    public bool isShoot = true;
    private bool isButtonShootPressed;

    private const string IDLE = "Idle";
    private const string RUN = "Run";
    private const string SHOOT = "Shoot";
    private const string JUMP = "Jump";
    private const string RUNSHOOT = "PistolRun";

    public bool IsButtonShootPressed => isButtonShootPressed;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        var direction = new Vector3(_stick.Direction.x, 0, _stick.Direction.y) * speed;
        if (direction != Vector3.zero)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(direction),
                speed * Time.deltaTime);
            characterController.SimpleMove(direction);
            if (isRun)
            {
                animator.SetTrigger(RUN);
            }
        }
        else if (isButtonShootPressed && direction != Vector3.zero && isShoot)
        {
            animator.SetTrigger(RUNSHOOT);
        }
        else
        {
            if (isButtonShootPressed && isShoot)
            {
                animator.SetTrigger(SHOOT);
            }
            else
            {
                animator.SetTrigger(IDLE);
            }
        }
    }

    public void Jump()
    {
        animator.SetTrigger(JUMP);
    }

    public void ButtonShootPressed()
    {
        isButtonShootPressed = true;
    }

    public void ButtonShootRelased()
    {
        isButtonShootPressed = false;
    }
}