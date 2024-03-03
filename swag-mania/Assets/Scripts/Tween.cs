using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*TWEENING FOR SCALE*/
public class Tween : MonoBehaviour
{
        public AnimationCurve curve = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);
        public float tweenTime = 3;

        public void ButtonPop(){
                StartCoroutine(EntryCurve());
        }

        IEnumerator EntryCurve(){
                float timePassed = 0f;
                while (timePassed <= tweenTime) {
                        float percent = Mathf.Clamp01(timePassed / tweenTime);
                        float curvePercent = curve.Evaluate(percent);
                        transform.localScale = Vector3.LerpUnclamped(Vector3.zero,
                                                Vector3.one, curvePercent);
                        timePassed += Time.unscaledDeltaTime;
                        yield return null;
                }
        }
}
