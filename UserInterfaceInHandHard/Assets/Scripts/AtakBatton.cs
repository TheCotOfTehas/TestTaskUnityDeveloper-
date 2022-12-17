using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtakBatton : MonoBehaviour
{
    public GameObject buttonAtak1;
    public GameObject buttonAtak2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoAttak()
    {
        buttonAtak1.SetActive(false);
        buttonAtak2.SetActive(false);
    }
}
