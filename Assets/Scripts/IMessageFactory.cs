using System.Collections;
using System.Collections.Generic;
using System.Net;

public interface IMessageFactory {
	IUdpMessage CreateMessage(string messageType, IPEndPoint remote, DataReader reader);
}
