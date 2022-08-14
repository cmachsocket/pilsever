namespace pil
{
    static class common
    {
        public const int MAXPLAY = 2;
        public const int MAXX = 10000;
        public const int MAXS = 20000;
        public const int MAXTMP = 21;
        public const int MAXC = 1024;
        public const int MAXIP = 21;
        public const int MAXP = 5;
        public const int MAXN = 11;
        public const string BAN = "3.1.0.20220131";//版本号
        public delegate void pfux(int a, int b, int c);//士员 上阵/怒气/怨念函数  武器使用/法术函数
        public static int inxbk = 26;//士员数量 
        public static int pu_inxbk = 26;//基础士员数量
        public static int infsk = 6;//法术数量 
        public static int inwqk = 2;//武器数量 
        public static wuqi NULLW = new wuqi();
        //空武器 
        public static fashu NULLF = new fashu();
        public static xiaobin NULLB = new xiaobin();
        public static xiaobin[,,] bing = new xiaobin[MAXPLAY, MAXP, MAXN];
        //		空士员        场地
        public static wuqi[] pwuqi = new wuqi[MAXPLAY] { new wuqi(), new wuqi() };
        //双方武器槽 
        public static int[,,] vis = new int[MAXPLAY, MAXP, MAXN];
        //是否有士员在此处 
        public static int[,] k = new int[MAXPLAY, MAXP];
        //每排的士员数量
        public static int[] kqian = new int[MAXPLAY], dead = new int[MAXX];
        //每排的士员数量		                       前锋数量 				
        public static int deadk = 0;
        //死者编号  死者人数 
        public static string[] p = new string[MAXPLAY], ppai = new string[MAXPLAY];
        //		                        玩家名称              牌组文件路径
        public static string tmpapz = "\0", sendtext, fatext, prtext = "";
        //创建牌组名                         回传zhu    发送text  打印text
        public static int[] pxue = new int[MAXPLAY] { 20, 20 }, ndian = new int[MAXPLAY] { 15, 15 };
        //  玩家血量											    玩家点数 
        public static int[,] paip = new int[MAXPLAY, MAXIP];
        //玩家队伍
        public static int huihes, mode, tmpbuy, tmpche, tmpb, tmpc, maxadd, t_fir;
        //				回合数    操作	购买		购买什么 输入模式	 最大添加数量 是否为第一回合
        public static int bban = 0;
        // 是否已添加士员/法术/武器
        public static int[] sxb = new int[MAXPLAY], usefa = new int[MAXPLAY], usewu = new int[MAXPLAY], xbapz = new int[MAXX], fsapz = new int[MAXX], wqapz = new int[MAXX];
        //当前回合玩家 是否首脑死亡     是否使用技能         是否使用武器
        public static xiaobin[] xblist = new xiaobin[MAXX]; //初始士员列表 
        public static fashu[] fslist = new fashu[MAXX];//初始法术列表 
        public static wuqi[] wqlist = new wuqi[MAXX];//初始武器列表
        public static pfux bback;//按钮事件返回
        public static abc clilin = new abc(0, 0, 0);//点击临时储存
        public static byte[] get_b = new byte[MAXS];//套接字字节流
        public static int blong, ilong;//缓冲流长度

        public static int[] I1 = new int[] { 0, 5, 5, 0, 5, -5, 3, 4, 10, 5, 5, 2, 0, 10, 10, 5, 0, 10, 10, 5, 5, 0, 0, 5, 1, 5, 5 };//gongji 攻击
        public static int[] I2 = new int[] { 0, 5, 5, 0, 5, 0, 0, 4, 10, 5, 5, 2, 0, 10, 10, 5, 0, 0, 10, 5, 5, 10, 2, 5, 1, 5, 5 };//fanci 反刺
        public static int[] I3 = new int[] { 0, 10, 5, 15, 2, 3, 3, 20, 5, 15, 7, 3, 10, 5, 5, 7, 10, 10, 5, 5, 5, 10, 12, 10, 6, 5, 10 };//xue 血量
        public static int[] I4 = new int[] { 0, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 3, 0, 1, 1, 1, 0, 2, 1, 1, 5, 0, 0, 0, 1, 1, 1 };//gjcishu 攻击次数
        public static int[] I5 = new int[] { 0, 1, 2, 1, 1, 3, 3, 1, 1, 1, 1, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };//shecheng 射程
        public static int[] I6 = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };//dun 盾
        public static int[] I7 = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 1, 0, 0, 0, 0, 0, 1, 0, 0 };//lingjcs 临时攻击次数
        public static int[] I8 = new int[] { 0, 5, 5, 5, 2, 5, 5, 20, 10, 15, 5, 5, 5, 10, 10, 5, 5, 10, 7, 5, 5, 5, 5, 15, 0, 10, 10 };//dianshu 点数
        public static int[] I9 = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };//xixue 吸血
        public static int[] I10 = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };//boolpojia 是否破甲
        public static int[] I11 = new int[] { 0, 1, 2, 1, 1, 3, 3, 1, 1, 1, 1, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 1 };//paishu 排数
        public static int[] I12 = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0 };//qianfeng 是否前锋
        public static int[] I13 = new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };//boolji 是否攻击
        public static int[] I14 = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };//bihu 是否庇护
        public static int[] I15 = new int[] { 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };//dianji 是否电击
        public static int[] I16 = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, -20, 21, 22, 23, 24, 25, 26 };//bian 编号
        public static int[] I17 = new int[] { 0, 10, 5, 15, 2, 3, 3, 20, 5, 15, 8, 3, 10, 5, 5, 7, 10, 10, 5, 5, 5, 10, 12, 10, 6, 5, 10 };//maxxue 最大血量
        public static int[] FDI = new int[] { 0, 5, 1, 0, 5, 3, 0, 5 };//法术点数
        public static int[] FBI = new int[] { 0, 1001, 1002, 1003, 1004, 1005, 1006 };//法术编号
        public static int[] WDI = new int[] { 0, 5, 5 };//武器点数
        public static int[] WBI = new int[] { 0, 2001, 2002 };//武器编号
        public static int[] NAI = new int[] { 0, 2, 2 };   //武器耐久
        public static string[] NAME = new string[] { "", "卫兵", "猎手", "重甲", "爆兵", "仁心", "火击", "炼狱", "英灵", "安德拉", "坚石", "忍", "缄默", "执剑人", "狡", "利矛", "清心", "叛军", "破阵", "彼岸", "双生", "禅", "断罪", "诙谐", "突击兵", "亡灵法师", "血月" };
        public static string[] HNAME = new string[] { "", "木头", "陈醋", "破损老搞", "BUG精灵", "草草", "肚纸", "地狱木头", "英灵", "吸血鬼", "前锋假豪", "BUG终结者", "重甲破损搞", "细菌", "反木头", "笑天犬", "刘动", "叛军", "破阵", "22", "33", "反抗木头", "破锋反搞", "诙谐", "突击兵", "灵魂召唤师", "血月" };
        //士员名称 
        public static string[] FNA = new string[] { "", "暗杀", "惊扰", "禁忌术", "风暴", "焕发", "背刺" };
        public static string[] HFNA = new string[] { "", "火球术", "惊扰", "死亡黎明", "风暴", "焕发", "自残" };
        //法术名称 
        public static string[] WNA = new string[] { "", "y12激光步枪", "急救剂" };
        public static string[] HWNA = new string[] { "", "战争拳套", "急救剂" };
        //武器名称 
        public static pfux[] FA = new pfux[] { null, fa1, fa2, fa3, fa4, fa5, fa6 };
        //法术集合 
        public static pfux[] WU = new pfux[] { tmpwu, wu1, wu2 };
        //武器集合 
        public static pfux[] F1 = new pfux[] { null, tmpyuan, tmpyuan, tmpyuan, tmpyuan, tmpyuan, tmpyuan, tmpyuan, tmpyuan, tmpyuan, tmpyuan, tmpyuan, tmpyuan, yuan13, tmpyuan, tmpyuan, tmpyuan, yuan17, tmpyuan, yuan19, tmpyuan, tmpyuan, tmpyuan, tmpyuan, tmpyuan, tmpyuan, tmpyuan };//yuannian
                                                                                                                                                                                                                                                                                             //怨念法术集合 
        public static pfux[] F2 = new pfux[] { null, tmpji, tmpji, tmpji, tmpji, tmpji, tmpji, tmpji, tmpji, tmpji, tmpji, tmpji, tmpji, tmpji, tmpji, tmpji, ji16, tmpji, tmpji, tmpji, tmpji, tmpji, tmpji, ji23, ji24, ji25, tmpji }; //jineng
                                                                                                                                                                                                                                         //上阵函数集合 
        public static pfux[] F3 = new pfux[] { null, tmphui, tmphui, tmphui, tmphui, tmphui, tmphui, hui7, tmphui, tmphui, tmphui, tmphui, hui12, tmphui, tmphui, tmphui, tmphui, tmphui, tmphui, tmphui, tmphui, tmphui, tmphui, tmphui, tmphui, tmphui, hui26 };//huihe
                                                                                                                                                                                                                                                                  //怒气函数集合 

        public static int gongji(int a, int b, int c, int aa, int bb, int cc)
        {//攻击函数 
            if (bing[aa, bb, cc].bihu != 0)
            {//庇护情况 
                bing[aa, bb, cc].bihu = 0;
                bing[a, b, c].lingjcs--;
                if (bing[a, b, c].dianji == 0) fanci(a, b, c, aa, bb, cc);
                return 1;
            }
            bing[a, b, c].xue += bing[a, b, c].xixue;//吸血情况 
            if (bing[a, b, c].xue > bing[a, b, c].maxxue) bing[a, b, c].xue = bing[a, b, c].maxxue;
            if (bing[a, b, c].boolpojia == 0 && bing[aa, bb, cc].dun > 0)
            {//护盾情况 
                bing[aa, bb, cc].dun -= bing[a, b, c].gongji;
            }
            else
            {
                bing[aa, bb, cc].xue -= bing[a, b, c].gongji;
            }
            bing[a, b, c].lingjcs--;
            if (bing[a, b, c].dianji == 0) fanci(a, b, c, aa, bb, cc);//电击情况 
            else isdie(aa, bb, cc);
            if (bing[a, b, c].xue > bing[a, b, c].maxxue) bing[a, b, c].xue = bing[a, b, c].maxxue;
            if (bing[aa, bb, cc].xue > bing[aa, bb, cc].maxxue) bing[aa, bb, cc].xue = bing[aa, bb, cc].maxxue;
            fatext += bing[a, b, c].name + "攻击了" + bing[aa, bb, cc].name + "\n";
            return 1;
        }
        public static void fanci(int a, int b, int c, int aa, int bb, int cc)
        {//反刺函数 
            int she = 0;
            for (int i = 1; i <= b; i++)
            {
                if (vis[a, i, c] != 0) she++;
            }
            if (bing[aa, bb, cc].shecheng < she)
            {
                isdie(a, b, c);
                isdie(aa, bb, cc);
                return;
            }
            if (bing[a, b, c].bihu != 0)
            {
                bing[a, b, c].bihu = 0;
                isdie(a, b, c);
                isdie(aa, bb, cc);
                return;
            }
            if (bing[aa, bb, cc].boolpojia == 0 && bing[a, b, c].dun > 0)
            {
                bing[a, b, c].dun -= bing[aa, bb, cc].fanci;
            }
            else
            {
                bing[a, b, c].xue -= bing[aa, bb, cc].fanci;
            }
            isdie(a, b, c);
            isdie(aa, bb, cc);
            return;
        }
        public static void isdie(int a, int b, int c)
        {//判定死亡 
            if (bing[a, b, c].xue > 0)
            {//有血返回 
                return;
            }
            if (F1[bing[a, b, c].yuan] != tmpyuan)
            {
                fatext += bing[a, b, c].name + "释放了怨念\n";
            }

            bing[a, b, c].yuannian();//释放怨念 

            fatext += bing[a, b, c].name + "死亡" + "\n";
            dead[++deadk] = bing[a, b, c].bian;
            if (bing[a, b, c].qianfeng != 0)
            {
                kqian[a]--;
            }
            bing[a, b, c] = NULLB.copy();
            vis[a, b, c] = 0;
            for (int i = c + 1; i <= k[a, b]; i++)
            {//存者向左移动 
                if (vis[a, b, i] != 0)
                {
                    bing[a, b, i - 1] = bing[a, b, i].copy();
                    vis[a, b, i - 1] = 1;
                    bing[a, b, i - 1].c = i - 1;
                    bing[a, b, i] = NULLB.copy();
                    vis[a, b, i] = 0;
                }
            }
            k[a, b]--;
            return;
        }
        public static void isbreak(int pl)
        {
            if (pwuqi[pl].naiju > 0)
            {
                return;
            }
            pwuqi[pl] = NULLW.copy();
            return;
        }
        public static abc addxb(int bought, int pl)
        {//增加士员 
            bing[pl, xblist[bought].paishu, ++k[pl, xblist[bought].paishu]] = xblist[bought].copy();//赋值上场 
            vis[pl, xblist[bought].paishu, k[pl, xblist[bought].paishu]] = 1; //确认有士员才此 
            if (xblist[bought].qianfeng != 0) kqian[pl]++;//前锋士员总数增加 
            bing[pl, xblist[bought].paishu, k[pl, xblist[bought].paishu]].a = pl;
            bing[pl, xblist[bought].paishu, k[pl, xblist[bought].paishu]].b = xblist[bought].paishu;
            bing[pl, xblist[bought].paishu, k[pl, xblist[bought].paishu]].c = k[pl, xblist[bought].paishu];
            //记录下a b c 
            bing[pl, xblist[bought].paishu, k[pl, xblist[bought].paishu]].jineng();//释放上阵技能 
            if (F1[bing[pl, xblist[bought].paishu, k[pl, xblist[bought].paishu]].ji] != tmpji)
            {
                fatext += bing[pl, xblist[bought].paishu, k[pl, xblist[bought].paishu]].name + "使用了上阵\n";
            }
            abc tmp = new abc(pl, xblist[bought].paishu, k[pl, xblist[bought].paishu]);
            return tmp;
        }
        public static void addfs(int bought, int pl)
        {
            bought -= 1000;
            ndian[pl] -= fslist[bought].dianshu;
            usefa[pl] = 1;
            fslist[bought].use();
            fatext += "购买并使用了" + fslist[bought].name + "\n";
            //do something
        }
        public static void addwq(int bought, int pl)
        {
            bought -= 2000;
            ndian[pl] -= wqlist[bought].dianshu;
            pwuqi[pl] = wqlist[bought].copy();
            fatext += "购买了" + wqlist[bought].name + "\n";
        }
        public static void useji()
        {
            for (int i = 1; i <= MAXP - 1; i++)
            {
                for (int j = 1; j <= k[0, i]; j++)
                {
                    if (vis[1, i, j] != 0)
                    {
                        bing[1, i, j].huihe();
                        bing[1, i, j].lingjcs = bing[0, i, j].gjcishu;
                        if (F3[bing[1, i, j].hui] != tmphui) fatext += bing[1, i, j].name + "使用了怒气\n";
                    }
                }
            }
            return;
        }


        public static void tmpfa(int a, int b, int c)
        {
            //空法术
            return;
        }
        public static void tmpwu(int a, int b, int c)
        {
            //空武器
            return;
        }
        public static void tmpyuan(int a, int b, int c)
        {//普通怨念函数 
            return;
        }
        public static void tmpji(int a, int b, int c)
        {//普通上阵函数 
            return;
        }
        public static void tmphui(int a, int b, int c)
        {//普通怒气函数 
            return;
        }
        public static void hui7(int a, int b, int c)
        {//7士员怒气函数 
            if (bing[a, b, c].tmp[1] == 0)
            {
                bing[a, b, c].tmp[1] = 1;
                return;
            }
            bing[a, b, c].gongji += 4;
            bing[a, b, c].fanci += 4;
            return;
        }
        public static void hui12(int a, int b, int c)
        {//12士员怒气函数 
            usefa[a ^ 1] = 1;
            return;
        }
        public static void yuan13(int a, int b, int c)
        {//13士员怨念函数 
            if (bing[a ^ 1, 3, 1].xue > 0)
            {
                bing[a ^ 1, 3, 1].xue = 0;
                isdie(a ^ 1, 3, 1);
            }
        }
        public static void ji16(int a, int b, int c)
        {//16士员上阵函数 
            abc tmp = new abc(a, b, c);
            if (clilin.a == 0 && clilin.b == 0 && clilin.c == 0)
            {
                setmode(3, ji16, "选择被增加攻击的士员");
                clilin.a = 1;
                return;
            }
            if (bing[tmp.a, tmp.b, tmp.c].xue <= 0)
            {
                prtext = "受击者为空或者血量不足";
                return;
            }
            bing[tmp.a, tmp.b, tmp.c].gongji += 5;
            bing[tmp.a, tmp.b, tmp.c].fanci += 5;
            clean(xblist[16].name + "上阵技能使用完毕");
            return;
        }
        public static void yuan17(int a, int b, int c)
        {//17士员怨念函数 
            pxue[a] -= 3;
            if (pxue[a] <= 0) sxb[a] = 1;
        }
        public static void yuan19(int a, int b, int c)
        {//19士员怨念函数 
            addxb(20, a);
            return;
        }
        public static void ji23(int a, int b, int c)
        {//23士员上阵函数 
            abc tmp = new abc(a, b, c);
            if (tmp.a == 0 && tmp.b == 0 && tmp.c == 0)
            {
                setmode(3, ji23, "点击第一排:与左边血量及上限相等\n第二排:与左边攻击及反刺相等");
                return;
            }
            if (tmp.b == 1)
            {
                bing[a, b, c].xue = bing[a, b, c - 1].xue;
                bing[a, b, c].maxxue = bing[a, b, c - 1].maxxue;
            }
            else if (tmp.b == 2)
            {
                bing[a, b, c].gongji = bing[a, b, c - 1].gongji;
                bing[a, b, c].fanci = bing[a, b, c - 1].fanci;
            }
            else
            {
                prtext = "错误的选择";
                return;
            }
        }
        public static void ji24(int a, int b, int c)
        {//24士员上阵函数
            ndian[a] -= 1;
        }
        public static void ji25(int a, int b, int c)
        {//25士员上阵函数
            if (deadk <= 0) return;
            abc tmp = addxb(dead[deadk], a);
            bing[tmp.a, tmp.b, tmp.c].xue = 1;
            deadk--;
        }
        public static void hui26(int a, int b, int c)
        {//26士员怒气函数
            if (bing[a, b, c].xue <= 5)
            {
                bing[a, b, c].gongji = 15;
            }
        }
        public static void fa1(int a, int b, int c)
        {//1001法术使用函数 
            abc tmp = new abc(a, b, c);
            if (tmp.a == 0 && tmp.b == 0 && tmp.c == 0)
            {
                setmode(3, fa1, "选择被攻击的一排士员");
                return;
            }
            if (tmp.b > 2)
            {
                prtext = "被攻击士员大于了2排";
                return;
            }
            if (bing[tmp.a, tmp.b, tmp.c].xue <= 0)
            {
                prtext = "受击者为空或者血量不足";
                return;
            }
            if (bing[tmp.a, tmp.b, tmp.c].bihu != 0)
            {
                bing[tmp.a, tmp.b, tmp.c].bihu = 0;
                clean(fslist[1].name + "使用完毕");
                return;
            }
            if (bing[tmp.a, tmp.b, tmp.c].dun > 0)
            {
                bing[tmp.a, tmp.b, tmp.c].dun -= 5;
            }
            else
            {
                bing[tmp.a, tmp.b, tmp.c].xue -= 5;
                isdie(tmp.a, tmp.b, tmp.c);
            }
            clean(fslist[1].name + "使用完毕");
            return;
        }
        public static void fa2(int a, int b, int c)
        {//1002法术使用函数 
            abc tmp = new abc(a, b, c);
            if (tmp.a == 0 && tmp.b == 0 && tmp.c == 0)
            {
                setmode(3, fa2, "选择被攻击的一排士员");
                return;
            }
            if (tmp.b > 2)
            {
                prtext = "被攻击士员大于了2排";
                return;
            }
            if (bing[tmp.a, tmp.b, tmp.c].xue <= 0)
            {
                prtext = "受击者为空或者血量不足";
                return;
            }
            if (bing[tmp.a, tmp.b, tmp.c].bihu != 0)
            {
                bing[tmp.a, tmp.b, tmp.c].bihu = 0;
                clean(fslist[2].name + "使用完毕");
                return;
            }
            if (bing[tmp.a, tmp.b, tmp.c].dun > 0)
            {
                bing[tmp.a, tmp.b, tmp.c].dun -= 1;
            }
            else
            {
                bing[tmp.a, tmp.b, tmp.c].xue -= 1;
                isdie(tmp.a, tmp.b, tmp.c);
            }
            clean(fslist[2].name + "使用完毕");
            return;
        }
        public static void fa3(int a, int b, int c)
        {//1003法术使用函数 
            ndian[1] -= 30;
            for (int i = 1; i <= MAXP - 1; i++)
            {
                for (int j = 1; j <= k[0, i]; j++)
                {
                    if (vis[0, i, j] != 0)
                    {
                        bing[0, i, j].xue = -1000;
                        //isdie(0, i, j);
                    }
                }
            }
            for (int i = 1; i <= MAXP - 1; i++)
            {
                for (int j = 1; j <= k[1, i]; j++)
                {
                    if (vis[1, i, j] != 0)
                    {
                        bing[1, i, j].xue = -1000;
                        //isdie(1, i, j);
                    }
                }
            }
            for (int k = 0; k <= 1; k++)
            {
                for (int i = 1; i <= MAXP - 1; i++)
                {
                    for (int j = 1; j <= MAXN; j++)
                    {
                        if (vis[k, i, 1] != 0)
                        {
                            isdie(k, i, 1);
                        }
                    }
                }
            }

        }
        public static void fa4(int a, int b, int c)
        {//1004法术使用函数 
            for (int i = 1; i <= MAXP - 1; i++)
            {
                for (int j = k[0, i]; j >= 1; j--)
                {
                    if (vis[0, i, j] != 0)
                    {
                        bing[0, i, j].xue -= 1;
                        isdie(0, i, j);
                    }
                }
            }
            for (int i = 1; i <= MAXP - 1; i++)
            {
                for (int j = k[1, i]; j >= 1; j--)
                {
                    if (vis[1, i, j] != 0)
                    {
                        bing[1, i, j].xue -= 1;
                        isdie(1, i, j);
                    }
                }
            }
        }
        public static void fa5(int a, int b, int c)
        {//1005法术使用函数 
            abc tmp = new abc(a, b, c);
            if (tmp.a == 0 && tmp.b == 0 && tmp.c == 0)
            {
                setmode(3, fa5, "选择被增加射程的士员");
                return;
            }
            if (bing[tmp.a, tmp.b, tmp.c].xue <= 0)
            {
                prtext = "受击者为空或者血量不足";
                return;
            }
            bing[tmp.a, tmp.b, tmp.c].shecheng++;
            clean(fslist[5].name + "使用完毕");
            return;
        }
        public static void fa6(int a, int b, int c)
        {//1006法术使用函数
            abc tmp = new abc(a, b, c);
            if (tmp.a == 0 && tmp.b == 0 && tmp.c == 0)
            {
                setmode(3, fa6, "选择被增加射程的士员");
                return;
            }
            if (bing[tmp.a, tmp.b, tmp.c].xue <= 0)
            {
                prtext = "受击者为空或者血量不足";
                return;
            }
            if (tmp.a != 1)
            {
                prtext = "非己方士员";
            }

            bing[tmp.a, tmp.b, tmp.c].xue -= 1;
            usefa[1] = 0;
            isdie(tmp.a, tmp.b, tmp.c);
            clean(fslist[6].name + "使用完毕");
            return;
        }
        public static void wu1(int a, int b, int c)
        {//2001武器使用函数 
            abc tmp = new abc(a, b, c);
            if (tmp.a == 0 && tmp.b == 0 && tmp.c == 0)
            {
                setmode(3, wu1, "选择被攻击的一排士员");
                return;
            }
            if (tmp.b > 2)
            {
                prtext = "被攻击士员大于了2排";
                return;
            }
            if (bing[tmp.a, tmp.b, tmp.c].xue <= 0)
            {
                prtext = "受击者为空或者血量不足";
                return;
            }
            if (bing[tmp.a, tmp.b, tmp.c].bihu != 0)
            {
                bing[tmp.a, tmp.b, tmp.c].bihu = 0;
                clean(wqlist[1].name + "使用完毕");
                return;
            }
            if (bing[tmp.a, tmp.b, tmp.c].dun > 0)
            {
                bing[tmp.a, tmp.b, tmp.c].dun -= 5;
            }
            else
            {
                bing[tmp.a, tmp.b, tmp.c].xue -= 5;
                isdie(tmp.a, tmp.b, tmp.c);
            }
            clean(wqlist[1].name + "使用完毕");
            return;
        }
        public static void wu2(int a, int b, int c)
        {//2002武器使用函数 
            abc tmp = new abc(a, b, c);
            if (tmp.a == 0 && tmp.b == 0 && tmp.c == 0)
            {
                setmode(3, wu2, "选择被治疗的士员");
                return;
            }
            if (bing[tmp.a, tmp.b, tmp.c].xue <= 0)
            {
                prtext = "受击者为空或者血量不足";
                return;
            }
            bing[tmp.a, tmp.b, tmp.c].xue += 5;
            if (bing[tmp.a, tmp.b, tmp.c].xue > bing[tmp.a, tmp.b, tmp.c].maxxue) bing[tmp.a, tmp.b, tmp.c].xue = bing[tmp.a, tmp.b, tmp.c].maxxue;
            clean(wqlist[2].name + "使用完毕");
            return;
        }




        public static int wquse(int pl)
        {
            pwuqi[pl].use();
            pwuqi[pl].naiju--;
            usewu[pl] = 1;
            isbreak(pl);
            prtext = "使用了" + pwuqi[pl].name + "\n";
            return 1;
        }
        public static int gjshou(int a, int b, int c, int pl)
        {//能否攻击首脑
            pxue[pl] -= bing[a, b, c].gongji;
            bing[a, b, c].xue = 0;
            isdie(a, b, c);
            if (pxue[pl] <= 0) sxb[pl] = 1;
            return 1;
        }
        public static void gj1(int a, int b, int c)
        {
            if (clilin.a == 0 && clilin.b == 0 && clilin.c == 0)
            {
                if (a >= 0)
                {
                    if (a == 0)
                    {
                        prtext = "无法选择对方士员";
                        return;
                    }
                    if (bing[a, b, c].xue <= 0)
                    {
                        prtext = "攻击者为空或者血量不足";
                        return;
                    }
                    if (bing[a, b, c].lingjcs <= 0)
                    {
                        prtext = "已经攻击过了或者没有攻击次数";
                        return;
                    }
                    clilin.a = a; clilin.b = b; clilin.c = c;
                    sendtext = "选择被攻击的对象";
                }
                else if (a == -1 || a == -2)
                {
                    prtext = "无法选择首脑";
                    return;
                }
                else if (a == -3)
                {

                    if (pwuqi[1].naiju <= 0)
                    {
                        prtext = "未装备武器";
                        return;
                    }


                    if (usewu[1] == 1)
                    {
                        prtext = "本回合已经使用过武器";
                        return;
                    }
                    wquse(1);
                }
                else if (a == -4)
                {
                    prtext = "无法选择对方武器";
                    return;
                }
            }
            else
            {
                if (a >= 0)
                {
                    if (bing[a, b, c].xue <= 0)
                    {
                        prtext = "受攻击者为空或者血量不足";
                        return;
                    }
                    int she = 0;//实际排数
                    for (int i = 1; i <= b; i++)
                    {
                        if (vis[a, i, c] != 0) she++;
                    }
                    if (bing[clilin.a, clilin.b, clilin.c].shecheng < she)
                    {
                        prtext = "射程不够";
                        return;
                    }
                    gongji(clilin.a, clilin.b, clilin.c, a, b, c);
                    clean("攻击完毕");

                }
                else if (a == -1 || a == -2)
                {
                    int pl = a + 2;
                    for (int i = 1; i <= MAXP - 1; i++)
                    {
                        if (k[pl, i] > 0)
                        {
                            prtext = p[pl] + "仍有士员在场";
                        }
                    }
                    gjshou(clilin.a, clilin.b, clilin.c, pl);
                    clean("攻击完毕");
                    return;
                }
                else if (a == -3 || a == -4)
                {
                    prtext = "无法选择武器";
                    return;
                }
            }
        }
        public static void initpai()
        {//初始化购买列表 
            for (int i = 1; i <= inxbk + 5; i++)
            {
                xblist[i] = new xiaobin();
                fslist[i] = new fashu();
                wqlist[i] = new wuqi();
            }
            for (int i = 1; i <= inxbk; i++)
            {
                xblist[i].Xiaobin(NAME[i], I1[i], I2[i], I3[i], I4[i], I5[i], I6[i], I7[i], I8[i], I9[i], I10[i], I11[i], I12[i], I13[i], I14[i], I15[i], I16[i], I17[i], i, i, i);
            }
            for (int i = 1; i <= infsk; i++)
            {
                fslist[i].Fashu(FNA[i], FA[i], FDI[i], FBI[i]);
            }
            for (int i = 1; i <= inwqk; i++)
            {
                wqlist[i].Wuqi(WNA[i], i, WDI[i], NAI[i], WBI[i]);
            }
        }
        public static void clean(string s)
        {
            mode = 1;
            clilin.a = 0; clilin.b = 0; clilin.c = 0;
            bback = tmpji;
            sendtext = s;
        }

        public static void setmode(int mo, pfux fun, string s)
        {
            bback = fun;
            mode = mo;
            sendtext = s;
        }
        public static int itob(ref byte[] b, int[] ne, int len)
        {
            int l = 1;
            for (int i = 0; i <= len; i++)
            {
                b[l++] = (byte)(ne[i]);
                b[l++] = (byte)(ne[i] >> 8);
                b[l++] = (byte)(ne[i] >> 16);
                b[l++] = (byte)(ne[i] >> 24);
            }
            return l;

        }
        public static int btoi(ref int[] u, byte[] ne, int len)
        {
            int l = 1, i = 0;
            for (; l <= len; i++)
            {
                u[i] = (int)(ne[l++] | ne[l++] << 8 | ne[l++] << 16 | ne[l++] << 24);
            }
            return i;
        }
    }

    class xiaobin
    {//士员类 
        public int
            gongji,//攻击 
            fanci,//反刺 
            xue,//血量 
            gjcishu,//攻击次数 
            shecheng,//射程 
            dun,//护盾 
            lingjcs,//临时攻击次数 
            dianshu,//点数 
            xixue,//吸血 
            boolpojia,//破甲 
            paishu,//排数 
            qianfeng,//前锋 
            boolji,//沉默 
            bihu,//庇护 
            dianji,//电击 
            bian,//编号 
            a,
            b,
            c,
            maxxue,
            yuan,
            ji,
            hui;//生命上限 
        public int[] tmp = new int[10];//临时数组 
        public string name;//名字 
        public void Xiaobin(string n, int i1, int i2, int i3, int i4, int i5, int i6, int i7, int i8, int i9, int i10, int i11, int i12, int i13, int i14, int i15, int i16, int i17, int f1, int f2, int f3)
        {
            //加载函数 
            name = n;
            gongji = i1;
            fanci = i2;
            xue = i3;
            gjcishu = i4;
            shecheng = i5;
            dun = i6;
            lingjcs = i7;
            dianshu = i8;
            xixue = i9;
            boolpojia = i10;
            paishu = i11;
            qianfeng = i12;
            boolji = i13;
            bihu = i14;
            dianji = i15;
            bian = i16;
            maxxue = i17;
            yuan = f1;
            ji = f2;
            hui = f3;
        }
        public xiaobin()
        {//构造函数 
            name = "";
            gongji = 0;
            fanci = 0;
            xue = 0;
            gjcishu = 0;
            shecheng = 0;
            dun = 0;
            lingjcs = 0;
            dianshu = 0;
            xixue = 0;
            boolpojia = 0;
            paishu = 0;
            qianfeng = 0;
            boolji = 0;
            bihu = 0;
            dianji = 0;
            bian = 0;
            maxxue = 0;
            for (int i = 0; i < 10; i++)
            {
                tmp[i] = 0;
            }
            yuan = 1;
            ji = 1;
            hui = 1;
            return;
        }
        public xiaobin copy()
        {
            xiaobin tmp = new xiaobin();
            tmp.name = name;
            tmp.gongji = gongji;
            tmp.fanci = fanci;
            tmp.xue = xue;
            tmp.gjcishu = gjcishu;
            tmp.shecheng = shecheng;
            tmp.dun = dun;
            tmp.lingjcs = lingjcs;
            tmp.dianshu = dianshu;
            tmp.xixue = xixue;
            tmp.boolpojia = boolpojia;
            tmp.paishu = paishu;
            tmp.qianfeng = qianfeng;
            tmp.boolji = boolji;
            tmp.bihu = bihu;
            tmp.dianji = dianji;
            tmp.bian = bian;
            tmp.maxxue = maxxue;
            tmp.yuan = yuan;
            tmp.ji = ji;
            tmp.hui = hui;
            tmp.tmp = this.tmp;
            return tmp;
        }
        public void yuannian()
        {//怨念绑定 
            common.F1[yuan](a, b, c);
            return;
        }
        public void jineng()
        {// 上阵绑定 
            common.F2[ji](a, b, c);
            return;
        }
        public void huihe()
        {//怒气绑定 
            common.F3[hui](a, b, c);
            return;
        }

    }
    class fashu
    {//法术类 
        public string name;//名字 
        public int
            dianshu,//点数 
            bian;//编号 
        public common.pfux p;//使用 
        public fashu()
        {//构造函数 
            name = "";
            p = common.tmpfa;
            dianshu = 0;
            bian = 0;
            return;
        }
        public void Fashu(string n, common.pfux tmpp, int d, int b)
        {//加载函数 
            name = n;
            p = tmpp;
            dianshu = d;
            bian = b;
        }
        public void use()
        {//使用函数 
            p(0, 0, 0);
            return;
        }
        public fashu copy()
        {
            fashu tmp = new fashu();
            tmp.name = name;
            tmp.p = p;
            tmp.dianshu = dianshu;
            tmp.bian = bian;
            return tmp;
        }
    };
    class wuqi
    {//武器类 
        public int
            naiju,//耐久 
            dianshu,//点数 
            bian,//编号 
            p;//使用
        public string name;//名字 

        public wuqi()
        {//构造函数 
            name = "武器:空";
            p = 0;
            dianshu = 0;
            naiju = 0;
            bian = 0;
            return;
        }
        public void Wuqi(string n, int tmpp, int d, int na, int b)
        {//加载函数 
            name = n;
            p = tmpp;
            dianshu = d;
            naiju = na;
            bian = b;
        }
        public void use()
        {//使用函数 
            common.WU[p](0, 0, 0);
            return;
        }
        public wuqi copy()
        {
            wuqi tmp = new wuqi();
            tmp.name = name;
            tmp.p = p;
            tmp.dianshu = dianshu;
            tmp.bian = bian;
            tmp.naiju = naiju;
            return tmp;
        }
    };
    class abc
    {//坐标三元组
        public int a, b, c;
        public abc(int aa, int bb, int cc)
        {
            a = aa; b = bb; c = cc;
        }
    };
}
