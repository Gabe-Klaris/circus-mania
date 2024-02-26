using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
      public GameObject textGameObject;
      private int score;
      public int scoreWin = 3;
      public float theTimer;
      public Text timerText;
      public float startTime = 20;

      public int numPeople;

      public GameObject[] personsArr;

      public List<GameObject> persons;

      public int spawnRate = 5;

      
      public bool isEnd = true;
      void Start () {
            score = 0;
            UpdateScore();
            theTimer = startTime;
            isEnd = false;
            if (isEnd) {
                  Cursor.lockState = CursorLockMode.None;
                  Cursor.visible = true;
            }
            personsArr = GameObject.FindGameObjectsWithTag("sitting");
            persons = new List<GameObject>(personsArr);
            StartCoroutine(peopleSpawn(persons.Count));
      }

      void Update () {
            if (Input.GetKey("escape")) {
                  QuitGame();
            }
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
            if (score >= scoreWin) {
                  SceneManager.LoadScene("EndWin");
                  isEnd = true;
            }
      }

      void UpdateScore () {
            Text scoreTextB = textGameObject.GetComponent<Text>();
            scoreTextB.text = "Score: " + score;
      }

      public void PlayAgain() {
            SceneManager.LoadScene("ThomasScene");
            theTimer = startTime;
            score = 0;
      }

      public void CreditsScene() {
            Debug.Log("not done yet");
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

      IEnumerator peopleSpawn(int numPeople) {
            for (int i = 0; i < numPeople; i++) {
                  yield return new WaitForSeconds(5);
                  int pos = Random.Range(0, persons.Count);
                  GameObject person = persons[pos];
                  PersonSit sitPerson = person.GetComponent<PersonSit>();
                  sitPerson.StandUp();
                  Debug.Log(person);
                  persons.RemoveAt(pos);
            }
      }
}