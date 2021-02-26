using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goal : MonoBehaviour
{

    [SerializeField] int pointvalue = 1;
    [SerializeField] AudioClip ballscoreSound;
    [SerializeField] [Range(0, 1)] float ballscorevolume = 0.6f;

    private void OnTriggerEnter2D(Collider2D ball)
    {
        Destroy(ball.gameObject);
        AudioSource.PlayClipAtPoint(ballscoreSound, Camera.main.transform.position, ballscorevolume);

        FindObjectOfType<scoresession>().UpdateScore(pointvalue);
    }
}
