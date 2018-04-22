using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGener : MonoBehaviour {
    public GameObject[] Gmap;
    public Map Mmap1;
    public Map Mmap2;
    private int mapCount = 2; 
    void Start()
    {

    }

    Map generateMap()
    {
        mapCount++;
        float z = 3000 * mapCount;
        int index = Random.Range(0, 3);
        GameObject map = GameObject.Instantiate(Gmap[index], new Vector3(0, 0, z), Quaternion.identity) as GameObject;
        return map.GetComponent<Map>();
    }

    public void UpdateMap()
    {
        Mmap1 = Mmap2;
        Mmap2 = generateMap();
    }
}
