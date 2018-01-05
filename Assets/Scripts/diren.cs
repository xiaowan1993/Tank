using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class diren : MonoBehaviour {

    public float moveSpeed=3;

    public GameObject zidan;
    public GameObject baoza;

    //两秒钟改变一次方向
    public  float changeFangXiang = 2f;
    private float changeFangXiangTime = 0f;
    private Vector3 fangxiang = Vector3.down;


    //每秒发射一发子弹
    public float fashe = 1f;
    public float fasheTime = 0f;

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


    private void Move()
    {
        
        if(changeFangXiangTime>= changeFangXiang)
        {
            changeFangXiangTime = 0f;
            float r=Random.Range(0, 8);
            if (r >= 0 && r < 2)
            {
                fangxiang = Vector3.left;
                //向左旋转90度
                transform.rotation = Quaternion.Euler(0, 0, 90);
            }else if (r >= 2 && r < 4)
            {
                fangxiang = Vector3.right;
                transform.rotation = Quaternion.Euler(0, 0, -90);
            }
            else if(r >= 4 && r < 5)
            {
                fangxiang = Vector3.up;
                transform.rotation = Quaternion.Euler(0, 0,0);
            }
            else if (r >= 5)
            {
                fangxiang = Vector3.down;
                transform.rotation = Quaternion.Euler(0, 0, 180);
            }
        }
        changeFangXiangTime += Time.fixedDeltaTime;
        transform.Translate(fangxiang*Time.fixedDeltaTime*moveSpeed,Space.World);
    }

    //敌人坦克攻击方法
    private void Attack()
    {
        if (fasheTime >= fashe)
        {
            fasheTime = 0f;
            GameObject obj=Instantiate(zidan, transform.position, transform.rotation);
            obj.GetComponent<zidan>().isPlayerZidan = false;
        }
        fasheTime += Time.deltaTime;
    }


    public void Die()
    {
        //先爆炸
        Instantiate(baoza, transform.position, Quaternion.identity);
        //后销毁
        Destroy(gameObject);
    }
}
