using System;
using System.Net.Sockets;
using System.Threading;
using OpenCvSharp;

namespace Protocols
{
    public class Video_capture_client
    {
        private readonly NetworkStream _stream;
        private readonly Thread _receiveThread;

        public Video_capture_client(NetworkStream stream)
        {
            _stream = stream;
            _receiveThread = new Thread(ReceiveFrames);
        }

        public void show_captures()
        {
            _receiveThread.Start();
            _receiveThread.Join();
        }

        private void ReceiveFrames()
        {
            using var window = new Window("Client Video");
            while (true)
            {
                try
                {
                    byte[] sizeBuffer = new byte[4];
                    _stream.Read(sizeBuffer, 0, sizeBuffer.Length);
                    int frameSize = BitConverter.ToInt32(sizeBuffer);

                    byte[] frameBuffer = new byte[frameSize];
                    int bytesRead = 0;

                    while (bytesRead < frameSize)
                    {
                        bytesRead += _stream.Read(frameBuffer, bytesRead, frameSize - bytesRead);
                    }

                    using Mat frame = Cv2.ImDecode(frameBuffer, ImreadModes.Color);
                    window.ShowImage(frame);

                    if (Cv2.WaitKey(1) == 27)
                        break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Client encountered an error: {ex.Message}");
                    break;
                }
            }
        }
    }
}
