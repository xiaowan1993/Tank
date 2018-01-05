using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class born : MonoBehaviour {

    public GameObject player;

    //0大敌人 1小敌人
    public GameObject[] enemy;

    public bool createPlayer;

	// Use this for initialization
	void Start () {
        Invoke("createTank", 1f);
        Random.Range(0, enemy.Length);
        Destroy(gameObject,1f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void createTank()
    {
        if (createPlayer)
        {
            GameObject obj=Instantiate(player, transform.position, Quaternion.Euler(0,0,0));        
        }
        else
        {
            int i=Random.Range(0, enemy.Length);
            GameObject obj = Instantiate(enemy[i], transform.position, Quaternion.Euler(0,0,180));          
        }       
    }

}
