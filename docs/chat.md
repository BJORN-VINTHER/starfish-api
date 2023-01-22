# Chat
A simple chat where you text other people of the room.

# Requirements
* any number of players allowed
* players can come and go as they like
* you should be able to see people connecting and disconnecting
* it should not support rich text
* it should support gifs
* each message should contain a timestamp, message text and player who made it
* players joining late should not be able to see prior messages

# Design

## client -> server messages

* Connect: `/chat/{activityCode}?playerId={pid}`
* Disconnect `/chat/{activityCode}?playerId={pid}`
* Send message `SendMessage`
    ``` json
    {
        "message": ""
    }
    ```
* Send image `SendImage`
    ``` json
    {
        "imageUrl": ""
    }
    ```


## server -> client messages
* Send message `MessageRecieved`
    ``` json
    {
        "message": "sample message",
        "timestamp": "2012-04-23T18:25:43.511Z"
    }
    ```
* Send image `ImageReceived`
    ``` json
    {
        "imageUrl": "https://giphy.com/clips/minecraft-microsoft-builder-minecraft-QxO6JEGaf3oTFDqqZJ",
        "timestamp": "2012-04-23T18:25:43.511Z"
    }
    ```
* Send message `PlayerJoined`
    ``` json
    {
        "player": {
            "id": 5,
            "name": "Mr. Ryan",
            "color": "#AA5511"
        },
        "timestamp": "2012-04-23T18:25:43.511Z"
    }
    ```
* Send message `PlayerLeft`
    ``` json
    {
        "player": {
            "id": 5,
            "name": "Mr. Ryan",
            "color": "#AA5511"
        },
        "timestamp": "2012-04-23T18:25:43.511Z"
    }
    ```