using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SignalRExperiments.Handlers
{
	public class ChatHandler
	{
		private static ChatHandler  _Instance;
		public static ConcurrentDictionary<string, string> chatRooms = new ConcurrentDictionary<string, string>();
        
		public static ChatHandler Instance
		{
			get
			{
				if (_Instance == null)
				{
					return new ChatHandler();
				}

				return _Instance;
			}
		}
		
	}
}