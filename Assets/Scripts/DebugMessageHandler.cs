using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class DebugMessageHandler : MonoBehaviour, IReceiver<DebugLogMessage> {

	private void Awake() {
		PostOffice.instance.Register(typeof(DebugLogMessage), this);
	}

	public void Receive(DebugLogMessage message) {
		if (message != null) {
			Debug.Log(message.message);
		}
	}

	public void Receive(IUdpMessage message) {
		Receive(message as DebugLogMessage);
	}
}
