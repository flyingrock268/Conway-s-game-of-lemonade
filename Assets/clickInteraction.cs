using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(cell))]
public class clickInteraction : MonoBehaviour
{

    SpriteRenderer sprite;
    cell cell;

    cell.state currentState = cell.state.LEMON;

    float TimeGap = 0.5f, lastTime;

    // Start is called before the first frame update
    void Start()
    {
     
        sprite = GetComponent<SpriteRenderer>();
        cell = GetComponent<cell>();

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.mouseScrollDelta.y > 0)
        {

            if (currentState == cell.state.LEMON)
            {

                currentState = cell.state.WATER;

            }

            else if (currentState == cell.state.WATER)
            {

                currentState = cell.state.SUGAR;

            }

            else
            {

                currentState = cell.state.LEMON;

            }

        }

        else if (Input.mouseScrollDelta.y < 0) {

            if (currentState == cell.state.LEMON)
            {

                currentState = cell.state.SUGAR;

            }

            else if (currentState == cell.state.WATER)
            {

                currentState = cell.state.LEMON;

            }

            else
            {

                currentState = cell.state.WATER;

            }

        }

    }

    private void OnMouseDown()
    {

    }

    private void OnMouseOver()
    {

        if (Input.GetMouseButton(0) && Time.time > lastTime + TimeGap)
        {

            if (cell.cellState == currentState)
            {

                cell.cellState = cell.state.DEAD;

            }

            else
            {

                cell.cellState = currentState;

            }

            lastTime = Time.time;

        }

    }

}
