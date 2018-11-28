using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    public GameObject ball;
    public GameObject bounds;
    public GameObject plunger;
    public GameObject ballPrefab;//used to generate new balls
    Transform ballTransform;//position of ball at plunger for new balls to reference

	// Use this for initialization
	void Start ()
    {
        ballTransform = ball.transform;
	}
	
	// Update is called once per frame
	void Update ()
    {
        //given current prototype code, ball resets to plunger location if above bounds
        if ((ball!=null)&&((ball.transform.position.y >= bounds.transform.position.y)))
        {
            Destroy(ball);//destroying ball when out of bounds
        }

        //generate a new ball if other destroyed
        if (ball == null)
        {
            ball = CreateBall();
<<<<<<< HEAD
            //plunger.GetComponent<Plunger>().SetBall(ball);//lets plunger know about new ball
=======
            //if (plunger != null)
            {
                //plunger.GetComponent<Plunger>().SetBall(ball);//lets plunger know about new ball
            }
>>>>>>> e7cd39f63e55c43967c5b44fa4c88d3d8616fc3e
        }
            
	}
    public GameObject CreateBall()
    {
        GameObject temp;
        //should generate a new ball for when another is destroyed
        temp=Instantiate(ballPrefab, ballTransform);
        return temp;
    }
}
