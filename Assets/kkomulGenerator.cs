using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kkomulGenerator : MonoBehaviour
{
    public GameObject kkomulPrefab;
    public GameObject bigkkomulPrefab;
    int px, py;
    float span = 3.5f;
    float delta = 0;
    int cnt = 5;
    int all = 0;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            GameObject kkomul;
            kkomul = Instantiate(kkomulPrefab) as GameObject;
            px = Random.Range(-10, 11);
            py = Random.Range(-7, 8);
            kkomul.transform.position = new Vector3(px, py, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime;
        if (this.all < 40)      //전체 꼬물이가 40마리 이하일 떄 까지만 생성, 터트리면 all 감소.
        {
            if (this.delta > this.span)
            {
                this.delta = 0;
                GameObject kkomul;

                if (cnt < 4)
                {
                    kkomul = Instantiate(kkomulPrefab) as GameObject;
                    this.cnt++;
                }
                else
                {
                    kkomul = Instantiate(bigkkomulPrefab) as GameObject;
                    this.cnt = 0;
                }

                px = Random.Range(-10, 11);
                py = Random.Range(-6, 7);
                kkomul.transform.position = new Vector3(px, py, 0);
                this.all++;
            }
        }
    }
}
