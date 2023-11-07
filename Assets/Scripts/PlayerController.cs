using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public float playerMoveSpeed;
    public float arrowMinX, arrowMaxX;
    public float throwForce;

    [SerializeField] private Transform throwingArrow;
    [SerializeField] private Transform ballSpawnPoint;
    [SerializeField] private Rigidbody bowlingBall;
    [SerializeField] private Rigidbody[] balls;
    [SerializeField] private Animator arrowAnimator;

    Vector3 ballOffset;
    bool wasBallthrown;


    // Start is called before the first frame update
    void Start()
    {
        //StartThrow();
    }

    // Update is called once per frame
    void Update()
    {
        TryMoveArrow();
        TryShootBall();
        
    }
    public void StartThrow()
    {
        arrowAnimator.SetBool("Aiming", true);
        wasBallthrown = false;
        ballOffset = ballSpawnPoint.position - throwingArrow.position;
        int balltoSpawnIndex = Random.Range(0, balls.Length);
        bowlingBall = Instantiate(balls[balltoSpawnIndex], ballSpawnPoint.position, Quaternion.identity);
        Debug.Log($"balls to spawn index = {balltoSpawnIndex}");
    }
       


    void TryMoveArrow()
    {
        if (!wasBallthrown)
        {
            //Move arrow without Bounds
            //throwingArrow.position += throwingArrow.right * Input.GetAxis("Horizontal") * playerMoveSpeed * Time.deltaTime;

            //Move Throwing arrow with bounds
            float movePosition = Input.GetAxis("Horizontal") * playerMoveSpeed * Time.deltaTime;
            throwingArrow.position = new Vector3(Mathf.Clamp(throwingArrow.position.x + movePosition, arrowMinX, arrowMaxX), throwingArrow.position.y, throwingArrow.position.z);
            //Debug.Log(throwingArrow.position);

            //Move the ball with the arrow
            bowlingBall.transform.position = throwingArrow.position + ballOffset;

            //resets the throwing arrow position into ballspawn point;
            ballSpawnPoint.position = throwingArrow.position + ballOffset;
        }
    }
    void TryShootBall()
    {
        //Debug.Log(bowlingBall.velocity);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            wasBallthrown = true;
            bowlingBall.velocity = Vector3.zero;
            bowlingBall.AddForce(throwingArrow.forward * throwForce, ForceMode.Impulse);
            arrowAnimator.SetBool("Aiming", false);

        }
    }

}
