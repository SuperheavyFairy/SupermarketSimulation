using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerRouteScript : MonoBehaviour
{   
    public GameObject pointA;
    public GameObject pointB;
    public GameObject pointC;
    public GameObject pointD;
    public GameObject pointE;
    public GameObject pointF;
    public GameObject end;
    public List<List<GameObject>> routes = new List<List<GameObject>>();
    // Start is called before the first frame update
    void Start()
    {
        routes.Add(new List<GameObject> {pointA, pointB, pointC, pointD, pointE, pointF, end});
        routes.Add(new List<GameObject> {pointA, pointB, pointC, pointF, end});
        routes.Add(new List<GameObject> {pointA, pointD, pointC, pointF, end});
        routes.Add(new List<GameObject> {pointA, pointD, pointE, pointF, end});
    }

}
