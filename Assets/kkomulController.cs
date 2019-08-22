using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kkomulController : MonoBehaviour
{
    public int state = 0;
    int direction;

    float span = 3.0f;
    float delta = 0;

    float free = 0;
    float sur = 3.0f;

    //GameObject block;

    // Start is called before the first frame update
    void Start()
    {
        //this.block = GameObject.Find("block");
        direction = Random.Range(0, 4);
    }

    // Update is called once per frame
    void Update()
    {
        if (state == 0)
        {
            switch (direction)
            {
                case 0:     //오른쪽
                    transform.Translate(0.03f, 0, 0);
                    break;
                case 1:     //왼쪽
                    transform.Translate(-0.03f, 0, 0);
                    break;
                case 2:     //아래쪽
                    transform.Translate(0, -0.03f, 0);
                    break;
                case 3:     //위쪽
                    transform.Translate(0, 0.03f, 0);
                    break;
                default:
                    break;
            }

            //블록과 충돌하면 direction 의 random 값을 다시 설정
            //Vector3 pos = this.gameObject.transform.position;
            
           Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
            if (pos.x < 0.1f)
            {
                pos.x = 0.1f;
                direction = Random.Range(0, 4);
            }
            if (pos.x > 0.9f)
            {
                pos.x = 0.9f;
                direction = Random.Range(0, 4);
            }
            if (pos.y < 0.1f)
            {
                pos.y = 0.1f;
                direction = Random.Range(0, 4);
            }
            if (pos.y > 0.9f)
            {
                pos.y = 0.9f;
                direction = Random.Range(0, 4);
            }
            transform.position = Camera.main.ViewportToWorldPoint(pos);
        }
        if (state == 1)
        {
            transform.Translate(0, 0, 0);

            this.free += Time.deltaTime;
            if (this.free > this.sur)
            {
                state = 0;
                this.free = 0;
            }

        }
        if (state == 2)
        {
            Destroy(this.gameObject);
            this.delta = 0;
        }

        this.delta += Time.deltaTime;
        if (this.delta > this.span)
        {
            this.delta = 0;
            direction = Random.Range(0, 4);
        }   
    }

    void OnTriggerEnter2D(Collider2D other)
    //rigidBody가 무언가와 충돌할때 호출되는 함수 입니다.
    //Collider2D other로 부딪힌 객체를 받아옵니다.
    {
        if (other.gameObject.tag.Equals("line"))        //물줄기랑 꼬물이 충돌하면 state = 1
         {
            state = 1;      
         }

        if (state == 1) {
            if (other.gameObject.tag.Equals("Player")) {
                state = 2;
            }
        }
    }
}
