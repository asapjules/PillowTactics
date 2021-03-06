using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using PillowFight.Api.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PillowFight.Api.Hubs
{
    [Authorize]
    public class GameHub : Hub<IGameHubClient>
    {
        private const string userIdKey = "UserId";
        private const string groupIdKey = "GroupId";

        private readonly List<int> lobbyClients = new();
        private readonly Dictionary<Guid, GameRoom> rooms = new();

        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
            Context.Items[userIdKey] = Convert.ToInt32(Context.UserIdentifier);
            lobbyClients.Add((int)Context.Items[userIdKey]);
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            /*
             * Probably add some code in here to remove abandoned rooms, etc.
             */

            await base.OnDisconnectedAsync(exception);
            lobbyClients.Remove((int)Context.Items[userIdKey]);
        }

        public async Task SendAction(string characterAction)
        {
            /*
             * Parameter 'characterAction' will remain null until game server is implemented.
             * Parameter 'resultDescription' will remain empty until game server is implemented.
             * Parameter 'characters' will remain null until game server is implemented.
             */
            await Clients.Group("").ReceiveAction(null, string.Empty, null);
        }

        public async Task SendActionOptions(int characterId, string action)
        {
            /*
             * Parameter 'options' will remain null until game server implemented.
             */
            await Clients.Caller.ReceiveActionOptions(characterId, null);
        }

        public async Task SendAvailableActions(int characterId)
        {
            /*
             * Parameter 'actions' will remain null until game server implemented.
             */
            await Clients.Caller.ReceiveAvailableActions(characterId, null);
        }

        public async Task SendAvailableRooms()
        {
            await Clients.Caller.ReceiveAvailableRooms(rooms.Values);
        }

        public async Task SendJoinRoomRequest(string roomId)
        {
            try
            {
                // Get the requested room.
                var room = rooms[Guid.Parse(roomId)];

                // Attempt to join room.
                if (room.Player1Id == null)
                {
                    room.Player1Id = (int)Context.Items[userIdKey];
                }
                else if (room.Player2Id == null)
                {
                    room.Player2Id = (int)Context.Items[userIdKey];
                }
                else
                {
                    await Clients.Caller.ReceiveJoinRoomRequest(null, false);
                }

                // Remove player from lobby.
                lobbyClients.Remove((int)Context.Items[userIdKey]);

                // Add the player to the group associated with the room.
                await Groups.AddToGroupAsync(Context.ConnectionId, roomId);
            }
            catch
            {
                await Clients.Caller.ReceiveJoinRoomRequest(null, false);
            }
        }

        public async Task SendNewRoomRequest(string roomName)
        {
            // Remove player from lobby.
            lobbyClients.Remove((int)Context.Items[userIdKey]);

            // Create a new game room.
            var room = new GameRoom()
            {
                Id = Guid.NewGuid(),
                Name = roomName,
                Player1Id = (int)Context.Items[userIdKey]
            };

            // Track the room.
            rooms[room.Id] = room;

            // Create a new group associated with the room id and add the player.
            await Groups.AddToGroupAsync(Context.ConnectionId, room.Id.ToString());

            // Associate the room with this player's connection.
            Context.Items[groupIdKey] = room.Id;

            /*
             * Create a new game server hereabouts.
             */

            await Clients.Caller.ReceiveNewRoomRequest(room);
        }
    }
}
