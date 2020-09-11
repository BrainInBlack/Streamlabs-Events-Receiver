using System;
#if DEBUG
using System.IO;
#endif
using StreamlabsEventReceiver;

// Test envoirement for StreamlabsEventReceiver DLL
namespace TestEnv {

	class Program {

		static void Main(string[] args) {

			string token;
			if (args.Length > 0) {
				token = args[0];
			} else {
				Console.WriteLine("Please supply a SocketToken");
				Environment.Exit(1);
				return;
			}

			StreamlabsEventClient SER = new StreamlabsEventClient();

			SER.StreamlabsSocketConnected += (o, e) => {
				Console.WriteLine("Connected");
			};

			SER.StreamlabsSocketDisconnected += (o, e) => {
				Console.WriteLine("Disconnected");
			};

			SER.StreamlabsSocketError += (o, e) => {
				Console.Write(ObjectDumper.Dump(e));
			};

			SER.StreamlabsSocketEvent += (o, e) => {
				Console.Write(ObjectDumper.Dump(e.Data));
				Console.WriteLine("###########");
			};

#if DEBUG
			SER.StreamlabsSocketRaw += (o, e) => {
				File.AppendAllText(Path.Combine(Environment.CurrentDirectory, "RawData.json"), e.Data);
				Console.WriteLine(e.Data);
				Console.WriteLine("###########");
			};
#endif

			SER.Connect(token);

			Console.ReadKey();

		}
	}
}
