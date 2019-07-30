# DarkRift2 Extension
A collection of handy DR2 Extension methods & a bit more!

## What's cool about it

Using hoops & loops in DR2 to send messages can quickly become repeptetive and hard to maintain as your project grows.
This collection of extension methods is meant to eliminate all the boilerplate code, giving you one-liner shorthands to all your server-client communication needs - with a cherry on top.

DR2 by default uses `ushort` as it's Tags type, which can often be hard to work around if you're new or if your project gets big enough, as such, this collection also attempts to solve this problem by extending the `IDarkRiftSerializable` interface & wrapping everything in neatly organized Enums.

## Quick Start

#### Standalone DR2 server
1. Simply clone & reference the project or binaries in your Standalone DR2 server project and reference DR2 dlls to it.
2. Reference the latest binaries in your project.

#### Unity Client/Server
Drag & Drop the built files in your assets folder, provided DR2 dlls are already there.

## How it works

It works in a simple matter, you create a message type that inherits from `IMessage<FooTag>`, with `FooTag` being an enum.
`FooTag` would have to be of type `ushort`, as that is how all DR2 tags are handled internally.

### Code Example

We start by creating our Tags Enum.

```csharp
public enum FooServerMessageTag : ushort
{
    SendMessage = 0,
    MoveUnit,
    PickUpWeapon
}
```

Which we can then proceed to use in our new message class
```csharp
public class SendMessage : IDarkRiftMessage<FooServerMessageTag>
{
  public FooServerMessageTag Tag => FooServerMessageTag.AuthRequest;

  public string Message = "Hello DR2!";

  public SendMessage(string message)
  {
    this.Message = message;
  }

  public SendMessage()
  {
  }

  public void Deserialize(DeserializeEvent e)
  {
    this.Message = e.Reader.ReadString();
  }

  public void Serialize(SerializeEvent e)
  {
    e.Writer.Write(this.Message);
  }
}
```

Once we've got our data neatly lined up, all we need to do to send it is

`client.SendTcpMessage(new SendMessage(message));`, given that client is one of DR2's supported client types.

For more info, refer to the wiki. (WIP)

## About DarkRift2

[DarkRift2](https://darkriftnetworking.com/DarkRift2/) is an amazing C# networking library created by [Jamie](https://github.com/JamJar00).
