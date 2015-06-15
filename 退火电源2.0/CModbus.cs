using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 退火电源2._0
{
    class CModbus
    {
        public CModbus()
        {
        }
        public static byte slaryID = 0x01;

        #region 发送数据
        /// <summary>
        /// 读线圈状态
        /// </summary>
        /// <param name="startAddrHi"></param>
        /// <param name="startAddrLow"></param>
        /// <param name="noOfRegHi"></param>
        /// <param name="noOfRegLow"></param>
        public static byte[] F1(byte startAddrHi, byte startAddrLow, byte noOfRegHi, byte noOfRegLow)
        {
            byte[] buffer = new byte[8];
            buffer[0] = slaryID;
            buffer[1] = 1;
            buffer[2] = startAddrHi;
            buffer[3] = startAddrLow;
            buffer[4] = noOfRegHi;
            buffer[5] = noOfRegLow;
            buffer[6] = 0xff;
            buffer[7] = 0xff;

            return CModbus.CRCCheck(buffer);
        }
        /// <summary>
        /// 读输入状态
        /// </summary>
        /// <param name="startAddrHi"></param>
        /// <param name="startAddrLow"></param>
        /// <param name="noOfRegHi"></param>
        /// <param name="noOfRegLow"></param>
        public static byte[] F2(byte startAddrHi, byte startAddrLow, byte noOfRegHi, byte noOfRegLow)
        {
            byte[] buffer = new byte[8];
            buffer[0] = slaryID;
            buffer[1] = 2;
            buffer[2] = startAddrHi;
            buffer[3] = startAddrLow;
            buffer[4] = noOfRegHi;
            buffer[5] = noOfRegLow;
            buffer[6] = 0xff;
            buffer[7] = 0xff;

            return CModbus.CRCCheck(buffer);
        }
        /// <summary>
        /// 读输入寄存器
        /// </summary>
        /// <param name="startAddrHi"></param>
        /// <param name="startAddrLow"></param>
        /// <param name="noOfRegHi"></param>
        /// <param name="noOfRegLow"></param>
        public static byte[] F4(byte startAddrHi, byte startAddrLow, byte noOfRegHi, byte noOfRegLow)
        {
            byte[] buffer = new byte[8];
            buffer[0] = slaryID;
            buffer[1] = 4;
            buffer[2] = startAddrHi;
            buffer[3] = startAddrLow;
            buffer[4] = noOfRegHi;
            buffer[5] = noOfRegLow;
            buffer[6] = 0xff;
            buffer[7] = 0xff;

            return CModbus.CRCCheck(buffer);
        }
        /// <summary>
        /// 强制单个线圈
        /// </summary>
        /// <param name="startAddrHi"></param>
        /// <param name="startAddrLow"></param>
        /// <param name="noOfRegHi"></param>
        /// <param name="noOfRegLow"></param>
        public static byte[] F5(byte startAddrHi, byte startAddrLow, byte noOfRegHi, byte noOfRegLow)
        {
            byte[] buffer = new byte[8];
            buffer[0] = slaryID;
            buffer[1] = 5;
            buffer[2] = startAddrHi;
            buffer[3] = startAddrLow;
            buffer[4] = noOfRegHi;
            buffer[5] = noOfRegLow;
            buffer[6] = 0xff;
            buffer[7] = 0xff;

            return CModbus.CRCCheck(buffer);
        }
        /// <summary>
        /// 写多个寄存器
        /// </summary>
        /// <param name="startAddrHi">地址高位</param>
        /// <param name="starAddrLow">地址低位</param>
        /// <param name="noOfRegHi">寄存器数量高位</param>
        /// <param name="noOfRegLow">寄存器数量低位</param>
        /// <param name="byteCount">数据byte个数</param>
        /// <param name="data">数据</param>
        public static byte[] F16(byte startAddrHi, byte starAddrLow, byte noOfRegHi, byte noOfRegLow, byte byteCount, byte[] data)
        {
            byte[] buffer = new byte[9 + data.Length];
            buffer[0] = slaryID;
            buffer[1] = 16;
            buffer[2] = startAddrHi;
            buffer[3] = starAddrLow;
            buffer[4] = noOfRegHi;
            buffer[5] = noOfRegLow;
            buffer[6] = byteCount;
            for (int i = 0; i < byteCount; i++)
            {
                buffer[i + 7] = data[i];
            }
            buffer[9 + data.Length - 2] = 0xff;
            buffer[9 + data.Length - 1] = 0xff;

            return CModbus.CRCCheck(buffer);
        } 
        #endregion

        #region 效验数据
        /// <summary>
        /// CRC效验
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public static byte[] CRCCheck(byte[] buffer)
        {
            int i = 0;
            UInt16 iIndex = 0x0000;
            byte ucCRCHi = 0xFF;
            byte ucCRCLo = 0xFF;

            int lenght = buffer.Length - 2;

            while (lenght-- > 0)
            {
                iIndex = (UInt16)(ucCRCLo ^ buffer[i++]);
                //低效验位
                ucCRCLo = (byte)(ucCRCHi ^ aucCRCHi[iIndex]);
                //高效验位
                ucCRCHi = aucCRCLo[iIndex];
            }

            buffer[buffer.Length - 2] = ucCRCLo;
            buffer[buffer.Length - 1] = ucCRCHi;

            return buffer;
        }
        private static readonly byte[] aucCRCHi = {
            0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41,
            0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40,
            0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41,
            0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41,
            0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41,
            0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40,
            0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40,
            0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40,
            0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41,
            0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40,
            0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41,
            0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 
            0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41,
            0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 
            0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41,
            0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41,
            0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41, 
            0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40,
            0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41,
            0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41,
            0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41,
            0x00, 0xC1, 0x81, 0x40
        };
        private static readonly byte[] aucCRCLo = {
            0x00, 0xC0, 0xC1, 0x01, 0xC3, 0x03, 0x02, 0xC2, 0xC6, 0x06, 0x07, 0xC7,
            0x05, 0xC5, 0xC4, 0x04, 0xCC, 0x0C, 0x0D, 0xCD, 0x0F, 0xCF, 0xCE, 0x0E,
            0x0A, 0xCA, 0xCB, 0x0B, 0xC9, 0x09, 0x08, 0xC8, 0xD8, 0x18, 0x19, 0xD9,
            0x1B, 0xDB, 0xDA, 0x1A, 0x1E, 0xDE, 0xDF, 0x1F, 0xDD, 0x1D, 0x1C, 0xDC,
            0x14, 0xD4, 0xD5, 0x15, 0xD7, 0x17, 0x16, 0xD6, 0xD2, 0x12, 0x13, 0xD3,
            0x11, 0xD1, 0xD0, 0x10, 0xF0, 0x30, 0x31, 0xF1, 0x33, 0xF3, 0xF2, 0x32,
            0x36, 0xF6, 0xF7, 0x37, 0xF5, 0x35, 0x34, 0xF4, 0x3C, 0xFC, 0xFD, 0x3D,
            0xFF, 0x3F, 0x3E, 0xFE, 0xFA, 0x3A, 0x3B, 0xFB, 0x39, 0xF9, 0xF8, 0x38, 
            0x28, 0xE8, 0xE9, 0x29, 0xEB, 0x2B, 0x2A, 0xEA, 0xEE, 0x2E, 0x2F, 0xEF,
            0x2D, 0xED, 0xEC, 0x2C, 0xE4, 0x24, 0x25, 0xE5, 0x27, 0xE7, 0xE6, 0x26,
            0x22, 0xE2, 0xE3, 0x23, 0xE1, 0x21, 0x20, 0xE0, 0xA0, 0x60, 0x61, 0xA1,
            0x63, 0xA3, 0xA2, 0x62, 0x66, 0xA6, 0xA7, 0x67, 0xA5, 0x65, 0x64, 0xA4,
            0x6C, 0xAC, 0xAD, 0x6D, 0xAF, 0x6F, 0x6E, 0xAE, 0xAA, 0x6A, 0x6B, 0xAB, 
            0x69, 0xA9, 0xA8, 0x68, 0x78, 0xB8, 0xB9, 0x79, 0xBB, 0x7B, 0x7A, 0xBA,
            0xBE, 0x7E, 0x7F, 0xBF, 0x7D, 0xBD, 0xBC, 0x7C, 0xB4, 0x74, 0x75, 0xB5,
            0x77, 0xB7, 0xB6, 0x76, 0x72, 0xB2, 0xB3, 0x73, 0xB1, 0x71, 0x70, 0xB0,
            0x50, 0x90, 0x91, 0x51, 0x93, 0x53, 0x52, 0x92, 0x96, 0x56, 0x57, 0x97,
            0x55, 0x95, 0x94, 0x54, 0x9C, 0x5C, 0x5D, 0x9D, 0x5F, 0x9F, 0x9E, 0x5E,
            0x5A, 0x9A, 0x9B, 0x5B, 0x99, 0x59, 0x58, 0x98, 0x88, 0x48, 0x49, 0x89,
            0x4B, 0x8B, 0x8A, 0x4A, 0x4E, 0x8E, 0x8F, 0x4F, 0x8D, 0x4D, 0x4C, 0x8C,
            0x44, 0x84, 0x85, 0x45, 0x87, 0x47, 0x46, 0x86, 0x82, 0x42, 0x43, 0x83,
            0x41, 0x81, 0x80, 0x40
        }; 
        #endregion

        #region 接收数据
        public static bool ModbusDataHandle(byte[] send,byte[] buffer,Form1 form1)
        {           
            switch (buffer[1])
            {
                case 1:
                    //Function01(buffer,form1);
                    break;
                case 2:
                    Function02(buffer,form1);
                    break;
                case 3:
                    //Function03(buffer);
                    break;
                case 4:
                    Function04(buffer,form1);
                    break;
                case 5:
                    //Function05(buffer);
                    break;
                case 6:
                    //Function06(buffer);
                    break;
                case 8:
                    //Function08(buffer);
                    break;
                case 16:
                    Function16(buffer, form1);
                    break;
                case 17:
                    //Function11(buffer);
                    break;
                case 18:
                    //Function12(buffer);
                    break;
                case 0x21:
                    //Function15(buffer);
                    break;
                case 0x23:
                    
                    break;
                case 0x17:
                    //Function17(buffer);
                    break;
                default:
                    break;
            }
            if (send[0] == slaryID && send[1] == buffer[1])
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //读取DI
        public static void Function02(byte[] buffer, Form1 form1)
        {
            int a = buffer[3] & 3;

            switch (a)
            {
                case 0:
                    form1.SKaiLu = false;
                    form1.SDuanlu = false;
                    break;
                case 1:
                    form1.SKaiLu = true;
                    form1.SDuanlu = false;
                    break;
                case 2:
                    form1.SKaiLu = false;
                    form1.SDuanlu = true;
                    break;
                case 3:
                    form1.SKaiLu = true;
                    form1.SDuanlu = true;
                    break;
            }
        }
        //读取DI
        public static void Function04(byte[] buffer, Form1 form1)
        {
            //赋值变量
            int a1 = (buffer[3]*256 +buffer[4]);
            form1.CurrentDianLiu = a1 / 10.0f;
            form1.CurrentDianYa = (buffer[5] * 256 + buffer[6]) / 10.0f;
            form1.CurrentDianZu = (buffer[7] * 256 + buffer[8]) / 10.0f;
            if(form1.CurrentStep<0)
            {
                return;
            }
            //保存数据
            string strConn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=.\DataBase.accdb;Persist Security Info=False;";
            string strSql = "INSERT INTO 退火记录表 ( 非晶丝编号, 设置频率,设置电流,设置占空比,电流,电压,电阻 ) VALUES ('" + form1.FeiJingSiSn + "',";
            strSql = strSql + form1.PinLv[form1.CurrentStep]/10.0 + ",";
            strSql = strSql + form1.DianLiu[form1.CurrentStep]/10.0 + ",";
            strSql = strSql + form1.ZhanKongBi[form1.CurrentStep]/10.0 + ",";
            strSql = strSql + form1.CurrentDianLiu + ",";
            strSql = strSql + form1.CurrentDianYa + ",";
            strSql = strSql + form1.CurrentDianZu + ")";
            int i = CAccessHelper.Run_SQL(strSql, strConn);
        }
        //设置多个寄存器反馈
        public static void Function16(byte[] buffer, Form1 form1)
        {
            //PID设置反馈
            if (buffer[2] == 0x02 && buffer[3] == 0x03 && buffer[4] == 0x00 && buffer[5] == 0x03)
            {
                form1.Kp = form1.SendData[7] * 256 + form1.SendData[8];
                form1.Ki = form1.SendData[9] * 256 + form1.SendData[10];
                form1.Kd = form1.SendData[11] * 256 + form1.SendData[12];
            }

            //开路短路设置反馈
            if (buffer[2] == 0x02 && buffer[3] == 0x06 && buffer[4] == 0x00 && buffer[5] == 0x02)
            {
                form1.KaiLu = form1.SendData[7] * 256 + form1.SendData[8];
                form1.DuanLu = form1.SendData[9] * 256 + form1.SendData[10];
            }
        }
        #endregion
    }
}
