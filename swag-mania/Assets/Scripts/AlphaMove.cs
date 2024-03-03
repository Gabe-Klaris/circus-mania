using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*TWEENING FOR BOTH ALPHA (TRANSPARENCY) AND POSITION*/
public class AlphaMove : MonoBehaviour{
        public AnimationCurve curveMove = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);
        public AnimationCurve curveAlpha = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);
        Image thisImage;
        public Text buttonText;

        public bool isButton1 = false;
        bool doButton1 = false;
        public bool isButton2 = false;
        bool doButton2 = false;

        float button1Timer = 0.5f;
        float button2Timer = 1.5f;

        float preOffsetPos;
        float startOffset = 100f;
        Vector3 startButtonPos;

        public void AlphaStart(){
                preOffsetPos = transform.position.y; //save the destination
                startButtonPos = transform.position;
                startButtonPos.y += startOffset;
                transform.position = startButtonPos; //set the start position

                thisImage = GetComponent<Image>();
                thisImage.color = new Color(2.55f, 2.55f, 2.55f, 0f);
                buttonText = GetComponentInChildren<Text>();
                buttonText.color = new Color(2.55f, 2.55f, 2.55f, 0f);
                StartCoroutine(EntryCurve());
        }

        IEnumerator EntryCurve(){
                float elapsed = 0f;
                float elapsedMove = 0f;
                float timer = 0f;
                while (elapsed <= (button1Timer + button2Timer)) {
                        timer += Time.unscaledDeltaTime;
                        if (timer >= button1Timer){doButton1=true;}
                        if (timer >= button2Timer){doButton2=true;}

                        if (
                                ((isButton1) && (doButton1))
                                || ((isButton2) && (doButton2))
                        ){
                                // Tween Move:
                                if(startButtonPos.y >= preOffsetPos){
                                        startButtonPos.y -= curveMove.Evaluate(elapsedMove) * startOffset;
                                        transform.position = startButtonPos;
                                }
                                
                                // Tween Alpha:
                                float newAlpha = curveAlpha.Evaluate(elapsed);
                                thisImage.color = new Color(2.55f, 2.55f, 2.55f, newAlpha);
                                buttonText.color = new Color(2.55f, 2.55f, 2.55f, newAlpha);
                        }
                        elapsed += Time.unscaledDeltaTime;
                        elapsedMove += (Time.unscaledDeltaTime / 10f);
                        doButton1 = false;
                        doButton2 = false;
                        yield return null;
                }
        }
}