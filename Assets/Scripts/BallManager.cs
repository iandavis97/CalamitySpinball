using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    public GameObject ball;
    public GameObject bounds;
    public GameObject plunger;
    public GameObject ballPrefab;//used to generate new balls
    public int lives;//how many chances player gets to use ball
    Vector3 ballTransform;//position of ball at plunger for new balls to reference

	// Use this for initialization
	void Start ()
    {
        ballTransform = ball.transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        //given current prototype code, ball resets to plunger location if above bounds
        if ((ball!=null)&&((ball.transform.position.y <= bounds.transform.position.y)))
        {
            Destroy(ball);//destroying ball when out of bounds
            lives--;//decreasing lives when ball falls
        }

        //generate a new ball if other destroyed
        if ((ball == null)&&(lives>0))
        {
            ball = CreateBall();
            //plunger.GetComponent<Plunger>().SetBall(ball);//lets plunger know about new ball
            //if (plunger != null)
            {
                //plunger.GetComponent<Plunger>().SetBall(ball);//lets plunger know about new ball
            }
        }
        //when lives run out, end game
            
	}
    public GameObject CreateBall()
    {
        GameObject temp;
        //should generate a new ball for when another is destroyed
        temp=Instantiate(ballPrefab);
        temp.transform.position = ballTransform;
        return temp;
    }
    //creates space to display the lives
    void OnGUI()
    {
        GUIStyle style = new GUIStyle();//used to modify text size
        style.fontSize = 50;
        style.normal.textColor = Color.white;
        if(lives>0)
            GUI.Label(new Rect(700, 10, 100, 20), "Lives: "+lives.ToString(), style);
        else if (lives<=0)//temporary, until game over screen finalized
            GUI.Label(new Rect(600, 10, 100, 20), "GAME OVER", style);
    }
}
