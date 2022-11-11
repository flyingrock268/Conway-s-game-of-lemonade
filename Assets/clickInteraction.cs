using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class clickInteraction : MonoBehaviour
{

    SpriteRenderer sprite;
    bool isAlive = false;

    float TimeGap = 0.5f, lastTime;

    // Start is called before the first frame update
    void Start()
    {
     
        sprite = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {

    }

    private void OnMouseOver()
    {

        if (Input.GetMouseButton(0) && Time.time > lastTime + TimeGap) {

            if (isAlive)
            {

                isAlive = false;
                sprite.color = Color.red;

            }

            else
            {

                isAlive = true;
                sprite.color = Color.green;

            }

            lastTime = Time.time;

        }

    }

}
