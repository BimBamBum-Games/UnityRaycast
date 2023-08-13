using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycaster : MonoBehaviour
{


    private void Update()
    {
        CheckRaycast();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.LogWarning("Detected");
        CheckRaycast();
    }

    //We will use Raycast without garbage mode and it must be fixed size
    RaycastHit[] hits = new RaycastHit[5];

    //Then we assign value - enum on inspector
    public LayerMask unwantedLayer;

    //Also we need ray length
    public float rayDist = 5f;
    public void CheckRaycast()
    {
        //Create Ray
        Ray myray = new Ray(transform.position, transform.forward);

        //To see hitted ray also we are gonna add debugray

        Debug.DrawRay(transform.position, transform.forward * rayDist, Color.red);

        //This will not produce garbage and doesnt trigger gc, if you want you can make specific layer mask. Tilde ~ inverter.
        int triggeredQuantity = Physics.RaycastNonAlloc(myray, hits, rayDist, ~unwantedLayer);

        Debug.Log(triggeredQuantity);

        //To see which one detected.
        for(int i = 0; i < triggeredQuantity; i++)
        {
            Debug.LogAssertion(hits[i].transform.tag);
        }

    }


}
