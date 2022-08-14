using pil;
using System;
using System.Net;
using System.Net.Sockets;

namespace pilgrims_sever
{
    public class pil_sever
    {
        public static byte[] but1 = new byte[20000];
        public static void Main()
        {

            int port;
            string host = "127.0.0.1";
            //Console.Write("输入监听端口: ");

            //port = int.Parse(Console.ReadLine());
            //调试代码区
            port = 13579;
            IPAddress ip = IPAddress.Parse(host);
            IPEndPoint ipe = new IPEndPoint(ip, port);
            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);//创建一个Socket类
            s.Bind(ipe);
            s.Listen(10);//开始监听
            Console.WriteLine("Waiting for connect.");
            Socket[] Ssocket = new Socket[2];
            Ssocket[0] = s.Accept();
            Ssocket[1] = s.Accept();
            Console.WriteLine("the socket has gotten a connect.");
            Random rd = new Random();
            //common.t_fir = rd.Next(0, 1);
            common.t_fir = 0;
            //调试代码,操作一下这个随机玩意防止太非
            byte[] buf = new byte[1024];
            buf[0] = (byte)(common.t_fir & 1);
            Ssocket[0].Send(buf);
            buf[0] = (byte)(buf[0] ^ 1);
            Ssocket[1].Send(buf);
            Console.WriteLine("the orders are sent.");
            Array.Clear(buf, 0, buf.Length);
            Ssocket[0].Receive(buf);
            Ssocket[1].Send(buf);
            Array.Clear(buf, 0, buf.Length);
            Ssocket[1].Receive(buf);
            Ssocket[0].Send(buf);
            int now = common.t_fir;
            while (true)
            {
                Array.Clear(common.get_b,0,common.get_b.Length);
                byte[] bb = new byte[1024];
                byte[] tmpb = new byte[1024];
                Ssocket[now].Receive(bb);
                Ssocket[now ^ 1].Send(bb);
                //Ssocket[now ^ 1].Receive(tmpb);
                //Ssocket[now].Send(tmpb);
                Ssocket[now].Receive(common.get_b);
                Ssocket[now ^ 1].Send(common.get_b);
                Console.WriteLine("Receive and Send successfully.");
                if (common.get_b[1] == 1)
                {
                    Console.WriteLine("Changed the turn.");
                    now ^= 1;
                }
            }
        }
    }
}

