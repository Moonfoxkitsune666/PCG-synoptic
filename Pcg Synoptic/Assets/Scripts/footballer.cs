using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class footballer : MonoBehaviour
{
    [SerializeField] float runningspeed = 5f;
    [SerializeField] float footballerpadding = 0.7f;

    [SerializeField] GameObject footballPrefab;
    [SerializeField] float ballShootTime = 2f;

    float xCamMin, xCamMax, yCamMin, yCamMax;
    Coroutine kickCoroutine;
    bool coroutineStart = false;
    // Start is called before the first frame update
    void Start()
    {
        footballerBounds();
    }

    // Update is called once per frame
    void Update()
    {
        footballermove();
        kickfootball();
    }

    private void footballerBounds()
    {
        Camera gamecam = Camera.main;

        xCamMin = gamecam.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + footballerpadding;
        xCamMax = gamecam.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - footballerpadding;
        yCamMin = gamecam.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + footballerpadding;
        yCamMax = gamecam.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - footballerpadding;
    }

    private void footballermove()
    {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * runningspeed;
        var newxpos = transform.position.x + deltaX;
        newxpos = Mathf.Clamp(newxpos, xCamMin, xCamMax);
        var deltay = Input.GetAxis("Vertical") * Time.deltaTime * runningspeed;
        var newypos = transform.position.y + deltay;
        newypos = Mathf.Clamp(newypos, yCamMin, yCamMax);
        this.transform.position = new Vector2(newxpos, newypos);
    }

    private IEnumerator ShootLoop()
    {
        while(true)
        {
            GameObject football = Instantiate(footballPrefab, transform.position, Quaternion.identity);
            football.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-2f,2f), 15f);
            yield return new WaitForSeconds(ballShootTime);
        }
    }

    private void kickfootball()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            if(!coroutineStart)
            {
                kickCoroutine = StartCoroutine(ShootLoop());
                coroutineStart = true;
            }
        }

        if (Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(kickCoroutine);
            coroutineStart = false;
        }
    }
}
