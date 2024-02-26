using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonStand : MonoBehaviour
{
    private GameController gameController;

    public GameObject sittingPerson;

    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.FindWithTag ("GameController") != null) { 
            gameController = GameObject.FindWithTag ("GameController").GetComponent<GameController>();
        }
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }
    void OnTriggerEnter(Collider other){
        Debug.Log(other.gameObject.tag);
        // Change to tag of object that will collide with this object (tshirt)
        if (other.gameObject.tag == "Shirt") {
            GetComponent<Collider> ().enabled = false;
            //GetComponent<AudioSource>().Play();
            gameController.AddScore(1);
            StartCoroutine(DestroyThis());
        }
        Debug.Log("impact: " + gameController.GetScore());
    }

    IEnumerator DestroyThis(){
        sittingPerson.SetActive(true);
        gameObject.SetActive(false);
        yield return new WaitForSeconds(0.5f);
    }
    
}
