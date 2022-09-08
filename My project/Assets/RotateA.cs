using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateA : MonoBehaviour
{
    public float speed;
    public GameObject gObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(gObject.transform.position, new Vector3(0, 1, 0), speed * Time.deltaTime);
    }
}
