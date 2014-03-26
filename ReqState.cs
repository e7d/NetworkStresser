using System;

namespace Network_Stresser
{
	public enum ReqState
	{
		Ready,
		Connecting,
		Requesting,
		Downloading,
		Completed,
		Failed
	};
}
