using Microsoft.AspNet.SignalR;
using SignalRExperiments.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

namespace SignalRExperiments.PlaygoundHubs
{
	public class PlayGround : Hub
	{
		ChatHandler Handler = ChatHandler.Instance;
		public async void JoinGroup(string groupName)
		{
			if (ChatHandler.chatRooms.Values.Contains(groupName))
			{
				await Groups.Add(Context.ConnectionId, groupName);
				//Clients.Caller.SuccessfullyJoinedGroup("Successfully joined " + groupName);
			}
		}

		public async void CreateGroup(string groupName)
		{
			if (ChatHandler.chatRooms.Values.Contains(groupName))
			{
				Clients.Caller.AlreadyExists("Group already exists" + groupName);
			}
			else
			{
				ChatHandler.chatRooms.AddOrUpdate(Context.ConnectionId, groupName, (s, t) => {
					return groupName;
				});
				await Groups.Add(Context.ConnectionId, groupName);
				Clients.All.SuccessfullyJoinedGroup(groupName);
			}
		}

		public void LeaveGroup()
		{
			var userInfo = ChatHandler.chatRooms.Keys.FirstOrDefault(k => k.Equals(Context.ConnectionId));
			if (userInfo != null)
			{
				userInfo.Remove(0);
			}
		}

		public void DeleteGroup(string groupName)
		{

		}

		public async void SendMessage(string groupName,string message)
		{
			await Clients.Group(groupName).sendMessage(message);
		}

		public void SendOnlyTo(string connectionId, string message)
		{
			Clients.Client(connectionId).sendMessage(message);
		}

		public void IAmWriting(string connectionId)
		{
			Clients.All.iAmWriting("typing ...");
		}

		public void IAmWritingTo(string connectionId)
		{
			Clients.Client(connectionId).iAmWriting("typing ...");

		}

		public void GetActiveGroups()
		{
			Clients.Caller.PopulateActiveGroups(ChatHandler.chatRooms.Values);
		}

		
	}

}