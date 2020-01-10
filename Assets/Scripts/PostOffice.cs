using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostOffice : SingletonBehavior<PostOffice> {
	private Dictionary<Type, List<IReceiver>> receivers = new Dictionary<Type, List<IReceiver>>();
	private Stack<IUdpMessage> messages = new Stack<IUdpMessage>();

	private void Update() {
		while (messages.Count > 0) {
			var message = messages.Pop();
			List<IReceiver> temp = null;
			if (receivers.TryGetValue(message.GetType(), out temp)) {
				foreach (var r in temp) {
					r.Receive(message);
				}
			}
		}
	}

	public void Register(Type type, IReceiver receiver) {
		List<IReceiver> temp = null;
		if (!receivers.TryGetValue(type, out temp)) {
			receivers[type] = new List<IReceiver>();
			temp = receivers[type];
		}

		if (!temp.Contains(receiver)) {
			temp.Add(receiver);
		}
	}

	public void Post(IUdpMessage message) {
		messages.Push(message);
	}
}
