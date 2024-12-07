using OpenCvSharp;
using System.Net;
using System;
using System.Net.Sockets;
using System.IO;
using System.Data.SqlTypes;
using System.ComponentModel;


namespace Protocols
{
    public class Video_capture_server
    {
        private readonly NetworkStream _stream;
        public Video_capture_server(NetworkStream stream)
        {
            _stream = stream;
        }
        public void start_capture()
        {
            using var capture = new VideoCapture(0);

            // check if cam is accessed
            if (!capture.IsOpened())
            {
                Console.WriteLine("error opening cam");
                return;
            }

            capture.FrameWidth = 640;
            capture.FrameHeight = 480;

            // create a window
            // using var window = new Window("video capture");

            while (true)
            {
                try
                {
                    using var frame = new Mat();
                    capture.Read(frame);

                    // check for empty frame
                    if (frame.Empty())
                    {
                        Console.WriteLine("empty frame");
                        return;
                    }

                    // store currently read frames in comperssed img format in byte[]
                    byte[] imageBytes;
                    Cv2.ImEncode(".jpg", frame, out imageBytes);

                    // send info such as the size and the image itself
                    byte[] sizeOfImage = BitConverter.GetBytes(imageBytes.Length);
                    _stream.Write(sizeOfImage, 0, sizeOfImage.Length);
                    _stream.Write(imageBytes, 0, imageBytes.Length);

                    // client side code    
                    // window.ShowImage(frame);

                    // if(Cv2.WaitKey(1)==27){
                    //     break;
                    // }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("server error" + ex.Message);
                    break;
                }

            }
        }
    }
}