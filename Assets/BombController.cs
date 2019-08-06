using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
    public GameObject character;
    public GameObject bombPrefab;
    public GameObject linePrefab;
    float span = 2.5f;
    float delta = 0;

    void Start()
    {
        this.character = GameObject.Find("Character");
    }

    void Update()
    {
        Vector2 p1 = this.bombPrefab.transform.position;
        this.delta += Time.deltaTime;
        if (this.delta > this.span)
        {
            Destroy(bombPrefab);
            for (int i = 1; i <= 2; i++)
            {
                GameObject LineUp = Instantiate(linePrefab) as GameObject;
                LineUp.transform.position = new Vector3(p1.x, p1.y + i, 0);
                GameObject LineLeft = Instantiate(linePrefab) as GameObject;
                LineLeft.transform.position = new Vector3(p1.x - i, p1.y, 0);
                GameObject LineRight = Instantiate(linePrefab) as GameObject;
                LineRight.transform.position = new Vector3(p1.x + i, p1.y, 0);
                GameObject LineDown = Instantiate(linePrefab) as GameObject;
                LineDown.transform.position = new Vector3(p1.x, p1.y - i, 0); ; //2,5초 후 폭탄 파괴 및 물줄기 생성
            }
            GameObject LineCenter = Instantiate(linePrefab) as GameObject;
            LineCenter.transform.position = new Vector3(p1.x, p1.y, 0);
            this.delta = 0;
        }
    }

    void OnTriggerEnter2D(Collider2D linePrefab)//특정 못하나????
    {
        delta = 2.5f;
    }
    //만약에 특정되면, 같은자리에 물폭탄 여러개 못놓는기능을 이거로 구현하면 될듯
}
