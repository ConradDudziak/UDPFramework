using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using UnityEngine;

public class ConnectionClient : MonoBehaviour {
	private UDPConnection connection;
	public int localPort = 54124;
	public int serverPort = 54123;

	private void Awake() {
		connection = new UDPConnection(localPort);
	}

	public void SendString(string msg) {
		var serializer = new MessageSerializer();

		/*
		var debug = new DebugLogMessage {
			message = msg
		};
		*/
		var welcome = new WelcomeMessage();
		var bytes = serializer.SerializeMessage(welcome);
	
		connection.Send(new IPEndPoint(IPAddress.Broadcast, serverPort), bytes);
	}
}
