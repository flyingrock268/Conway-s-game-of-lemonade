using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cell : MonoBehaviour
{

    public List<cell> neighbors = new List<cell>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addNeighbor(cell x) { 
    
        neighbors.Add(x);
        x.neighbors.Add(this);
    
    }

}
