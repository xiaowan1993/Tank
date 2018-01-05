using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zidan : MonoBehaviour {

    public float moveSpeed=8;
    public bool isPlayerZidan=true;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
      
    }
    private void FixedUpdate()
    {
        Move();
    }


    void Move()
    {
        transform.Translate(Vector3.up*Time.fixedDeltaTime*moveSpeed,Space.Self);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.tag);
        switch (collision.tag)
        {
            case "Player":
                if (!isPlayerZidan)
                {
                    collision.SendMessage("Die");
                    Destroy(gameObject);
                }
                break;
            case "Qiang":
                Destroy(collision.gameObject);
                Destroy(gameObject);
                break;
            case "Diren":
                if (isPlayerZidan)
                {
                    collision.SendMessage("Die");
                    Destroy(gameObject);
                }
                break;
            case "Gang":
                Destroy(gameObject);
                break;
            case "Jia":
                collision.SendMessage("Die");
                Destroy(gameObject);
                break;
            default:
                break;
        }
    }
}
