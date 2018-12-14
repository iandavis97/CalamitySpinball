using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour {

	private static int score=0;
	private static int ball=3;
	private static float multiplier=1;
	private static int timerEnd = 0;
    public GameObject manager;//reference to manager script attached to, to get text

	public static MessageManager messageManager;

	// Use this for initialization
	void Start ()
    {
        score = 0;
		messageManager = manager.GetComponent<MessageManager> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (System.DateTime.Today.Second >= timerEnd && timerEnd!=-1)
			multiplier = 1;
	}

	public static int Score{
	
		get{
			return score;
		}

        set
        {
            score = value;
            if (messageManager != null)
            {
                messageManager.ChangeScore(score);
            }
        }
	
	}

	public static MessageManager MessageManager {
		get {
			return messageManager;
		}
	}

	public static int Ball {
		get {
			return ball;
		}
        set
        {
            ball = value;
            if (messageManager != null)
            {
                messageManager.ChangeBall(ball);
            }
        }
	}


	public static float Multiplier{

		get{
			return multiplier;
		}

		set{
			multiplier = value;
		}

	}

	public static void IncreaseScore(int amount)
	{

		score += (int)(amount*multiplier);
        if (messageManager != null)
        {
            messageManager.ChangeScore(score);
        }
	}

	/// <summary>
	/// Sets the multiplier. This method was created to be used by the event system. When this method is triggered should be followed by the SetMultiplierTimer function. If it is not setafterward it will be indefinite.
	/// </summary>
	/// <param name="value">Value.</param>
	public static void SetMultiplier(float value){
	
		multiplier = value;
		SetMultiplierTimer (-1);
	
	}

	/// <summary>
	/// Sets the multiplier timer. This method was created to be used by the event system.
	/// </summary>
	/// <param name="seconds">Number of seconds before the multiplier is reset. The multiplier is indefinite if it is equal to -1.</param>
	public static void SetMultiplierTimer(int seconds)
	{

		timerEnd = System.DateTime.Today.Second + seconds;
		if (seconds == -1)
			timerEnd = -1;

	}

	/// <summary>
	/// This function is to be used outside of the event system because the multiplier should be set at the same time as it's timer.
	/// </summary>
	/// <param name="value">Value of the multiplier</param>
	/// <param name="seconds">Number of seconds before the multiplier is reset. The multiplier is indefinite if it is equal to -1.</param>
	public static void SetMultiplier(float value, int seconds)
	{

		multiplier = value;
		timerEnd = System.DateTime.Today.Second + seconds;
		if (seconds == -1)
			timerEnd = -1;

	}

    //creates space to display the score
    void OnGUI()
    {
        if (messageManager == null)
        {
            GUIStyle style = new GUIStyle();//used to modify text size
            style.fontSize = 50;
            style.normal.textColor = Color.white;
            GUI.Label(new Rect(10, 10, 100, 20), Score.ToString(), style);
        }
    }
}