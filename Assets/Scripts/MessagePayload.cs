using System.Collections;
using System.Collections.Generic;

public class MessagePayload {
    public string messageType { get; }

	public byte[] payload { get; }

	public MessagePayload(string messageType, byte[] payload) {
		this.messageType = messageType;
		this.payload = payload;
	}
}
