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
        CharacterController CC = GameObject.Find("Character").GetComponent<CharacterController>();
        Vector2 p1 = this.bombPrefab.transform.position;
        this.delta += Time.deltaTime;
        if (this.delta > this.span)
        {
            Destroy(bombPrefab);
            CC.count--;
            for (int i = 1; i <= CC.act2; i++)
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

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Line")
        {
            delta = 2.5f;
        }
    }
}
