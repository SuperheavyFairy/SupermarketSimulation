using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerScript : MonoBehaviour
{   
    // Animation and movement variables

    [SerializeField] public CustomerRouteScript routes;
    private List<GameObject> myRoute;
    private List<Vector2> velocities;
    private int nextPointIndex = 1;
    private Animator anim;
    private Rigidbody2D rb;
    private Transform nextPoint;
    [SerializeField] public float speed = 2;

    // List of stuff customers can buy

    // Event
    // [SerializeField] public EventScript event;

    // Customer stuff demand parameters
    [SerializeField] private static int foodDemandParam = 1;
    [SerializeField] private static int drinkDemandParam = 1;
    [SerializeField] private static int clothesDemandParam = 2;

    // Customer maximum price acceptance 
    [SerializeField] private static int deltaPrice = 10;
    private int maxPriceFood = 30 + deltaPrice * foodDemandParam;
    private int maxPriceDrink = 20 + deltaPrice * drinkDemandParam;
    private int maxPriceClothes = 50 + deltaPrice * clothesDemandParam;

    // Customer maximum products buying
    [SerializeField] private static int deltaProducts = 1;
    private int maxNumberFood = 1 + deltaProducts * foodDemandParam;
    private int maxNumberDrink = 1 + deltaProducts * drinkDemandParam;
    private int maxNumberClothes = 1 + deltaProducts * clothesDemandParam;

    // public CustomerScript(EventScript eventScript)
    // {
    //     // Customer demand
    //     foodDemandParam = eventScript.GetFoodDemand();
    //     drinkDemandParam = eventScript.GetDrinkDemand();
    //     clothesDemandParam = eventScript.GetClothesDemand();

    //     // Customer maximum price acceptance
    //     maxPriceFood = 30 + deltaPrice * foodDemandParam;
    //     maxPriceDrink = 20 + deltaPrice * drinkDemandParam;
    //     maxPriceClothes = 50 + deltaPrice * clothesDemandParam;

    //     // Customer maximum products buying
    //     maxNumberFood = 1 + deltaProducts * foodDemandParam;
    //     maxNumberDrink = 1 + deltaProducts * drinkDemandParam;
    //     maxNumberClothes = 1 + deltaProducts * clothesDemandParam;
    // }


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
