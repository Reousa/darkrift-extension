using System;
using System.Collections.Generic;
using System.Linq;
using DarkRift.Extension.Message.Core;
using DarkRift.Server;

namespace DarkRift.Extension.Server
{
	public static class DarkRiftServerIClientExtension
	{
		/// <summary>
		/// Extension shorthand for sending reliable messages.
		/// </summary>
		/// <typeparam name="TTag">Type of tag used.</typeparam>
		/// <param name="client">IClient to which the message is sent.</param>
		/// <param name="message">Message object that inherits from IDarkRiftMessage</param>
		public static bool SendTcpMessage<TTag>(this IClient client, IDarkRiftMessage<TTag> message)
			where TTag : struct, Enum, IConvertible
		{
			using (DarkRiftWriter writer = DarkRiftWriter.Create())
			{
				writer.Write(message);

				using (DarkRift.Message msg = DarkRift.Message.Create(Convert.ToUInt16(message.Tag), writer))
					return client.SendMessage(msg, SendMode.Reliable);
			}
		}

		/// <summary>
		/// Extension shorthand for sending unreliable messages.
		/// </summary>
		/// <typeparam name="TTag">Type of tag used.</typeparam>
		/// <param name="client">IClient to which the message is sent.</param>
		/// <param name="message">Message object that inherits from IDarkRiftMessage</param>
		public static bool SendUdpMessage<TTag>(this IClient client, IDarkRiftMessage<TTag> message)
			where TTag : struct, Enum, IConvertible
		{
			using (DarkRiftWriter writer = DarkRiftWriter.Create())
			{
				writer.Write(message);

				using (DarkRift.Message msg = DarkRift.Message.Create(Convert.ToUInt16(message.Tag), writer))
					return client.SendMessage(msg, SendMode.Unreliable);
			}
		}

		/// <summary>
		/// Extension shorthand for sending empty reliable messages.
		/// </summary>
		/// <param name="client">Client to which this should be sent.</param>
		/// <param name="tag"></param>
		public static bool SendEmptyTcpMessage(this IClient client, ushort tag)
		{
			using (DarkRiftWriter writer = DarkRiftWriter.Create())
			{
				using (DarkRift.Message msg = DarkRift.Message.Create(tag, writer))
					return client.SendMessage(msg, SendMode.Reliable);
			}
		}

		/// <summary>
		/// Extension shorthand for sending empty unreliable messages.
		/// </summary>
		/// <param name="client">Client to which this should be sent.</param>
		/// <param name="tag"></param>
		public static bool SendEmptyUdpMessage(this IClient client, ushort tag)
		{
			using (DarkRiftWriter writer = DarkRiftWriter.Create())
			{
				using (DarkRift.Message msg = DarkRift.Message.Create(tag, writer))
					return client.SendMessage(msg, SendMode.Unreliable);
			}
		}

		/// <summary>
		/// Extension shorthand for sending empty reliable messages.
		/// </summary>
		/// <param name="client">Client to which this should be sent.</param>
		/// <param name="tag"></param>
		public static void SendEmptyTcpMessage<TTag>(this IClient client, TTag tag)
			where TTag : struct, Enum, IConvertible
		{
			using (DarkRiftWriter writer = DarkRiftWriter.Create())
			{
				using (DarkRift.Message msg = DarkRift.Message.Create(Convert.ToUInt16(tag), writer))
					client.SendMessage(msg, SendMode.Reliable);
			}
		}

		/// <summary>
		/// Extension shorthand for sending empty unreliable messages.
		/// </summary>
		/// <param name="client">Client to which this should be sent.</param>
		/// <param name="tag"></param>
		public static void SendEmptyUdpMessage<TTag>(this IClient client, TTag tag)
			where TTag : struct, Enum, IConvertible
		{
			using (DarkRiftWriter writer = DarkRiftWriter.Create())
			{
				using (DarkRift.Message msg = DarkRift.Message.Create(Convert.ToUInt16(tag), writer))
					client.SendMessage(msg, SendMode.Unreliable);
			}
		}

		/// <summary>
		/// Extension shorthand for sending reliable messages to all clients in a collection.
		/// </summary>
		/// <typeparam name="TTag"></typeparam>
		/// <param name="clients"></param>
		/// <param name="message"></param>
		public static void SendTcpMessageToAll<TTag>(this IEnumerable<IClient> clients, IDarkRiftMessage<TTag> message)
			where TTag : struct, Enum, IConvertible
		{
			foreach (var c in clients)
				c.SendTcpMessage(message);
		}

		/// <summary>
		/// Extension shorthand for sending unreliable messages to all clients in a collection.
		/// </summary>
		/// <typeparam name="TTag"></typeparam>
		/// <param name="clients"></param>
		/// <param name="message"></param>
		public static void SendUdpMessageToAll<TTag>(this IEnumerable<IClient> clients, IDarkRiftMessage<TTag> message)
			where TTag : struct, Enum, IConvertible
		{
			foreach (var c in clients)
				c.SendTcpMessage(message);
		}

		/// <summary>
		/// Extension shorthand for sending reliable messages to all clients in a collection, excluding one or multiple clients.
		/// </summary>
		/// <typeparam name="TTag"></typeparam>
		/// <param name="clients"></param>
		/// <param name="message"></param>
		/// <param name="exclusionList">List of IClients to exclude.</param>
		public static void SendTcpMessageToAllExcept<TTag>(this IEnumerable<IClient> clients, IDarkRiftMessage<TTag> message, IEnumerable<IClient> exclusionList)
			where TTag : struct, Enum, IConvertible
		{
			foreach (var c in clients.Except(exclusionList))
				c.SendTcpMessage(message);
		}

		/// <summary>
		/// Extension shorthand for sending unreliable messages to all clients in a collection, excluding one or multiple clients.
		/// </summary>
		/// <typeparam name="TTag"></typeparam>
		/// <param name="clients"></param>
		/// <param name="message"></param>
		/// <param name="exclusionList">List of IClients to exclude.</param>
		public static void SendUdpMessageToAllExcept<TTag>(this IEnumerable<IClient> clients, IDarkRiftMessage<TTag> message, IEnumerable<IClient> exclusionList)
			where TTag : struct, Enum, IConvertible
		{
			foreach (var c in clients.Except(exclusionList))
				c.SendUdpMessage(message);
		}
	}
}
