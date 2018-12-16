using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallManager : MonoBehaviour
{
    public List<GameObject> balls;
    public GameObject bounds;
    public GameObject plunger;
    public GameObject ballPrefab;//used to generate new balls
    public int lives;//how many chances player gets to use ball
	public int timeAfterGameOver;
    Vector3 ballTransform;//position of ball at plunger for new balls to reference

	AudioSource audio;
	public AudioClip ballRespawn;
    public delegate void VoidZero();
    public static event VoidZero OnLoseLife;
	// Use this for initialization
	void Start ()
    {
        ScoreSystem.Ball = lives;
        ballTransform = balls[0].transform.position;
		audio = gameObject.GetComponent<AudioSource> ();
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
				if(PaddleBehavior.Touched)
                {
                	lives--;
                    OnLoseLife();
                }
                ScoreSystem.Ball = lives;
                if (lives > 0)
                {
					WaitForTime (1);
                    balls.Add(CreateBall());
                }
                else
                {
                    //when lives run out, end game
					WaitForTime(timeAfterGameOver);
                    SceneManager.LoadScene("Victory_Screen");
                }
				PaddleBehavior.Touched = false;
            }
        }
	}
    public GameObject CreateBall()
    {
        GameObject temp;
		PlaySound (ballRespawn);
        //should generate a new ball for when another is destroyed
        temp=Instantiate(ballPrefab);
        temp.transform.position = ballTransform;
        return temp;
    }
    //creates space to display the lives
    void OnGUI()
    {
        if (ScoreSystem.MessageManager == null)
        {
            GUIStyle style = new GUIStyle();//used to modify text size
            style.fontSize = 50;
            style.normal.textColor = Color.white;
            if (lives > 0)
                GUI.Label(new Rect(700, 10, 100, 20), "Lives: " + lives.ToString(), style);
            else if (lives <= 0)//temporary, until game over screen finalized
                GUI.Label(new Rect(600, 10, 100, 20), "GAME OVER", style);
        }
    }

    public void AddBall()
    {
        balls.Add(CreateBall());
    }

	IEnumerator WaitForTime(int seconds)
	{
		yield return new WaitForSeconds (seconds);
	}

	void PlaySound(AudioClip ac){
		if (audio != null && ac != null) {
			audio.PlayOneShot (ac);
		}
	}
}
