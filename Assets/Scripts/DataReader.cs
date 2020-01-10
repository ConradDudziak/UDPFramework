using System.IO;
using System.Text;

public class DataReader {
	private readonly MemoryStream stream;
	private readonly BinaryReader reader;

	public DataReader(byte[] data) {
		stream = new MemoryStream(data);
		reader = new BinaryReader(stream);
	}

	public string GetString() {
		int length = reader.ReadInt32();
		var temp = reader.ReadBytes(length);
		return Encoding.ASCII.GetString(temp);
	}

	public int GetInteger() {
		return reader.ReadInt32();
	}

	public void Close() {
		stream.Flush();
		reader.Close();
		reader.Dispose();
		stream.Close();
		stream.Dispose();
	}
}
