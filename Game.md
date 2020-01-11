# Welcome to Adventure!

### Story

### Gameplay

Adventure is a simple text based adventure game. You will need to know the following commands to play.

-	`go <direction>`
	- Moves your player from room to room.
	- Directions: `north`, `south`, `east`, `west`
- `take <item>`
	- If an item can be picked up this command will put the item in your inventory
- `use <item>`
	- Uses an item from your inventory or in the room
- `look`
	- Displays the Description of the current room
- `inventory`
	- This command will list of the current items in your inventory

### Rooms
```json
[
	"name": {
		"description": "",//string[]
		"events": {
			// eventId
		},
		"actions": {
			// actionId
		},
		"items": [
			// itemId
		],
		"exits": [
			// roomId
		]
	}
]
```

### Victory Conditions

### Cheat Guide