using System;
using System.Net;

public class ConnectedClient {
	public IPEndPoint remote { get; }
	public DateTime lastMessage { get; set; }
	public string username { get; set; }

	public ConnectedClient(IPEndPoint remote) {
		this.remote = remote;
		lastMessage = DateTime.Now;
		username = remote.ToString();
	}
}
