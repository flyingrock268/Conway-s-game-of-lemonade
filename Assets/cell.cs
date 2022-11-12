using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class cell : MonoBehaviour
{

    SpriteRenderer spriteRenderer;

    public List<cell> neighbors = new List<cell>();

    public gridManager GM;

    float TimeGap = 0.5f, lastTime;

    public enum state { 
    
        DEAD,
        LEMON,
        WATER,
        SUGAR
    
    }

    public state cellState = state.DEAD;

    // Start is called before the first frame update
    void Start()
    {

        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        if (cellState == state.DEAD)
        {

            spriteRenderer.color = Color.gray;

        }

        else if (cellState == state.LEMON)
        {

            spriteRenderer.color = Color.yellow;

        }

        else if (cellState == state.WATER)
        {

            spriteRenderer.color = Color.blue;

        }

        else {

            spriteRenderer.color = Color.white;

        }
    }

    public void addNeighbor(cell x) { 
    
        neighbors.Add(x);
        x.neighbors.Add(this);
    
    }

    public state nextState() {

        int numDead = 0, numLemon = 0, numWater = 0, numSugar = 0;

        foreach (cell obj in neighbors) {

            if (obj.cellState == state.DEAD) {

                numDead++;
            
            }

            else if (obj.cellState == state.LEMON)
            {

                numLemon++;

            }

            else if (obj.cellState == state.WATER)
            {

                numWater++;

            }

            else
            {

                numSugar++;

            }

        }

        if (cellState == state.LEMON)
        {

            if (numLemon == 2 || numLemon == 3)
            {

                return cellState;

            }

            else
            {

                return state.DEAD;

            }

        }

        else if (cellState == state.WATER)
        {

            if (numWater == 2 || numWater == 3)
            {

                return cellState;

            }

            else
            {

                return state.DEAD;

            }

        }

        else if (cellState == state.SUGAR)
        {

            if (numSugar == 2 || numSugar == 3)
            {

                return cellState;

            }

            else
            {

                return state.DEAD;

            }

        }

        else {

            if (numLemon == 3)
            {

                return state.LEMON;

            }

            else if (numWater == 3)
            {

                return state.WATER;

            }

            else if (numSugar == 3)
            {

                return state.SUGAR;

            }

            else {

                return state.DEAD;
            
            }
        
        }
    
    }

    private void OnMouseOver()
    {

        if (Input.GetMouseButton(0) && Time.time > lastTime + TimeGap && GM.going == null)
        {

            if (cellState == GM.currentState)
            {

                cellState = cell.state.DEAD;

            }

            else
            {

                cellState = GM.currentState;

            }

            lastTime = Time.time;

        }

    }

}
