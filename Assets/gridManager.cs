using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gridManager : MonoBehaviour
{

    public GameObject obj;

    public int numCol, numRow;
    public float distX, distY, XoffSet, YoffSet;
    public cell[,] grid, grid2;

    public cell.state currentState = cell.state.LEMON;

    public Coroutine going = null;

    // Start is called before the first frame update
    void Start()
    {

        grid = new cell[numRow,numCol];
        grid2 = new cell[numRow,numCol];

        for (int i = 0; i < numRow; i++) {

            for (int j = 0; j < numCol; j++) {

                cell temp = Instantiate(obj, transform.position + new Vector3(XoffSet + i * distX,YoffSet + j* distY, 0), Quaternion.identity).GetComponent<cell>();
                grid[i,j] = temp;
                temp.GM = this;

                cell temp2 = Instantiate(obj, transform.position + new Vector3(XoffSet + i * distX, YoffSet + j * distY, 0), Quaternion.identity).GetComponent<cell>();
                grid2[i, j] = temp2;
                temp2.GM = this;

                //add above
                if (i != 0) {

                    if (j != numCol - 1)
                    {

                        temp.addNeighbor(grid[i - 1, j + 1]);
                        temp2.addNeighbor(grid2[i - 1, j + 1]);

                    }

                    if (j != 0)
                    {

                        temp.addNeighbor(grid[i - 1, j - 1]);
                        temp2.addNeighbor(grid2[i - 1, j - 1]);

                    }

                    temp.addNeighbor(grid[i-1,j]);
                    temp2.addNeighbor(grid2[i-1,j]);


                
                }

                //add left
                if (j != 0) {

                    temp.addNeighbor(grid[i, j - 1]);
                    temp2.addNeighbor(grid2[i, j - 1]);

                }

                temp2.gameObject.SetActive(false);
            
            }
        
        }

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E)) {

            if (going == null)
            {

                if (grid[0, 0].gameObject.activeSelf)
                {

                    for (int i = 0; i < numRow; i++)
                    {

                        for (int j = 0; j < numCol; j++)
                        {

                            grid2[i, j].cellState = grid[i, j].nextState();

                        }

                    }

                }

                else
                {

                    for (int i = 0; i < numRow; i++)
                    {

                        for (int j = 0; j < numCol; j++)
                        {

                            grid[i, j].cellState = grid2[i, j].nextState();

                        }

                    }

                }

                going = StartCoroutine(nextLife());

            }

            else {

                StopCoroutine(going);
                going = null;


            
            }            

        }

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

        else if (Input.mouseScrollDelta.y < 0)
        {

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

    public IEnumerator nextLife() {

        while (true) {

            for (int i = 0; i < numRow; i++)
            {

                for (int j = 0; j < numCol; j++)
                {

                    grid2[i, j].cellState = grid[i, j].nextState();
                    grid[i, j].gameObject.SetActive(false);
                    grid2[i, j].gameObject.SetActive(true);
                
                }

            }

            yield return new WaitForSeconds(0.2f);

            for (int i = 0; i < numRow; i++)
            {

                for (int j = 0; j < numCol; j++)
                {

                    grid[i, j].cellState = grid2[i, j].nextState();
                    grid2[i, j].gameObject.SetActive(false);
                    grid[i, j].gameObject.SetActive(true);

                }

            }

            yield return new WaitForSeconds(0.2f);

        }
    
    }

}
