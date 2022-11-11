using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gridManager : MonoBehaviour
{

    public GameObject obj;

    public int numCol, numRow;
    public float distX, distY, XoffSet, YoffSet;

    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i < numRow; i++) {

            for (int j = 0; j < numCol; j++) {

                Instantiate(obj, transform.position + new Vector3(XoffSet + i * distX,YoffSet + j* distY, 0), Quaternion.identity);
            
            }
        
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
