using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace 退火电源2._0
{
    class CWorkFlow
    {
        /// <summary>
        /// 显示状态
        /// </summary>
        public static string DisplayStuts(int timeAdd,int workStep,int workSteps,float dianLiu,float dianYa,float dianZu)
        {
            //步骤：0/5,电流：0A，电压：0V，电阻：0Ω
            string str = "步骤：" + workStep.ToString() + "/" + workSteps;
            str = str + " " + timeAdd.ToString() +"S";
            str = str + ",电流：" + dianLiu.ToString();
            str = str + "mA，电压：" + dianYa.ToString();
            str = str + "mV，电阻：" + dianZu.ToString() + "Ω";
            return str;
        }
        //读取数据
        public static void ReadDataOnTime(int i,Form1 form1)
        {
            if (i == 0)
            {
                //读开关量
                byte[] buffer = CModbus.F2(0x01, 0x01, 0x00, 0x02);
                form1.SerialSendData(buffer);
            }
            else
            {
                //读模拟量
                byte[] buffer= CModbus.F4(0x03, 0x00, 0x00, 0x03);
                form1.SerialSendData(buffer);
            }
        }
        /// <summary>
        /// 开始命令
        /// </summary>
        /// <param name="d">计时</param>
        /// <param name="data">数据</param>
        public static void StartCommand(int d,byte[] data)
        {
            if (d == 0)
            {
                CModbus.F16(0x02, 0x00, 0x00, 0x03, 0x06, data);
            }
            if (d == 1)
            {
                CModbus.F5(0x00, 0x00, 0xff, 0x00);
            }
        }
        //停止命令
        public static void StopCommand()
        {
            CModbus.F5(0x00, 0x00, 0x00, 0x00);
        }
        //进入下一步
        public static void GoToNextStep(int d,Form1 form1)
        {
            byte[] data = new byte[6];

            data[0] = Convert.ToByte(form1.PinLv[d+1] / 256);
            data[1] = Convert.ToByte(form1.PinLv[d + 1] % 256);
            data[2] = Convert.ToByte(form1.DianLiu[d+1] / 256);
            data[3] = Convert.ToByte(form1.DianLiu[d+1] % 256);
            data[4] = Convert.ToByte(form1.ZhanKongBi[d+1] / 256);
            data[5] = Convert.ToByte(form1.ZhanKongBi[d+1] % 256);

            if (form1.StartCommandCoilIsOver == false || form1.StartCommandRegIsOver == false)
            {
                StartCommand(d, data);
            }
        }
        public static void GoToStep(int step,Form1 form1)
        {
            int pinLv = form1.PinLv[step];
            int dianLiu = form1.DianLiu[step];
            int zhanKongBi = form1.ZhanKongBi[step];
            byte pinLvHi = Convert.ToByte(pinLv/256);
            byte pinLvLow = Convert.ToByte(pinLv%256);
            byte dianLiuHi = Convert.ToByte(dianLiu/256);
            byte dianLiuLow = Convert.ToByte(dianLiu%256);
            byte zhanKongBiHi = Convert.ToByte(zhanKongBi/256);
            byte zhanKongBiLow = Convert.ToByte(zhanKongBi%256);

            byte[] data = new byte[6];
            data[0] = pinLvHi;
            data[1] = pinLvLow;
            data[2] = dianLiuHi;
            data[3] = dianLiuLow;
            data[4] = zhanKongBiHi;
            data[5] = zhanKongBiLow;
            byte[] buffer = CModbus.F16(0x02, 0x00, 0x00, 0x03, 0x06, data);

            form1.SerialSendData(buffer);
            Thread.Sleep(150);

            while (!form1.Response(16))
            {
                form1.SerialSendData(buffer);
                Thread.Sleep(150);
            }


            byte[] buffer2 = CModbus.F5(0x00, 0x00, 0xff, 0x00);
            form1.SerialSendData(buffer2);
            Thread.Sleep(150);
            while (!form1.Response(5))
            {
                form1.SerialSendData(buffer2);
                Thread.Sleep(150);
            }
            
        }
        //完成工作
        public static void FinishWork(Form1 form1)
        {
            byte[] buffer2 = CModbus.F5(0x00, 0x00, 0x00, 0x00);
            form1.SerialSendData(buffer2);
            Thread.Sleep(150);
            while (!form1.Response(5))
            {
                form1.SerialSendData(buffer2);
                Thread.Sleep(150);
            }
        }
    }
}
