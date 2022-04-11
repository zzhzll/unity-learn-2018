using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D _rigid2D;
    Animator animator;
    float jumpForce = 780.0f;
    float walkForce = 30.0f;
    float maxWalkSpeed = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        _rigid2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow)) {
            _rigid2D.AddForce(transform.up * jumpForce);
        }
        
        int key = 0;
        if(Input.GetKey(KeyCode.RightArrow)) {
            key = 1;
        }
        if(Input.GetKey(KeyCode.LeftArrow)) {
            key = -1;
        }

        float speedX = Mathf.Abs(_rigid2D.velocity.x);

        if(speedX < maxWalkSpeed) {
            _rigid2D.AddForce(transform.right * key * walkForce);
        }
        
        if(key != 0) {
            transform.localScale = new Vector3(key, 1, 1);
        }

        animator.speed = speedX / 2.0f;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("到达目的地");
    }
}
