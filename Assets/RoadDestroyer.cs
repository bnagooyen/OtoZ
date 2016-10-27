using UnityEngine;
using System.Collections;

public class RoadDestroyer : MonoBehaviour {

	
  void OnTriggerEnter(Collider col)
    {

        if(col.gameObject.tag == "Road")
        {
            Destroy(col.gameObject);
        }

    }

	
}
