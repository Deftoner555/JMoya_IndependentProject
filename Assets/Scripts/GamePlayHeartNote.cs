using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayHeartNote : MonoBehaviour
{
    public GameObject NoteGO;
    public ParticleSystem RipplePS;
    private Animator Hitanim;
    private GameManager gameManager;

    private bool isHeart = false;
    private bool isUp = false;
    private bool isDown = false;
    private bool isLeft = false;
    private bool isRight = false;
    private bool isPowerUp = false;

    private bool isColliding = false;

    private float Speed = 10f;

    private static int currentScore;
    private static int addPoints = 50;
    private Coroutine doublePointsCoroutine;

    private void Start()
    {
        Hitanim = GetComponent<Animator>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    void Update()
    {
        transform.Translate(-Speed * Time.deltaTime, 0, 0);

        //Sets up conditions for each note and how to activate each one individually
        if (Input.GetButtonDown("Space") && isColliding && isHeart)
        {
            gameManager.UpdateScore(currentScore += addPoints);
            Debug.Log(currentScore);
            RipplePS.Play();
        }

        else if (Input.GetButtonDown("W") && isColliding && isUp)
        {
            currentScore += addPoints;
            Debug.Log(currentScore);
            RipplePS.Play();
        }

        else if (Input.GetButtonDown("S") && isColliding && isDown)
        {
            currentScore += addPoints;
            Debug.Log(currentScore);
            RipplePS.Play();
        }

        else if (Input.GetButtonDown("A") && isColliding && isLeft)
        {
            currentScore += addPoints;
            Debug.Log(currentScore);
            RipplePS.Play();
        }

        else if (Input.GetButtonDown("D") && isColliding && isRight)
        {
            currentScore += addPoints;
            Debug.Log(currentScore);
            RipplePS.Play();
        }

        else if (isColliding && isPowerUp)
        {
            Debug.Log("Picked up PowerUp");
            Destroy(GetComponent<MeshRenderer>());

            if (doublePointsCoroutine != null)
                StopCoroutine(doublePointsCoroutine);

            doublePointsCoroutine = StartCoroutine(DoublePoints());
            StartCoroutine(StopDoublePointsCoroutine(5f));
        }
    }

    //When collider enters Trigger, it checks the tag and sets isColliding
    //to true if it collides with Player GO
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isColliding = true;

            //setting up bool's for each tag to make sure each player input is
            //specific to each GO
            if (gameObject.CompareTag("Heart"))
            {
                isHeart = true;
                Hitanim.SetTrigger("Hit_trig");
            }

            else if (gameObject.CompareTag("Up"))
            {
                isUp = true;
            }

            else if (gameObject.CompareTag("Down"))
            {
                isDown = true;
                Hitanim.SetTrigger("Hit_trig");
            }

            else if (gameObject.CompareTag("Left"))
            {
                isLeft = true;
                Hitanim.SetTrigger("Hit_trig");
            }

            else if (gameObject.CompareTag("Right"))
            {
                isRight = true;
            }

            else if (gameObject.CompareTag("PowerUp"))
            {
                isPowerUp = true;
            }
        }
    }

    //sets isColliding to false when trigger exits collider
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isColliding = false;
            isHeart = false;
            isUp = false;
            isDown = false;
            isLeft = false;
            isRight = false;
            isPowerUp = false;
        }
    }

    IEnumerator DoublePoints()
    {
        while (true)
        {
            addPoints = 100;

            // Yield execution of this coroutine and return to the main loop
            // until next frame
            yield return null;
        }
    }

    IEnumerator StopDoublePointsCoroutine(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (doublePointsCoroutine != null)
            StopCoroutine(doublePointsCoroutine);
    }
}
