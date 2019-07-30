using System;
using DarkRift.Client;
using DarkRift.Extension.Message.Core;

namespace DarkRift.Extension.Client
{
	public static class DarkRiftClientExtension
	{

		/// <summary>
		/// Extension shorthand for sending reliable messages.
		/// </summary>
		/// <typeparam name="TTag">Type of the message that inherits from IMessage & IDarkRiftSerializable</typeparam>
		/// <param name="client">Client to which this should be sent.</param>
		/// <param name="message">Message object</param>
		public static void SendMessageReliable<TTag>(this DarkRiftClient client, IDarkRiftMessage<TTag> message)
			where TTag : struct, Enum, IConvertible
		{
			using (DarkRiftWriter writer = DarkRiftWriter.Create())
			{
				writer.Write(message);

				using (DarkRift.Message msg = DarkRift.Message.Create(Convert.ToUInt16(message.Tag), writer))
					client.SendMessage(msg, SendMode.Reliable);
			}
		}

		/// <summary>
		/// Extension shorthand for sending unreliable messages.
		/// </summary>
		/// <typeparam name="TTag">Type of the message that inherits from IMessage & IDarkRiftSerializable</typeparam>
		/// <param name="client">Client to which this should be sent.</param>
		/// <param name="message">Message object</param>
		public static void SendMessageUnreliable<TTag>(this DarkRiftClient client, IDarkRiftMessage<TTag> message)
			where TTag : struct, Enum, IConvertible
		{
			using (DarkRiftWriter writer = DarkRiftWriter.Create())
			{
				writer.Write(message);

				using (DarkRift.Message msg = DarkRift.Message.Create(Convert.ToUInt16(message.Tag), writer))
					client.SendMessage(msg, SendMode.Unreliable);
			}
		}

		/// <summary>
		/// Extension shorthand for sending empty reliable messages.
		/// </summary>
		/// <param name="client">Client to which this should be sent.</param>
		/// <param name="tag"></param>
		public static void SendEmptyMessageReliable(this DarkRiftClient client, ushort tag)
		{
			using (DarkRiftWriter writer = DarkRiftWriter.Create())
			{
				using (DarkRift.Message msg = DarkRift.Message.Create(tag, writer))
					client.SendMessage(msg, SendMode.Reliable);
			}
		}

		/// <summary>
		/// Extension shorthand for sending empty unreliable messages.
		/// </summary>
		/// <param name="client">Client to which this should be sent.</param>
		/// <param name="tag"></param>
		public static void SendEmptyMessageUnreliable(this DarkRiftClient client, ushort tag)
		{
			using (DarkRiftWriter writer = DarkRiftWriter.Create())
			{
				using (DarkRift.Message msg = DarkRift.Message.Create(tag, writer))
					client.SendMessage(msg, SendMode.Unreliable);
			}
		}

		/// <summary>
		/// Extension shorthand for sending empty reliable messages.
		/// </summary>
		/// <param name="client">Client to which this should be sent.</param>
		/// <param name="tag"></param>
		public static void SendEmptyMessageReliable<TTag>(this DarkRiftClient client, TTag tag)
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
		public static void SendEmptyMessageUnreliable<TTag>(this DarkRiftClient client, TTag tag)
			where TTag : struct, Enum, IConvertible
		{
			using (DarkRiftWriter writer = DarkRiftWriter.Create())
			{
				using (DarkRift.Message msg = DarkRift.Message.Create(Convert.ToUInt16(tag), writer))
					client.SendMessage(msg, SendMode.Unreliable);
			}
		}
	}
}
