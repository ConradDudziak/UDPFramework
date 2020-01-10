using System.Net;

public interface IMessageSerializer {
	IUdpMessage ParseMessage(IMessageFactory factory, IPEndPoint remote, byte[] data);
	DataReader CreateReader(byte[] data);
}
