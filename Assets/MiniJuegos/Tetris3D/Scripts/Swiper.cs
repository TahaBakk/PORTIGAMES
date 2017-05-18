using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swiper : MonoBehaviour {

    private float fingerStartTime = 0.0f;
    private Vector2 fingerStartPos = Vector2.zero;

    private bool isSwipe = false;
    private float minSwipeDist = 30.0f;
    private float maxSwipeTime = 0.5f;
    private int timer = 0;

    private int timerPlatform;
    private int timeDivider;


    // Update is called once per frame
    void Update()
    {
        // Increment the timer
        if (Input.GetMouseButton(0))
        {
            timer += 1;
            // Additional code for chicken squat
            Debug.Log("timer " + timer);

        }
        else if (timer > 0)
        {
            timer = 0;
            // Additional code for chicken jump
            Debug.Log("timer " + timer);
        }

#if UNITY_ANDROID

        timerPlatform = 10;
        timeDivider = 2;
        if (timer > timerPlatform )
        {
            FindObjectOfType<Group>().moveDown();
        }
#endif

#if UNITY_STANDALONE

        timerPlatform = 30;
        timeDivider = 5;
        if (timer > timerPlatform && (timer % timeDivider == 0))
        {
            FindObjectOfType<Group>().moveDown();
        }
#endif



        if (Input.touchCount > 0)
        {

            foreach (Touch touch in Input.touches)
            {
                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        /* this is a new touch */
                        isSwipe = true;
                        fingerStartTime = Time.time;
                        fingerStartPos = touch.position;
                        break;

                    case TouchPhase.Canceled:
                        /* The touch is being canceled */
                        isSwipe = false;
                        break;

                    case TouchPhase.Ended:

                        float gestureTime = Time.time - fingerStartTime;
                        float gestureDist = (touch.position - fingerStartPos).magnitude;

                        if (isSwipe && gestureTime < maxSwipeTime && gestureDist > minSwipeDist)
                        {
                            Vector2 direction = touch.position - fingerStartPos;
                            Vector2 swipeType = Vector2.zero;

                            if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
                            {
                                // the swipe is horizontal:
                                swipeType = Vector2.right * Mathf.Sign(direction.x);
                            }
                            else
                            {
                                // the swipe is vertical:
                                swipeType = Vector2.up * Mathf.Sign(direction.y);
                            }

                            if (swipeType.x != 0.0f)
                            {
                                if (swipeType.x > 0.0f)
                                {
                                    // MOVE RIGHT
                                    Debug.Log("Right Swipe");
                                    FindObjectOfType<Group>().moveRight();
                                }
                                else
                                {
                                    // MOVE LEFT
                                    Debug.Log("Left Swipe");
                                    FindObjectOfType<Group>().moveLeft();
                                }
                            }

                            if (swipeType.y != 0.0f)
                            {
                                if (swipeType.y > 0.0f)
                                {
                                    // MOVE UP
                                    Debug.Log("Up Swipe");
                                    FindObjectOfType<Group>().rotate();
                                }
                                else
                                {
                                    // MOVE DOWN
                                    Debug.Log("Down Swipe");
                                    FindObjectOfType<Group>().moveDown();
                                }
                            }

                        }
                        if ( touch.tapCount > 1 && ( touch.tapCount % 2 == 0))
                        {
                            FindObjectOfType<Group>().rotate();
                        }


                        break;
                }
            }
        }

    }
}