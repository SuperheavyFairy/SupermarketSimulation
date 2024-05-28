using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerScript : MonoBehaviour
{   
    public CustomerRouteScript routes;
    private List<GameObject> myRoute;
    private List<Vector2> velocities;
    private int nextPointIndex = 1;
    private Animator anim;
    private Rigidbody2D rb;
    private Transform nextPoint;
    public float speed = 2;

    void Start()
    {
        myRoute = routes.routes[Random.Range(0, routes.routes.Count-1)];
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        nextPoint = myRoute[nextPointIndex].transform;

        velocities = new List<Vector2>();
        for (int i = 1; i<myRoute.Count; i++)
        {
            Vector2 direction = myRoute[i].transform.position - myRoute[i-1].transform.position;
            velocities.Add(direction.normalized * speed);
        }
        rb.velocity = velocities[nextPointIndex-1];
        anim.SetBool(GetDirection(velocities[nextPointIndex-1]), true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, nextPoint.position) < 0.1f)
        {
            nextPointIndex++;
            nextPoint = myRoute[nextPointIndex].transform;
            rb.velocity = velocities[nextPointIndex-1];
            anim.SetBool(GetDirection(velocities[nextPointIndex-1]), true);
            anim.SetBool(GetDirection(velocities[nextPointIndex-2]), false);
        }

        if (transform.position.x > 10 || transform.position.x < -10 || transform.position.y > 6 || transform.position.y < -6)
        {
            Destroy(gameObject);
        }
    }

    private string GetDirection(Vector2 direction)
    {
        if (direction.x > 0)
        {
            return "isRight";
        }
        else if (direction.x < 0)
        {
            return "isLeft";
        }
        else if (direction.y > 0)
        {
            return "isUp";
        }
        else if (direction.y < 0)
        {
            return "isDown";
        }
        return "isIdle";
    }
}
