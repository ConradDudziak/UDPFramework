using System;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class ConnectionManager : MonoBehaviour {
	private UDPConnection connection;
	private IMessageSerializer serializer;
	private IMessageFactory messageFactory;
	private Dictionary<string, ConnectedClient> clients = new Dictionary<string, ConnectedClient>();

	public int port = 54123;

	private void Awake() {
		connection = new UDPConnection(port);
		connection.Listen(DataReceived, 5000);
		serializer = new MessageSerializer();
		messageFactory = new MessageFactory();

		RegisterMessageHandlers();
	}

	private void DataReceived(IPEndPoint remote, byte[] data) {
		var message = serializer.ParseMessage(messageFactory, remote, data);
		if (message != null) {
			PostOffice.instance.Post(message);
		}

		// Must be the last line
		connection.Listen(DataReceived, 5000);
	}

	private void RegisterMessageHandlers() {
		PostOffice.instance.Register(typeof(WelcomeMessage), new CallbackReceiver<WelcomeMessage>(msg => {
			clients[msg.sender.ToString()] = new ConnectedClient(msg.sender);
		}));
	}
}
