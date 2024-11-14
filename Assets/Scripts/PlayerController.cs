using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float _moveSpeed = 3f;
    [SerializeField] private float _jumpSpeed = 20f;
    private Rigidbody2D _rb;
    private Animator _anim;
    private string currentAnim;
    public LayerMask groundLayer;
    [SerializeField] private bool Grounded;
    private float horizontal;
    [SerializeField] private float groundDistance;
    private Vector3 startPos;
    
    
    void Start()
    {
        
        _anim = GetComponent<Animator>();
        startPos = transform.position;
        // _rb.mass = 1.0f; 
    }

    private void Update()
    {
        Vector2 movement = Vector2.zero;
        if (Input.GetKey(KeyCode.W)) // Phím đi lên
            movement.y = 1;
        if (Input.GetKey(KeyCode.S)) // Phím đi xuống
            movement.y = -1;
        if (Input.GetKey(KeyCode.A)) // Phím đi trái
            movement.x = -1;
        if (Input.GetKey(KeyCode.D)) // Phím đi phải
            movement.x = 1;
        
        _rb.velocity = movement * _moveSpeed;
    }

    private void FixedUpdate()
    {
        
        
    }


    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("enemy"))
        {
            transform.position = startPos;
        }
    }
}
