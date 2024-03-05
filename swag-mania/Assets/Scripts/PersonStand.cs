using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonStand : MonoBehaviour
{
    private GameController gameController;

    public GameObject sittingPerson;

    public GameObject angryPerson;

    private int nextUpdate = 2;

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
        if (Time.time >= nextUpdate && gameController.happiness) {
            nextUpdate = Mathf.FloorToInt(Time.time) + 1;
            UpdateEverySecond();
        }
    }

    void UpdateEverySecond() {
        gameController.AdjustHappy(1);
        happySlider mySlider = FindObjectOfType<happySlider>();
        if (mySlider != null) {
            mySlider.IncrementProgress(-0.01f); // Adjust the argument as needed
        }
    }

    void OnTriggerEnter(Collider other){
        Debug.Log(other.gameObject.tag);
        // Change to tag of object that will collide with this object (tshirt)
        if (other.gameObject.tag == "Shirt") {
            GetComponent<Collider> ().enabled = false;
            //GetComponent<AudioSource>().Play();
            gameController.AddScore(1);
            if (gameController.happiness) {gameController.AdjustHappy(-8);
                happySlider mySlider = FindObjectOfType<happySlider>();
                    if (mySlider != null) {
                    mySlider.IncrementProgress(0.08f); // Adjust the argument as needed
                }
            }
            StartCoroutine(DestroyThis());
        }
        Debug.Log("impact: " + gameController.GetScore());
    }

    IEnumerator DestroyThis(){
        sittingPerson.SetActive(true);
        gameObject.SetActive(false);
        yield return new WaitForSeconds(0.5f);
    }


    void OnEnable() {
        StartCoroutine(BecomeAngry());
    }

    IEnumerator BecomeAngry() {
        Debug.Log("Waiting");
        yield return new WaitForSeconds(5);
        Debug.Log("Done waiting");
        if (gameController.happiness) {
            angryPerson.SetActive(true);
            gameObject.SetActive(false);
        }
    }
    
}
