using System;

namespace StreamlabsEventReceiver {
	public class StreamlabsEventArgs : EventArgs {
		public object Data { get; private set; }

		public StreamlabsEventArgs(object data) {
			Data = data;
		}
	}

#if DEBUG
    public class RawEventArgs : EventArgs
    {
        public string Data { get; private set; }

        public RawEventArgs(string data)
        {
            Data = data;
		}
	}
#endif
}
