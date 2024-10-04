using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;
    private Vector2 direction;

    bool canDashing = true;
    bool isDashing = false;
    float dashindTime = 0.2f;
    float dashCoolDown = 3f;
    //float dashingPower = 10f;

    [SerializeField] private TrailRenderer tr;

    private void Start()
    {
        if (isDashing)
        {
            return;
        }
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (isDashing)
        {
            return;
        }

        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.LeftShift) && canDashing)
        {
            StartCoroutine(Dash());
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
    }

    private IEnumerator Dash()
    {
        canDashing = false;
        isDashing = true;
        tr.emitting = true;
        speed *= 5; // юзануть деш повер
        yield return new WaitForSeconds(dashindTime);

        speed /= 5; // юзануть деш повер
        tr.emitting = false;
        isDashing = false;
        yield return new WaitForSeconds(dashCoolDown);

        canDashing = true;
    }
}
