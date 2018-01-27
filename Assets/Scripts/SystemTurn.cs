using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts {
    public class SystemTurn : MonoBehaviour {
        void Start() {
            StartCoroutine(TurnBegin());
        }

        private IEnumerator TurnBegin() {
            // show spymaster and spies
            Debug.Log("Turn Begin");

            yield return WaitForInput(KeyCode.Space);
            StartCoroutine(TurnSeeIntercepts());
        }

        private IEnumerator TurnSeeIntercepts() {
            // show lines and shit
            Debug.Log("Turn SeeIntercepts");

            yield return WaitForInput(KeyCode.Space);
            TurnCheckWin();
        }

        private void TurnCheckWin() {
            // check for win conditions
            Debug.Log("Turn CheckWin");

            // if win end game
            // else
            StartCoroutine(TurnShuffle());
        }

        private IEnumerator TurnShuffle() {
            // shuffle all population
            // and execute previously queued actions
            Debug.Log("Turn Shuffle");

            yield return WaitForInput(KeyCode.Space);
            StartCoroutine(TurnCommsLink());
        }

        private IEnumerator TurnCommsLink() {
            // establish communication links
            Debug.Log("Turn CommsLink");

            yield return WaitForInput(KeyCode.Space);
            StartCoroutine(TurnQueueActions());
        }

        private IEnumerator TurnQueueActions() {
            // queue actions (MOVE or STANDBY)
            Debug.Log("Turn QueueActions");

            yield return WaitForInput(KeyCode.Space);
            TurnEnd();
        }

        private void TurnEnd() {
            // blackout and hide spymaster and spies
            Debug.Log("Turn End");
        }

        private IEnumerator WaitForInput(KeyCode keyCode) {
            yield return new WaitForSeconds(1);
            while (!Input.GetKeyDown(keyCode))
                yield return null;
        }
    }
}