using System.Net;

class DebugLogMessage : BaseUdpMessage {
	public string message { get; set; }

	protected override void OnDeserialize(IPEndPoint remote, DataReader reader) {
		sender = remote;
		message = reader.GetString();
	}

	public override void Serialize(DataWriter writer) {
		writer.Write(message);
	}
}
