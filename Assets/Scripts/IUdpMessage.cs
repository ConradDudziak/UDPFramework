using System.Net;

public interface IUdpMessage {
	IPEndPoint sender { get; }
	void Deserialize(IPEndPoint remote, DataReader reader);
	void Serialize(DataWriter writer);
}
