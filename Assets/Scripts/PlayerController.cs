using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float _moveSpeed = 300f;
    [SerializeField] private float _jumpSpeed = 20f;
    private Rigidbody2D _rb;
    private Animator _anim;
    private string currentAnim;
    public LayerMask groundLayer;
    [SerializeField] private bool Grounded;
    private float horizontal;
    [SerializeField] private float groundDistance;
    
    
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        // _rb.mass = 1.0f; 
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Grounded) // nếu ấn space và đang ở mặt đất sẽ nhảy 
        {
            _anim.SetTrigger("isJump");
            _rb.AddForce(_jumpSpeed * Vector2.up, ForceMode2D.Impulse);
            Debug.Log("Jump");
        }
    }

    private void FixedUpdate()
    {
        horizontal = Input.GetAxisRaw("Horizontal"); // -1 đi lùi, 0 đứng im, 1 tiến về phía trước => return -1/0/1
        Grounded = checkGrounded(); // true of false
        var speed = Mathf.Abs(horizontal);
        
        // Debug.Log(Grounded);
        
        if (speed > 0.1f)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, (horizontal > 0.1f)? 0:-180, 0));
            _rb.velocity = new Vector2(horizontal * _moveSpeed * Time.deltaTime, _rb.velocity.y);
        }
        else if (Grounded)  // ko di chuyen va dang o mat dat
        {
            // ChangeAnim("isIdle");
            _rb.velocity = new Vector2(0, _rb.velocity.y);
        }
    }


    private bool checkGrounded()
    {
        Debug.DrawLine(transform.position, transform.position - Vector3.up * groundDistance, Color.red);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, groundDistance, groundLayer);
        
        return hit.collider != null;
    }

    private void ChangeAnim (string animName) {
        if(currentAnim != animName) {
            _anim.ResetTrigger(animName);
            currentAnim = animName;

            _anim.SetTrigger(currentAnim);
        }
    }
}
