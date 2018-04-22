using UnityEngine;
using System.Collections;

public class Map : MonoBehaviour 
{
    public Barriers[] barriers;
    public trackPoints trackpoints;

    public float fstarLen = 10;
    public float fminLen = 10;
    public float fmaxLen = 100;

    private Transform tplayer;
    private int itargetPIndex;
    void Awake(){
        GameObject gplayer = GameObject.FindGameObjectWithTag("player");
        if (gplayer)
            tplayer = gplayer.transform;
        trackpoints = transform.Find("waypoints").GetComponent<trackPoints>();    
       
     }

    void start()
    {


    }

    }






