using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetUpBoundsScriptPT : MonoBehaviour
{
    // Use this for initialization
	void Start ()
    {
        SetUpColliders();

    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void SetUpColliders()
    {
        //Bottom
        BoxCollider2D box = transform.gameObject.AddComponent<BoxCollider2D>();
        box.offset = new Vector2(0.0f, -5.0f);
        box.size = new Vector2(18.0f, 0.5f);

        //Left
        box = transform.gameObject.AddComponent<BoxCollider2D>();
        box.offset = new Vector2(-10.0f, 0.0f);
        box.size = new Vector2(0.5f, 10.0f);

        //Right
        box = transform.gameObject.AddComponent<BoxCollider2D>();
        box.offset = new Vector2(10.0f, 0.0f);
        box.size = new Vector2(0.5f, 10.0f);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Destroy(col.gameObject);
    }
}
