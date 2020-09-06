using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody rb;
    public float amplify = 10;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //AddForce();

    }

    // Update is called once per frame
    void Update()
    {


    }
    /**
    * Does when something hits something
    */
    void OnCollisionEnter(Collision other)
    {
        Debug.Log("I hit something " + gameObject.name);
        Debug.Log("I hit a " + other.gameObject.name);

        // if want to the change the color that this is attached other we change
        // the game object
        // ball changes color
        //gameObject.GetComponent<MeshRenderer>().material.color = NewColor();
        // floor changes color
        other.gameObject.GetComponent<MeshRenderer>().material.color = NewColor();

    }
    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AddForce();
        }

    }

    private void AddForce()
    {
        // goes straight down the x axis
        rb.AddForce(new Vector3(1, 0, 0 * amplify));
    }
    private void ResetForce()
    {
        // goes straight down the x axis
        rb.AddForce(new Vector3(1, 0, 0));
    }
    /**
    * Returns the color when the object hits something
    * @return color - the color object
    */
    private Color NewColor()
    {
        // uses random values for RGB
        Color color = new Color(UnityEngine.Random.value,
                                UnityEngine.Random.value,
                                UnityEngine.Random.value);
        return color;
    }

}
