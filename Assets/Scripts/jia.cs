using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jia : MonoBehaviour {

    private SpriteRenderer sr;

    public Sprite dieSprite;


    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void Die()
    {
        sr.sprite = dieSprite;
    }
}
