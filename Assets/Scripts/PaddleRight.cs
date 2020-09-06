using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleRight : MonoBehaviour
{
    public float amplify = 1;
    public int score = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, 0, Input.GetAxis("PaddleRight")) * Time.deltaTime * amplify);
    }
}
