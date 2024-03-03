using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PersonSit : MonoBehaviour
{

    
    public GameObject standingPerson;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true);
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    

    public void StandUp() {
        standingPerson.SetActive(true);
        gameObject.SetActive(false);
    }
}
