# TCP Video Streaming Application

This project demonstrates basic TCP communication between a server and a client for real-time video streaming. It uses **C#** for both the TCP server and client, with video capture and processing powered by **OpenCvSharp**.

## Features

- **TCP Server**:
  - Binds to a specified host and port.
  - Captures video frames from the host's webcam using OpenCvSharp.
  - Compresses and encodes video frames into `.jpg` format.
  - Streams the encoded frames over a TCP connection.

- **TCP Client**:
  - Connects to the TCP server using the host and port.
  - Receives and decodes the compressed video frames.
  - Displays the decoded frames in real-time within a GUI window.

## Requirements

### For Server and Client
- **.NET Core SDK**
- **OpenCvSharp** (installed via NuGet)

### Optional
- Compatible IDEs such as Visual Studio or Visual Studio Code.

## How It Works

1. The **TCP Server** opens a connection on the specified host and port, captures video frames using the webcam, compresses them to `.jpg`, and sends the frames to connected clients over TCP.
2. The **TCP Client** establishes a connection to the server, receives the frames, decodes them, and displays the video stream in real-time.

## Usage

### Running the Server
1. Open the `Program.cs` file in your IDE.
2. Set the desired host and port in the server configuration.
3. Run the server application. It will start streaming video frames.

### Running the Client
1. Open the `Program.cs` file in your IDE.
2. Set the server's IP address and port in the client configuration.
3. Run the client application to connect to the server and view the video stream.

---

**Happy coding!** 🎥🚀
