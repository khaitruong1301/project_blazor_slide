// namespace blazor_soan_slide.Store.Hub;

// using System;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.SignalR;

// public class ProductHub : Hub
// {
//     public override async Task OnConnectedAsync()
//     {
//         Console.WriteLine($"Client connected: {Context.ConnectionId}");
//         await base.OnConnectedAsync();
//     }

//     public override async Task OnDisconnectedAsync(Exception? exception)
//     {
//         var errorMessage = exception != null ? exception.Message : "No error information.";
//         Console.WriteLine($"Client disconnected: {Context.ConnectionId}, Error: {errorMessage}");
//     }

//     public async Task SendMessage(string message)
//     {
//         try
//         {
//             Console.WriteLine($"Message received: {message}");
//             await Clients.All.SendAsync("ReceiveMessage", message);
//         }
//         catch (Exception ex)
//         {
//             Console.WriteLine($"Error in SendMessage: {ex.Message}");
//         }
//     }
// }
