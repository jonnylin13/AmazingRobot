using UnityEngine;

public class EntityMovement : MonoBehaviour
{
    public float speed = 7.0f;
    public float jumpSpeed = 6.0f;
    public float gravity = 20.0f;
    public AudioSource movementSound;
    public AudioSource movementSoundEnd;

    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;
    private bool moving;

    
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.isGrounded)
        {
            float vertical = Input.GetAxis("Vertical");

            moveDirection = new Vector3(0, 0, vertical);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;

            if (movementSound.isPlaying && movementSound.time > 6.0f) {
                movementSound.time = 4.6f;
            }

            if (controller.velocity.magnitude >= speed - 2 && !movementSound.isPlaying)
            {
                movementSound.Play();
                movementSound.time = 0;
                moving = true;
            }
            else if (controller.velocity.magnitude < speed - 2) {
                if (movementSound.isPlaying)
                {
                    movementSoundEnd.Play();
                    movementSound.Stop();
                    moving = false;
                }
            }

            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;

        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }
    public bool isMoving()
    {
        return this.moving;
    }
}