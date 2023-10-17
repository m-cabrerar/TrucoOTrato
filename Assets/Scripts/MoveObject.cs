using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
   public GameObject HandPoint;

   private GameObject pickedObject = null;


   
    void Update()
    {
      if (pickedObject!=null)
      {
        if (Input.GetKey("r"))
        {
            pickedObject.GetComponent<Rigidbody>().useGravity=true;

            pickedObject.GetComponent<Rigidbody>().isKinematic = false;
            pickedObject.gameObject.transform.SetParent(null);
            pickedObject = null;

        }
      }

    
        
    }
    private void OnTriggerStay (Collider other)
    {
      if (other.gameObject.CompareTag("Object"))
      {
        if (Input.GetKey("e") && pickedObject==null )
        {
            other.GetComponent<Rigidbody>().useGravity=false;

            other.GetComponent<Rigidbody>().isKinematic = true;
            other.enabled = false;
            other.transform.position = HandPoint.transform.position;

            other.gameObject.transform.SetParent(HandPoint.gameObject.transform);

            pickedObject = other.gameObject;

        }

      }

    }
   



} 
