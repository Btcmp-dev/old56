using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MoveController : MonoBehaviour
{
   

    private PlayerInputActions playerInputAction;
    private Rigidbody2D rb;
    private Vector2 direction;
    private bool canDashing = true;
    private bool isDashing = false;
    float dashindTime = 0.2f;
    float dashCoolDown = 3f;
    

    [SerializeField] private float movingSpeed = 10f;
    [SerializeField] private float dashSpeed = 4f;
    [SerializeField] private TrailRenderer trailRenderer;


    private void Awake() {
        rb = GetComponent<Rigidbody2D> ();
       playerInputAction = new PlayerInputActions ();
       playerInputAction.Enable ();
    }

    private void Start() {
        playerInputAction.Combat.Dash.performed += _ => Dash();
    }


    private void Update() {
    }
    private Vector2 GetMovementVector(){
        Vector2 inputVector = playerInputAction.Player.Move.ReadValue<Vector2>();

        return inputVector;
    }

    private void FixedUpdate() {

        Vector2 inputVector = GetMovementVector();

        inputVector = inputVector.normalized;

        rb.MovePosition(rb.position + inputVector *(movingSpeed * Time.fixedDeltaTime));
    }
    private void Dash() {
        if (!isDashing) {
            isDashing = true;
            movingSpeed *= dashSpeed;
            trailRenderer.emitting = true;
            StartCoroutine(EndDashRoutine());
        }
    }

    private IEnumerator EndDashRoutine() {
        yield return new WaitForSeconds (dashindTime);
        movingSpeed /= dashSpeed;
        trailRenderer.emitting = false;
        yield return new WaitForSeconds (dashCoolDown);
        isDashing = false;
    }
}
