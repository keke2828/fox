using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickEvent : MonoBehaviour
{
    [Header("點擊移動距離")]
    public float moveDist;

    [Header("點擊消失次數")]
    public int clickCount;

    [Header("播放音檔")]
    public GameObject audioOPrefab;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, 10, -1);
            if (hit.collider)
            {
                if (hit.collider.tag == "Pig")
                {
                    GameObject pigAudioClone = Instantiate(audioOPrefab);
                    Destroy(pigAudioClone, 2);

                    hit.collider.transform.Translate(moveDist, 0, 0);
                    clickCount--;

                    print("點到狐狸");
                    if (clickCount <= 0)
                    {
                        Destroy(hit.transform.gameObject);
                    }
                }                
            }
        }
    }
}
