using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggeable : MonoBehaviour
{
  
    void Update()
    {
        
        
    }


    private void OnMouseDrag()
    {
        Vector3 newMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        newMousePosition.z = 0;
        transform.position = newMousePosition;
    }
}
