using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gridManager : MonoBehaviour
{

    public GameObject obj;

    public int numCol, numRow;
    public float distX, distY, XoffSet, YoffSet;
    public cell[,] grid;

    // Start is called before the first frame update
    void Start()
    {

        grid = new cell[numRow,numCol];

        for (int i = 0; i < numRow; i++) {

            for (int j = 0; j < numCol; j++) {

                cell temp = Instantiate(obj, transform.position + new Vector3(XoffSet + i * distX,YoffSet + j* distY, 0), Quaternion.identity).GetComponent<cell>();
                grid[i,j] = temp;

                //add above
                if (i != 0) {

                    if (j != numCol - 1)
                    {

                        temp.addNeighbor(grid[i - 1, j + 1]);

                    }

                    if (j != 0)
                    {

                        temp.addNeighbor(grid[i - 1, j - 1]);

                    }

                    temp.addNeighbor(grid[i-1,j]);


                
                }

                //add left
                if (j != 0) {

                    temp.addNeighbor(grid[i, j - 1]);

                }
            
            }
        
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
