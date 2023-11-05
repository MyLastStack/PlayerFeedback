using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] InputAction interactAction, pauseAction;
    public bool interactable;
    public bool interacting;
    public bool pausing;

    [Header("Movement")]
    public float moveSpeed;

    public float groundDrag;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    void Start()
    {
        interactable = false;
        interacting = false;
        pausing = false;

        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    void Update()
    {
        if (!interacting || !pausing)
        {
            grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

            KeyboardInputs();
            SpeedControl();

            if (grounded)
            {
                rb.drag = groundDrag;
            }
            else
            {
                rb.drag = 0;
            }
        }

        if (pauseAction.WasPressedThisFrame())
        {
            if (pausing)
            {
                UnpausingScene();
            }
            else
            {
                PausingScene();
            }
        }
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void KeyboardInputs()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if (interactable && interactAction.WasReleasedThisFrame())
        {
            onInteract();
        }
    }

    public void PausingScene()
    {
        pausing = true;
    }

    public void UnpausingScene()
    {
        pausing = false;
    }

    #region Player Movement
    private void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        rb.AddForce(moveDirection.normalized * moveSpeed * 10.0f, ForceMode.Force);
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }
    #endregion

    #region Player Interaction
    public void onInteract()
    {
        interacting = true;
    }
    
    public void offInteract()
    {
        interacting = false;
    }
    #endregion

    #region Enable and Disable
    private void OnEnable()
    {
        interactAction.Enable();
        pauseAction.Enable();
    }

    private void OnDisable()
    {
        interactAction.Disable();
        pauseAction.Disable();
    }
    #endregion
}
