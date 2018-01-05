using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float moveSpeed=3;

    public GameObject baoza;

    public GameObject zidanPrefab;
    public float zidanLenqueTime=0.4f;


    private void Awake()
    {
        
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Attack();
	}

    private void FixedUpdate()
    {
        Move();

    }


    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (zidanLenqueTime >= 0.4f)
            {
                GameObject obj=Instantiate(zidanPrefab, transform.position, transform.rotation);
                obj.GetComponent<zidan>().isPlayerZidan = true;
                zidanLenqueTime = 0;
            }
        }
        zidanLenqueTime += Time.deltaTime;
    }

    private void Move()
    {
        //竖直方向
        float v=Input.GetAxisRaw("Vertical");
        //水平方向
        float h = Input.GetAxisRaw("Horizontal");

        transform.Translate(Vector3.up * v * moveSpeed * Time.fixedDeltaTime, Space.World);
       // bool isKeySpace= Input.GetKeyDown(KeyCode.Space);

        if (v>0)
        {
            transform.rotation = Quaternion.Euler(0,0,0);
        }
        else if (v < 0)
        {
            transform.rotation = Quaternion.Euler(0,0,180);
        }

        if (v != 0)
        {
            return;
        }


        if (h > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, -90);
        }
        else if (h < 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 90);
        }

        transform.Translate(Vector3.right * h * moveSpeed * Time.fixedDeltaTime, Space.World);


    }

    public void Die()
    {
        //产生爆炸特效
        Instantiate(baoza, transform.position, Quaternion.identity);
        //销毁坦克
        Destroy(gameObject);
    }

}
