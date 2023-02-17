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
            Console.Write("输入1来编辑牌组 2来更改牌组路径: ");
            port = int.Parse(Console.ReadLine());
            if (port == 1)
            {
                addpaizu();
            }
            else if(port == -2)
            {
                chpaizu();
            }
        }
        public static void addpaizu()
        {
            Console.Clear();
            string tmpapz;
            int wapz;
            common.initpai();
            Console.WriteLine("输入要创建的牌组文件名(会清空原来的牌组):");
            tmpapz = Console.ReadLine();
            StreamWriter st = new StreamWriter(tmpapz);
            common.maxadd = 1;
            while (common.maxadd <= 20)
            {
                Console.Clear();

                Console.WriteLine("输入要添加的单位编号，回车前请确认编号是否正确，输入0或者满20张退出");
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
                try
                {
                    wapz = int.Parse(Console.ReadLine());
                }
                catch
                {
                    continue;
                }
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
            Console.WriteLine("完成,请按任意键退出");
            Console.ReadKey();
        }
        public static void chpaizu()
        {
            string choses;
            Console.Clear();
            Console.WriteLine("这会清空你的原有牌组路径");
            Console.WriteLine("输入牌组路径: ");
            choses=Console.ReadLine();
            StreamWriter st = new StreamWriter("player.txt");
            st.WriteLine(choses);
            st.Close();
            Console.WriteLine("修改成功,请按任意键退出");
            Console.ReadKey();
        }
    }
}

