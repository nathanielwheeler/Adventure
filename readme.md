## Goals

I would like to refactor my text adventure game and add a web client interface.

### Home Screen

A box for entering commands.  Above it, a screen-sized window where old commands are logged.

### Server API

#### Message Schema
```cs
public class Message
{
	public string Body { get; set; }
	public string Color { get; set;}
	public IGame GameId { get; set;}
}
```

#### Endpoints
> baseUrl: `https://localhost:3000/api`
Get
`/messages/`: returns the most recent logged messages in the associated gameId.
Post
`/messages/`: runs the command and responds with new messages

## Requirements

#### Visualization:

#### Functionality:

## Stretch Goals

#### Command Tabs

In the home screen below or the side of the message log will be tabs for listing available actions, items, and exits.
Pressing the associated buttons will execute the appropriate command listed.

#### First-Time Visit Modal

When visiting website for the first time, users will see a modal that presents this message:
> Register a save account?
Below this, a form sheet for registration and then basic commands are listed.
> Click 'OK' or press a key to continue