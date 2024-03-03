using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
      public GameObject textGameObject;
      private int score;
      public float theTimer;
      public Text timerText;
      public float startTime = 20;

      public int spawnRate = 3;

      private GameObject[] personsArr;

      private List<GameObject> persons;

      private int numPeople;

      
      public bool isEnd = true;
      void Start () {
            score = 0;
            theTimer = startTime;
            isEnd = false;
            if (isEnd) {
                  Cursor.lockState = CursorLockMode.None;
                  Cursor.visible = true;
            }
            personsArr = GameObject.FindGameObjectsWithTag("sitting");
            persons = new List<GameObject>(personsArr);
            numPeople = persons.Count;
            UpdateScore();
            StartCoroutine(peopleSpawn());
      }

      void Update () {
      }

      void FixedUpdate () {
            theTimer -= Time.deltaTime;
            timerText.text = "Time: " + Mathf.Floor(theTimer);
            if ((theTimer <= 0) && (isEnd == false)){
                  SceneManager.LoadScene("EndLose");
                  isEnd = true;
            }
      }

      public void AddScore (int newScoreValue) {
            score += newScoreValue;
            UpdateScore ();
            if (score >= numPeople) {
                  // Line should vary depending on the level
                  SceneManager.LoadScene("Level2");
                  isEnd = true;
            }
      }

      void UpdateScore () {
            Text scoreTextB = textGameObject.GetComponent<Text>();
            scoreTextB.text = "Score: " + score + "/" + numPeople;
      }

      public void PlayAgain() {
            SceneManager.LoadScene("Level1");
            theTimer = startTime;
            score = 0;
      }

      public void CreditsScene() {
            SceneManager.LoadScene("CreditsScene");
      }

      public void Return() {
            SceneManager.LoadScene("StartMenu");
      }

      public void QuitGame() {
            #if UNITY_EDITOR
                  UnityEditor.EditorApplication.isPlaying = false;
            #else
                  Application.Quit();
            #endif
      }

      public int GetScore () {
            return score;
      }

      IEnumerator peopleSpawn() {
            for (int i = 0; i < numPeople; i++) {
                  yield return new WaitForSeconds(spawnRate);
                  int pos = Random.Range(0, persons.Count);
                  GameObject person = persons[pos];
                  PersonSit sitPerson = person.GetComponent<PersonSit>();
                  sitPerson.StandUp();
                  Debug.Log(person);
                  persons.RemoveAt(pos);
            }
      }
}