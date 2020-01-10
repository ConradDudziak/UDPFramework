public interface IReceiver {
	void Receive(IUdpMessage message);
}

public interface IReceiver<T> : IReceiver where T: IUdpMessage {
	void Receive(T message);
}
