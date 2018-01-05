using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapCreate : MonoBehaviour {

    //0 家 1草 2刚 3水 4空气墙 5土墙 6出生效果 （包含玩家和敌人）
    public GameObject[] item;
    public float createEnemyTime = 5;
    public int maxEnemyCount = 6;

    private List<Vector3> itemPositionList=new List<Vector3>();

    private List<Vector3> enemyPositionList = new List<Vector3>();

    //最外一圈的特殊坐标，此坐标只可以生成土墙或者草丛
    private List<Vector3> specialPositionList = new List<Vector3>();

 
    public int qiangCount   =30;
    public int caoCount = 30;
    public int gangCount = 30;
    public int shuiCount = 30;

   

    private void Awake()
    {
        //创建老家
        CreateItem(item[0], new Vector3(0,-7,0), Quaternion.identity);
        //创建老家周围的墙
        CreateItem(item[5], new Vector3(-1, -7, 0), Quaternion.identity);
        CreateItem(item[5], new Vector3(1, -7, 0), Quaternion.identity);
        for(int i = -1; i < 2; i++)
        {
            itemPositionList.Add(new Vector3(i, -6, 0));
            CreateItem(item[5], new Vector3(i, -6, 0), Quaternion.identity);
        }
        //创建四周的空气墙
        //上下
        for(int i = -9; i <= 9; i++)
        {
            CreateItem(item[4], new Vector3(i, -8, 0), Quaternion.identity);
            CreateItem(item[4], new Vector3(i, 8, 0), Quaternion.identity);
            if (i != -9 && i != 9 && i != 0)
            {
                specialPositionList.Add(new Vector3(i, 7, 0));
            }
          
            List<int> m =new List<int> { -2,-1,0,1,2 };
            if (!m.Contains(i))
            {
                specialPositionList.Add(new Vector3(i, -7, 0));
            }
        }
        //左右
        for (int i = -7; i <= 7; i++)
        {
            CreateItem(item[4], new Vector3(-10, i, 0), Quaternion.identity);
            CreateItem(item[4], new Vector3(10, i, 0), Quaternion.identity);
            if (i != -7 && i != 7)
            {
                specialPositionList.Add(new Vector3(-9, i, 0));
                specialPositionList.Add(new Vector3(9, i, 0));
            }
           
        }

        //20个土墙
        for (int i = 0; i < qiangCount; i++)
        {
            CreateItem(item[5], generateRandomVector3(), Quaternion.identity);     
        }
        //20个草
        for (int i = 0; i < caoCount; i++)
        {
            CreateItem(item[1], generateRandomVector3(), Quaternion.identity);
        }
        //20个刚
        for (int i = 0; i < gangCount ; i++)
        {
            CreateItem(item[2], generateRandomVector3(), Quaternion.identity);
        }
        //20个水
        for (int i = 0; i < shuiCount ; i++)
        {
            CreateItem(item[3], generateRandomVector3(), Quaternion.identity);
        }


        //地图的最外一圈只能创建土墙或者草丛
        //随机生成n个最外层的东西
        int n=Random.Range(0, specialPositionList.Count);
        for(int i = 0; i < n; i++)
        {
            int r=Random.Range(0, 2);
            if (r == 0)
            {
                CreateItem(item[1], specialPositionList[Random.Range(0, specialPositionList.Count)], Quaternion.identity);
            }
            else {
                CreateItem(item[5], specialPositionList[Random.Range(0, specialPositionList.Count)], Quaternion.identity);
            }
        }


        //创建玩家
        GameObject playerBorn = CreateItem(item[6], new Vector3(-2, -7, 0), Quaternion.identity);
        playerBorn.GetComponent<born>().createPlayer = true;

        //创建敌人
        InvokeRepeating("CreateEnemy", 4, createEnemyTime);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    private Vector3 generateRandomVector3()
    {
        int x = Random.Range(-8,9);
        int y = Random.Range(-6, 7);
        Vector3 v3=new Vector3(x, y, 0);

        if (itemPositionList.Contains(v3))
        {
            return generateRandomVector3();
        }
        itemPositionList.Add(v3);
        return v3;
    }

    private GameObject CreateItem(GameObject obj,Vector3 position,Quaternion rotation)
    {
        GameObject item=  Instantiate(obj, position, rotation);
        item.GetComponent<Transform>().SetParent(transform);
        return item;
    }

    //创建敌人
    private void CreateEnemy()
    {

        if(GameObject.FindGameObjectsWithTag("Diren").Length>= maxEnemyCount)
        {
            //如果敌人数量超过了最大限度的敌人数量 那么不生成敌人了
            return;
        }
        int r=Random.Range(0, 3);
        if (r == 0)
        {  
            GameObject playerBorn = CreateItem(item[6], new Vector3(-9, 7, 0), Quaternion.identity);
            playerBorn.GetComponent<born>().createPlayer = false;

        }
        else if (r == 1)
        {
            GameObject playerBorn = CreateItem(item[6], new Vector3(0, 7, 0), Quaternion.identity);
            playerBorn.GetComponent<born>().createPlayer = false;
        }
        else if (r == 2)
        {
            GameObject playerBorn = CreateItem(item[6], new Vector3(9, 7, 0), Quaternion.identity);
            playerBorn.GetComponent<born>().createPlayer = false;
        }
    }

}
