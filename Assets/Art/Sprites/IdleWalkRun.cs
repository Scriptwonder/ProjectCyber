using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleWalkRun : MonoBehaviour
{
    private Animator mAnimator;
    private bool isFacingRight = false;
    // Start is called before the first frame update
    void Start()
    {
        mAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        

       

        if (mAnimator != null) {


            if(!Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow)) {
                mAnimator.SetTrigger("WalkIdle");
            } else {
                 // Get the horizontal input axis (left or right arrow keys)
                float horizontalInput = Input.GetAxis("Horizontal");

                // Set the "StartWalk" trigger when the left or right arrow key is pressed
                if (horizontalInput > 0f)
                {
                    mAnimator.SetTrigger("StartWalk");

                    // If the right arrow key is pressed and the GameObject is facing right, flip it
                    if (isFacingRight)
                    {
                        Flip();
                    }
                }
                else if (horizontalInput < 0f)
                {
                    mAnimator.SetTrigger("StartWalk");

                    // If the left arrow key is pressed and the GameObject is facing left, flip it
                    if (!isFacingRight)
                    {
                        Flip();
                    }
                }
            }


            if (Input.GetKeyDown(KeyCode.Space)) {
                mAnimator.SetTrigger("Jump");
            }

            if (Input.GetKeyDown(KeyCode.Z)) {
                mAnimator.SetTrigger("Contact");
            }

            if (Input.GetKeyDown(KeyCode.X)) {
                mAnimator.SetTrigger("Punch");
            }

            if (Input.GetKeyDown(KeyCode.C)) {
                mAnimator.SetTrigger("Dash");
            }
        }
    }

    // Flips the GameObject horizontally by changing its scale
    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    public void transitionMidJump() {
        mAnimator.SetTrigger("ToMidJump");
        print("hi");
    }


}
