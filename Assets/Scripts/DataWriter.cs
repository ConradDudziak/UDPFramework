using System.IO;
using System.Text;

public class DataWriter {
	private readonly MemoryStream stream;
	private readonly BinaryWriter writer;

	public DataWriter() {
		stream = new MemoryStream();
		writer = new BinaryWriter(stream);
	}

	public void Write(int value) {
		writer.Write(value);
	}

	public void Write(string value, bool writeLength = true) {
		if (string.IsNullOrEmpty(value)) {
			return;
		}

		if (writeLength) {
			writer.Write(value.Length);
		}
		writer.Write(Encoding.ASCII.GetBytes(value));
	}

	public byte[] Finalize() {
		writer.Flush();
		stream.Flush();
		var temp = stream.ToArray();

		writer.Close();
		writer.Dispose();
		stream.Close();
		stream.Dispose();

		return temp;
	}
}
