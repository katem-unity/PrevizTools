using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapToPosition : MonoBehaviour
{
	public GameObject objectConstraint;
    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = objectConstraint.transform.position;
        this.transform.rotation = objectConstraint.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = objectConstraint.transform.position;
        this.transform.rotation = objectConstraint.transform.rotation;

        /*
        if (objectConstraint.active){
        	gameObject.SetActive(false);
        } else {
        	gameObject.SetActive(true);
        }
        */
    }
}
