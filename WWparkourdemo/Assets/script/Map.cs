using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour {

    public Barriers[] barriers;
    public trackPoints trackpoints;

    public float fstarLen = 10;
    public float fminLen = 10;
    public float fmaxLen = 100;
    public float mapLen=3000;

    private Transform tplayer;
    private int itargetPotIndex;
    void Awake()
    {
        GameObject gplayer = GameObject.FindGameObjectWithTag("player");
        if (gplayer)
            tplayer = gplayer.transform;
        trackpoints = transform.Find("waypoints").GetComponent<trackPoints>();

    }

    void start()
    {
        //GenerateBarriers();

    }

    Vector3 getTargetPot(float Zpos)
    {
        float t;
        int i, index, index_l;
        //float startZpos;
        Transform[] tracpots = trackpoints.trackpoints;
        index = 0;
        index_l=tracpots.Length - 1;
        for (i = 0; i < tracpots.Length; i++)
        {
            if (tracpots[i].position.z - tracpots[index_l].position.z >= Zpos)
                index = i;
            else break;
        }
        t = (Zpos  - tracpots[index].position.z) / (tracpots[index-1].position.z - tracpots[index].position.z);
        return Vector3.Lerp(tracpots[index].position, tracpots[index-1].position, t);
        }


    
    void GenerateBarriers()
    {
        float z, len;
        z= fstarLen;
        while (true)
        {
            len = Random.Range(fminLen,fmaxLen);
            z += len;
            if (z > mapLen) break;
            Vector3 setposition = getTargetPot(z);
            int index = Random.Range(0, barriers.Length);
            Barriers bar = (GameObject.Instantiate(barriers[index]) as Barriers);
            bar.initSelf(setposition, this.transform);
           // GenerateBarriers(setposition);
        }
    }

    public Vector3 GetTargetPot()
    {
        while (true)
        {
            if (trackpoints.trackpoints[itargetPotIndex].position.z - tplayer.position.z < 0.5f)
            { itargetPotIndex--;
                if (itargetPotIndex < 0)
                {
                    itargetPotIndex = 0;
                    Destroy(this.gameObject);
                    ((MapGener)GameObject.Find("player").GetComponent(typeof(MapGener))).UpdateMap();
                    return trackpoints.trackpoints[0].position;
                }
            }
            else
            {
                return trackpoints.trackpoints[itargetPotIndex].position;
            }
        }

    }







}

