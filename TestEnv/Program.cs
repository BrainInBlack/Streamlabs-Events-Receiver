using System;
using StreamlabsEventReceiver;

// Test envoirement for StreamlabsEventReceiver DLL
namespace TestEnv {

	class Program {

		static void Main(string[] args) {

			string token;
			if (args.Length > 0) {
				// Not really save, but it will do for most devs -BrainInBlack
				token = args[0];
			} else {
				// StreamLabs SocketToken -BrainInBlack
				token = "";
			}
			StreamlabsEventClient SER = new StreamlabsEventClient();

			SER.StreamlabsSocketConnected += (o, e) => {
				Console.WriteLine("Connected");
			};

			SER.StreamlabsSocketDisconnected += (o, e) => {
				Console.WriteLine("Disconnected");
			};

			SER.StreamlabsSocketEvent += (o, e) => {
				Console.Write(ObjectDumper.Dump(e.Data));
				Console.WriteLine("###########");
			};

			SER.Connect(token);

			Console.ReadKey();

		}
	}
}
