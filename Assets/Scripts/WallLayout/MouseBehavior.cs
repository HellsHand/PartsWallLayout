using UnityEngine;
using System.Collections;

public class MouseBehavior : MonoBehaviour {

	void OnMouseEnter()
    {
        Debug.Log("Mouse Entered");
    }

    void OnMouseDown()
    { 
        Debug.Log("Mouse Pressed");
    }

    void OnMouseOver()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Destroy(gameObject);
        }
    }

    void OnMouseDrag()
    {
        float mouseX = Input.mousePosition.x;
        float mouseY = Input.mousePosition.y;
        Vector3 mouseLoc = Camera.main.ScreenToWorldPoint(new Vector3(mouseX, mouseY, 109));
        transform.position = mouseLoc;
    }
}
