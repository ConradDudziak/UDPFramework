using System;
using System.Net;
using System.Net.Sockets;

public class UDPConnection {
    protected UdpClient client { get; }
	protected int port { get; }

	public UDPConnection(int port) {
		this.port = port;
		client = new UdpClient(port);
	}

	public void Send(IPEndPoint remoteAddress, byte[] message) {
		client.Send(message, message.Length, remoteAddress);
	}

	public void Listen(Action<IPEndPoint, byte[]> action, int timeoutMs = 0) {
		var result = client.BeginReceive(new AsyncCallback(OnMessageReceived), action);
		if (timeoutMs > 0) {
			result.AsyncWaitHandle.WaitOne(timeoutMs);
		}
	}

	private void OnMessageReceived(IAsyncResult ar) {
		var action = (Action<IPEndPoint, byte[]>)ar.AsyncState;
		if (ar.IsCompleted) {
			IPEndPoint remoteIP = null;
			var bytes = client.EndReceive(ar, ref remoteIP);
			action?.Invoke(remoteIP, bytes);
		} else {
			action?.Invoke(null, null);
		}
	}
}
