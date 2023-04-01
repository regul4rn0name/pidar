using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        Ball.total_score++;
		Ball.current_scene_score++;
		// gameObject is current figure (like this)
        Destroy(gameObject);
    }
}
