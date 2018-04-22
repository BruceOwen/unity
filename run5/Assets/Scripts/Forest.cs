using UnityEngine;
using System.Collections;

public class Forest : MonoBehaviour {

    public float startLength = 10;
    public float minLength = 10;
    public float maxLength = 100;

    public Obstacles[] obstacles;

    private Transform player;
    public WayPoints waypoints;
    private int targetWayPointIndex = 0;

    void Awake() {
        GameObject playerGo = GameObject.FindGameObjectWithTag(Tags.player);
        if (playerGo != null) {
            player = playerGo.transform;
        }
        //GameObject map = GameObject.FindGameObjectWithTag(Tags.player);
        waypoints = transform.Find("waypoints").GetComponent<WayPoints>();
        targetWayPointIndex = waypoints.waypoints.Length - 2;
    }

    void Start() {
        GenerateObstacles();
    }



    public Vector3 GetNextWayPoint() {
        while (true) {

            if (waypoints.waypoints[targetWayPointIndex].position.z - player.position.z < 0.5f) {
                targetWayPointIndex--;
                if (targetWayPointIndex < 0) {
                    targetWayPointIndex = 0;

                    Destroy(this.gameObject);
                   // Camera.main.SendMessage("UpdateForest", SendMessageOptions.DontRequireReceiver);
                    ((EnvGenerator)GameObject.Find("Player").GetComponent(typeof(EnvGenerator))).UpdateForest();
                    return waypoints.waypoints[0].position;
                }
            } else {
                return waypoints.waypoints[targetWayPointIndex].position;
            }
        }
    }

    void GenerateObstacles() {
        float z = startLength;
        while (true) {
            float length = Random.Range(minLength, maxLength);
            z += length;
            if (z > 3000) break;
            Vector3 waypoint = GetWayPoint(z);
            GenerateObstacles(waypoint);
        }
    }

    void GenerateObstacles(Vector3 position) {
        int index = Random.Range(0, obstacles.Length);
        Obstacles obs = (GameObject.Instantiate(obstacles[index]) as Obstacles);
        obs.InitSelf(position,this.transform);
    }

    Vector3 GetWayPoint(float z) {
        Transform[] wps = waypoints.waypoints;
        int index = GetIndex(z);
        //return Vector3.Lerp(wps[index].position, wps[index-1].position, (z - wps[index].position.z) / (wps[index-1].position.z - wps[index].position.z));
        return Vector3.Lerp(wps[index + 1].position, wps[index].position, (z + wps[wps.Length-1].position.z - wps[index + 1].position.z) / (wps[index].position.z - wps[index + 1].position.z));
    }

    int GetIndex(float z) {
        Transform[] wps = waypoints.waypoints;
        float startZ = wps[wps.Length - 1].position.z;
        int index = 0;
        for (int i = 0; i < wps.Length; i++) {
            if (wps[i].position.z - startZ >= z) {
                index = i;
            } else {
                break;
            }
        }
        return index;
    }


}
