using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;

    private float fixedSpeed;

    private Rigidbody2D myRigidbody;

    private Vector3 change;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        //Debug.Log(change);
        if (Input.GetButtonDown("attack"))
        {
            fixedSpeed = speed;
            speed = 0;
            StartCoroutine(attackCo());
            speed = fixedSpeed;
        }else 
            {
                UpdateAnimationAndMove();
            }
    }

    void UpdateAnimationAndMove()
    {
        if (change != Vector3.zero)
        {
            MoveCharacter();
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
            animator.SetBool("moving", true);
        }
        else
        {
            animator.SetBool("moving", false);
        }
    }
    private IEnumerator attackCo()
    {
        animator.SetBool("attacking" , true);
        yield return null;
        animator.SetBool("attacking" , false);
        yield return new WaitForSeconds(.3f);
    }

    void MoveCharacter()
    {
        myRigidbody.MovePosition(
                transform.position + change.normalized * speed /** Time.deltaTime*/
            );
    }
}
