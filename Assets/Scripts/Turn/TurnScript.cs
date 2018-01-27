using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Phase {
	Begin,
	SeeIntercepts,
	Shuffle,
	Comms,
	QueueActions,
	CheckWin,
	BlackOut
}

public class TurnScript : MonoBehaviour {
	public Turn_Begin TB;
	public Turn_SeeIntercepts TSI;
	public Turn_Shuffle TS;
	public Turn_Comms TC;
	public Turn_QueueActions TQA;
	public Turn_CheckWin TCW;
	public Turn_BlackOut TBO;
	public Phase phase = Phase.Begin;
	
	void Update() {
		switch (phase) {
			case Phase.Begin:
				TB.BeginLogic();
				phase = Phase.SeeIntercepts;
				break;
			case Phase.SeeIntercepts:
				TSI.SeeInterceptsLogic();
				phase = Phase.Shuffle;
				break;
			case Phase.Shuffle:
				TS.ShuffleLogic();
				phase = Phase.Comms;
				break;
			case Phase.Comms:
				TC.CommsLogic();
				phase = Phase.QueueActions;
				break;
			case Phase.QueueActions:
				TQA.QueueActionsLogic();
				phase = Phase.CheckWin;
				break;
			case Phase.CheckWin:
				TCW.CheckWinLogic();
				phase = Phase.BlackOut;
				break;
			case Phase.BlackOut:
				TBO.BlackOutLogic();
				phase = Phase.Begin;
				break;
			default:
				throw new ArgumentOutOfRangeException();
		}
	}
}
