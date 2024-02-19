using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    private GameController gameController;
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.FindWithTag ("GameController") != null) { 
            gameController = GameObject.FindWithTag ("GameController").GetComponent<GameController>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate (new Vector3 (15, 30, 45) * Time.deltaTime);
    }
    void OnTriggerEnter(Collider other){
        // Change to tag of object that will collide with this object (tshirt)
        if (other.gameObject.tag == "Player") {
            GetComponent<Collider> ().enabled = false;
            GetComponent<AudioSource>().Play();
            gameController.AddScore(1);
            StartCoroutine(DestroyThis());
        }
        Debug.Log("impact: " + gameController.GetScore());
    }

    IEnumerator DestroyThis(){
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
