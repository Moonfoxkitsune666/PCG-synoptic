using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pointtest : MonoBehaviour
{
    Text pointtext;
    scoresession scoresession;
    // Start is called before the first frame update
    void Start()
    {
        pointtext = GetComponent<Text>();
        scoresession = FindObjectOfType < scoresession>();
    }

    // Update is called once per frame
    void Update()
    {
        pointtext.text = scoresession.currentscore().ToString(); 
    }
}
