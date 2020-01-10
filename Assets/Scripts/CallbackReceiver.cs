using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallbackReceiver<T> : IReceiver<T> where T : class, IUdpMessage, new() {

	private readonly Action<T> callback;

	public CallbackReceiver(Action<T> callback) {
		this.callback = callback;
	}

	public void Receive(T message) {
		callback?.Invoke(message);
	}

	public void Receive(IUdpMessage message) {
		Receive(message as T);
	}
}
