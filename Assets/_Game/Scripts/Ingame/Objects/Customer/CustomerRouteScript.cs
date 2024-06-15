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
    public GameObject pointG;
    public GameObject pointH;
    public GameObject pointI;
    public GameObject pointJ;
    public GameObject end1;
    public GameObject end2;
    public List<List<GameObject>> routes = new List<List<GameObject>>();
    // Start is called before the first frame update
    void Start()
    {
        routes.Add(new List<GameObject> {pointA, pointB, pointE, pointH, pointI, end1});
        routes.Add(new List<GameObject> {pointA, pointB, pointE, pointF, pointI, end1});
        routes.Add(new List<GameObject> {pointA, pointB, pointE, pointF, pointI, pointJ, end2});
        routes.Add(new List<GameObject> {pointA, pointB, pointE, pointH, pointJ, end2});
        routes.Add(new List<GameObject> {pointA, pointB, pointE, pointF, pointG, pointJ, end2});
        routes.Add(new List<GameObject> {pointA, pointB, pointE, pointF, pointG, pointJ, pointI, end1});

        routes.Add(new List<GameObject> {pointA, pointC, pointF, pointE, pointH, pointI, end1});
        routes.Add(new List<GameObject> {pointA, pointC, pointF, pointI, pointJ, end2});
        routes.Add(new List<GameObject> {pointA, pointC, pointF, pointG, pointJ, end2});
        routes.Add(new List<GameObject> {pointA, pointC, pointF, pointG, pointJ, pointI, end1});

        routes.Add(new List<GameObject> {pointA, pointD, pointG, pointJ, pointI, end1});
        routes.Add(new List<GameObject> {pointA, pointD, pointG, pointF, pointI, pointJ, end2});
        routes.Add(new List<GameObject> {pointA, pointD, pointG, pointF, pointE, pointH, pointI, end1});
        routes.Add(new List<GameObject> {pointA, pointD, pointG, pointF, pointE, pointH, pointI, pointJ, end2});
        routes.Add(new List<GameObject> {pointA, pointD, pointG, pointF, pointC, pointB, pointH, pointI, end1});
        
    }

}
