using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour {

    // Movement Speed
    public static float speed = 100.0f;
    // Use this for initialization
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        // Hit the Racket?
        if (col.gameObject.name == "Racket")
        {
            // Calculate hit Factor
            float x = hitFactor(transform.position,
                col.transform.position,
                col.collider.bounds.size.x);

            // Calculate direction, set length to 1
            Vector2 dir = new Vector2(x, 1).normalized;

            // Set Velocity with dir * speed
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }
        if (col.gameObject.name == "Ground")
        {
            Ball.racket--;
        }
        BallDestroy();
    }
    float hitFactor(Vector2 ballPos, Vector2 racketPos,
        float racketWidth)
    {
        // ascii art:
        //
        // 1  -0.5  0  0.5   1  <- x value
        // ===================  <- racket
        //
        return (ballPos.x - racketPos.x) / racketWidth;
    }
    public static int total_score = 0;
    public static int current_scene_score;
    public static int racket = 5;
    public static int currentSceneNum;
    //using UnityEngine.SceneManagement;
    void OnGUI()
    {
        int x = 5;
        int y = 5;
        int h = 100;
        int w = 150;
        int step = 15;
        GUI.Box(new Rect(x, y, w, h), SceneManager.GetActiveScene().name);
		GUI.BeginGroup(new Rect(x, y, w, h), "");
		GUI.Label(new Rect(x + step, y + step, w - 2 * step, 20), "Lifes: " + racket);
        GUI.Label(new Rect(x + step, y + 2 * step, w - 2 * step, 20), "Total score: " + total_score);
		GUI.Label(new Rect(x + step, y + 3 * step, w - 2 * step, 20), "Level score: " + current_scene_score);
		GUI.Label(new Rect(x + step, y + 4 * step, w - 2 * step, 20), "Speed: " + speed/100 + "x");
        GUI.EndGroup();

    }
    void BallDestroy()
    {
        if (racket == 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("Loosegame", LoadSceneMode.Single);
        }
        if (SceneManager.GetActiveScene().name == "FirstLevelScene")
        {
            if(GameObject.FindGameObjectsWithTag("Block").Length < 1)
            {
				SceneManager.LoadScene("Mario", LoadSceneMode.Single);
				racket++;
				speed += (float)30;
				current_scene_score = 0;
            }
        }
        else if (SceneManager.GetActiveScene().name == "SecondLevelScene")
        {
            if (GameObject.FindGameObjectsWithTag("Block").Length < 1)
			{
				SceneManager.LoadScene("ThirdLevelScene", LoadSceneMode.Single);
				racket++;
				speed += (float)30;
				current_scene_score = 0;
            }
        }
        else if (SceneManager.GetActiveScene().name == "ThirdLevelScene")
        {
            if (GameObject.FindGameObjectsWithTag("Block").Length < 1)
			{
				SceneManager.LoadScene("FourthLevelScene", LoadSceneMode.Single);
				racket++;
				speed += (float)20;
				current_scene_score = 0;
            }
        }
        else if (SceneManager.GetActiveScene().name == "FourthLevelScene")
        {
            if (GameObject.FindGameObjectsWithTag("Block").Length < 1)
			{
				SceneManager.LoadScene("FiveLevelScene", LoadSceneMode.Single);
				racket++;
				speed += (float)20;
				current_scene_score = 0;
            }
        }
        else if (SceneManager.GetActiveScene().name == "FiveLevelScene")
        {
            if (GameObject.FindGameObjectsWithTag("Block").Length < 1)
			{
                SceneManager.LoadScene("WinScene", LoadSceneMode.Single);
            }
        }
    }
}
