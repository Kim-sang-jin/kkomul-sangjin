using UnityEngine;

public class CharacterController : MonoBehaviour
{
    int state = 0;
    //캐릭터의 상태 0: 평소, 1: 가둠, 2: 사망
    public int count = 0;
    public int act1 = 5, act2 = 3, act3 = 2;
        // 1: 물방울설치, 2: 물줄기길이, 3: 이동속도
    float slow = 1; 
        //캐릭터의 상태에 따른 둔화율
    int score = 0;
    //float span = 1.0f, delta = 0;
    // 시간간격 체크
    int setBomb = 1;
    //폭탄설치 가능여부

    public GameObject character;
    public GameObject bombPrefab;

    void Start()
    {
        this.character = GameObject.Find("Character");
        //랜덤 위치 소환 -> 함수 사용: 타일 구현후 작성
    }

    void Update()
    {
        //캐릭터 상태
        if (state == 0)
        {
            slow = 1f;
        }
        if (state == 1)
        {
            setBomb = 0;
            slow = 0.1f;
            //3초 후 state=0
        }
        if (state == 2)
        {
            setBomb = 0;
            slow = 0f;
            //destroy, 3초 후 부활, start와 같은 함수
        }

        //캐릭터 이동: 이동속도 비례
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-0.1f*slow*act3, 0, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(0.1f*slow*act3, 0, 0);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(0, 0.1f*slow*act3, 0);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(0, -0.1f*slow*act3, 0);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (setBomb == 1)
            {
                MakeBomb();
                //폭탄 생성
            }
        }
    }

    void MakeBomb()
    {
        {
            if (count < act1)
            {
                count++;
                Vector2 p1 = this.character.transform.position;
                float checkX = transform.position.x - 0.5f;
                float checkY = transform.position.y - 0.5f;
                float X = Mathf.Round(checkX) + 0.5f;
                float Y = Mathf.Round(checkY) + 0.5f;
                if (true) //물풍선끼리 안겹칠떄
                {
                    GameObject bomb = Instantiate(bombPrefab) as GameObject;
                    bomb.transform.position = new Vector3(X, Y, 0);
                }
            }
        }
    }
    int stop()//벽과 충돌판정
    {
        return 0;
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bomb")
        {
            setBomb = 0;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bomb")
        {
            setBomb = 1;
        }
    }
}

