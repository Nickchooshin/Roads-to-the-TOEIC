using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator animator = null;

    private const float gravity = -9.8f;
    private Vector3 gravityVector = Vector3.zero;
    private bool m_isJump = false;

    void Start()
    {
        
    }
    
    void Update()
    {
        Vector3 direction = Vector3.zero;

        if (Input.GetKey(KeyCode.RightArrow))
            direction.x += 5.0f;
        if (Input.GetKey(KeyCode.LeftArrow))
            direction.x -= 5.0f;

        if (Input.GetKey(KeyCode.DownArrow))
            animator.SetBool("Spin", true);
        else
            animator.SetBool("Spin", false);

        if (!m_isJump && Input.GetKeyDown(KeyCode.Space))
        {
            m_isJump = true;
            gravityVector.y = 5.0f;
        }

        transform.position += direction * Time.deltaTime;

        if (transform.position.x < -5.35f)
            transform.position = new Vector3(-5.35f, transform.position.y);
        else if (transform.position.x > 5.35f)
            transform.position = new Vector3(5.35f, transform.position.y);

        if (m_isJump)
            Gravity();
    }

    private void Gravity()
    {
        gravityVector.y += gravity * Time.deltaTime;
        transform.position += gravityVector * Time.deltaTime;

        if (transform.position.y <= -1.31f)
        {
            transform.position = new Vector3(transform.position.x, -1.31f);
            m_isJump = false;
        }
    }
}
