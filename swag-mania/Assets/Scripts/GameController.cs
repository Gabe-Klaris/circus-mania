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
                  SceneManager.LoadScene("EndScene");
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
            SceneManager.LoadScene("GameScene");
            theTimer = startTime;
            score = 0;
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
}