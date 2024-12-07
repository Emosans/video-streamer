using OpenCvSharp;
using System;
using System.IO;
using System.Net.Sockets;

namespace Protocols
{
    public class Video_capture_client
    {
        private readonly NetworkStream _stream;

        public Video_capture_client(NetworkStream stream)
        {
            _stream = stream;
        }

        public void show_captures()
        {
            var window = new Window("Video Stream");

            try
            {
                while (true)
                {
                    byte[] imageSizeBuffer = new byte[4];
                    int bytesRead = _stream.Read(imageSizeBuffer, 0, imageSizeBuffer.Length);

                    if (bytesRead == 0) break;
                    if (bytesRead != 4) throw new IOException("Incomplete size data received.");

                    int imageSize = BitConverter.ToInt32(imageSizeBuffer, 0);

                    byte[] imageData = new byte[imageSize];
                    int totalRead = 0;
                    while (totalRead < imageSize)
                    {
                        bytesRead = _stream.Read(imageData, totalRead, imageSize - totalRead);
                        if (bytesRead == 0) throw new IOException("Incomplete image data received.");
                        totalRead += bytesRead;
                    }

                    using var mat = Cv2.ImDecode(imageData, ImreadModes.Color);
                    window.ShowImage(mat);

                    if (Cv2.WaitKey(1) == 27)
                    {
                        break;
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine("Stream Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Client Error: " + ex.Message);
            }
            finally
            {
                window.Close();
                _stream.Close();
            }
        }
    }
}
