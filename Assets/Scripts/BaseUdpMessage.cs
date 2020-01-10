using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

abstract class BaseUdpMessage : IUdpMessage {
	public IPEndPoint sender { get; protected set; }

	public void Deserialize(IPEndPoint remote, DataReader reader) {
		sender = remote;
		OnDeserialize(remote, reader);
	}

	protected virtual void OnDeserialize(IPEndPoint remote, DataReader reader) {

	}

	public virtual void Serialize(DataWriter writer) {

	}
}
