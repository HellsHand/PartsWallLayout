using UnityEngine;
using System.Collections;

public class MouseBehavior : MonoBehaviour {

    Rigidbody rb;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
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
        rb.MovePosition(mouseLoc);
    }

    void OnTriggerEnter(Collider col)
    {
        gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
    }

    void OnTriggerExit(Collider col)
    {
        gameObject.GetComponent<MeshRenderer>().material.color = Color.white;
    }
}
