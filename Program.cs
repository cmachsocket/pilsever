using pil;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace pilgrims_sever
{
    public class pil_sever
    {
        public static void Main()
        {

            int port;//端口
            string host = "127.0.0.1";//主机
            Console.Write("输入监听端口 或者输入-1来编辑牌组 -2来更改牌组路径: ");
            port = int.Parse(Console.ReadLine());
            if (port > 0)
            {
                sever(host, port);
            }
            else if (port == -1)
            {
                addpaizu();
            }
            else if(port == -2)
            {
                chpaizu();
            }
        }
        public static void sever(string host, int port)
        {
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
            common.t_fir = rd.Next(0, 2);
            //common.t_fir = 0;
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
            Ssocket[0].Send(buf);//传递名称
            int now = common.t_fir;//访问第一个回合的人
            while (true)
            {
                Array.Clear(common.get_b, 0, common.get_b.Length);
                byte[] bb = new byte[1024];
                byte[] tmpb = new byte[1024];
                Ssocket[now].Receive(bb);
                Ssocket[now ^ 1].Send(bb);
                Ssocket[now].Receive(common.get_b);
                Ssocket[now ^ 1].Send(common.get_b);
                Console.WriteLine("Receive and Send successfully.");
                if (common.get_b[13]==0 || common.get_b[17] == 0)
                {
                    Console.WriteLine("get the hp is 0");
                }
                if (common.get_b[1] == 1)
                {
                    Console.WriteLine("Changed the turn.");
                    now ^= 1;
                }
            }
        }
        public static void addpaizu()
        {
            Console.Clear();
            string tmpapz;
            int wapz;
            common.initpai();
            Console.WriteLine("输入要创建的牌组文件名(会清空原来的牌组 输入请带上后缀):\n");
            tmpapz = Console.ReadLine();
            StreamWriter st = new StreamWriter(tmpapz);
            common.maxadd = 0;
            while (common.maxadd <= 20)
            {
                Console.Clear();

                Console.WriteLine("输入要添加的单位编号，回车前请确认编号是否正确，输入0或者满20张退出\n");
                for (int i = 1; i <= common.inxbk; i++)
                {
                    if (common.xbapz[i] == 0 && common.xblist[i].bian > 0)
                    {
                        Console.WriteLine(common.xblist[i].bian + "." + common.xblist[i].name);
                    }
                }
                for (int i = 1; i <= common.infsk; i++)
                {
                    if (common.fsapz[i] == 0 && common.fslist[i].bian > 0)
                    {
                        Console.WriteLine(common.fslist[i].bian + "." + common.fslist[i].name);
                    }
                }
                for (int i = 1; i <= common.inwqk; i++)
                {
                    if (common.wqapz[i] == 0 && common.wqlist[i].bian > 0)
                    {
                        Console.WriteLine(common.wqlist[i].bian + "." + common.wqlist[i].name);
                    }
                }
                wapz = int.Parse(Console.ReadLine());
                if (wapz == 0)
                {
                    break;
                }
                st.WriteLine(wapz.ToString());
                if (wapz < 1000)
                {
                    common.xbapz[wapz] = 1;
                }
                if (wapz >= 1000 && wapz< 2000) {
                    common.fsapz[wapz - 1000] = 1;
                }
                if (wapz >= 2000)
                {
                    common.wqapz[wapz - 2000] = 1;
                }
                common.maxadd++;
            }
            st.Close();
            Console.WriteLine("完成");
            Console.ReadKey();
        }
        public static void chpaizu()
        {
            string choses;
            Console.Clear();
            Console.WriteLine("这会清空你的原有牌组路径");
            Console.WriteLine("输入牌组路径(并带上后缀): ");
            choses=Console.ReadLine();
            StreamWriter st = new StreamWriter("player.txt");
            st.WriteLine(choses);
            st.Close();
            Console.WriteLine("修改成功");
            Console.ReadKey();
        }
    }
}

