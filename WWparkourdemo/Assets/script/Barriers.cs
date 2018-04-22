using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barriers : MonoBehaviour
{

    public float wide = 14.0f;
    public virtual void initSelf(Vector3 pos, Transform parent = null)
    {
        this.transform.parent = parent;
        bool first = true;
        int i, count, track;
        count = Random.Range(1, 4);
        track = Random.Range(-1, 1);
        for (i = -1; i < 2; i++)
        {
            if (count == 1)
                this.transform.position = new Vector3(pos.x + track * wide, pos.y, pos.z);
            else 
            {
                if (count == 2)
                    if (track == i) continue;
                if (first)
                {
                    first = false;
                    this.transform.position = new Vector3(pos.x + i * wide, pos.y, pos.z);
                }
                else
                {
                    Vector3 tempos = new Vector3(pos.x + i * wide, pos.y, pos.z);
                    GameObject bar = GameObject.Instantiate(this.gameObject, tempos, Quaternion.identity) as GameObject;
                    bar.transform.parent = parent;

                }
            }

        }
    }
}
