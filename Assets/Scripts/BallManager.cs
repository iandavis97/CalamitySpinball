using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    public List<GameObject> balls;
    public GameObject bounds;
    public GameObject plunger;
    public GameObject ballPrefab;//used to generate new balls
    public int lives;//how many chances player gets to use ball
    Vector3 ballTransform;//position of ball at plunger for new balls to reference

	// Use this for initialization
	void Start ()
    {
        ballTransform = balls[0].transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        int count = 0;
        bool killed = false;
        for (int i = 0; i < balls.Count; i++)
        {
            if (balls[i].transform.position.y <= bounds.transform.position.y)
            {
                Destroy(balls[i]);//destroying ball when out of bounds
                balls.RemoveAt(i);
                i--;
                killed = true;
            }
            else if (!balls[i].GetComponent<Rigidbody>().isKinematic)
            {
                count++;
            }
        }
        //generate a new ball if other destroyed
        if (count <= 0 && killed)
        {
            if (lives > 0)
            {
                lives--;
                if (lives > 0)
                {
                    balls.Add(CreateBall());
                }
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

    public void AddBall()
    {
        balls.Add(CreateBall());
    }
}
