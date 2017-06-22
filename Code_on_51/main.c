#include <REG51.H>
#include "char_code.h"

//--重定义函数变量--//
#define uchar unsigned char
#define uint unsigned int
#define ulong unsigned long

//--定义SPI要使用的 IO--//
sbit MOSIO = P3 ^ 4;
sbit R_CLK = P3 ^ 5;
sbit S_CLK = P3 ^ 6;

//--定义常量--//
const uchar FLAG_SCROLL = 'l';
const uchar FLAG_SHOW = 'w';

//--定义变量--//
uchar bufferCount;  //缓存个数（一个是一个字节）
uchar buffer[32];   //缓存区
uchar buffered[32]; //缓存完成区
uchar flag;			//显示方式标志位
uchar num;			//滚动显示个数

//--定义一个指针数据指向汉字--//
uchar *p[] = {tab1, tab2, tab3, tab4, tab5, tab6};

/*******************************************************************************
* 函 数 名         : HC595SendData
* 函数功能		   : 通过595发送四个字节的数据
* 输    入         : BT3：第四个595输出数值
*                  * BT2: 第三个595输出数值
*                  * BT1：第二个595输出数值
*                  * BT0：第一个595输出数值
* 输    出         : 无
*******************************************************************************/

void HC595SendData(uchar BT3, uchar BT2, uchar BT1, uchar BT0)
{
	uchar i;

	//--发送第一个字节--//
	for (i = 0; i < 8; i++)
	{
		MOSIO = BT3 >> 7; //从高位到低位
		BT3 <<= 1;

		S_CLK = 0;
		S_CLK = 1;
	}

	//--发送第一个字节--//
	for (i = 0; i < 8; i++)
	{
		MOSIO = BT2 >> 7; //从高位到低位
		BT2 <<= 1;

		S_CLK = 0;
		S_CLK = 1;
	}

	//--发送第一个字节--//
	for (i = 0; i < 8; i++)
	{
		MOSIO = BT1 >> 7; //从高位到低位
		BT1 <<= 1;
		S_CLK = 0;
		S_CLK = 1;
	}

	//--发送第一个字节--//
	for (i = 0; i < 8; i++)
	{
		MOSIO = BT0 >> 7; //从高位到低位
		BT0 <<= 1;
		S_CLK = 0;
		S_CLK = 1;
	}

	//--输出--//
	R_CLK = 0; //set dataline low
	R_CLK = 1; //片选
	R_CLK = 0; //set dataline low
}

/*******************************************************************************
* 函数名         :UsartInit()
* 函数功能		   :设置串口
* 输入           : 无
* 输出         	 : 无
*******************************************************************************/
void UsartInit()
{
	SCON = 0X50; //设置为工作方式1
	TMOD = 0X20; //设置计数器工作方式2
	PCON = 0X80; //波特率加倍
	TH1 = 0XF3;  //计数器初始值设置，注意波特率是4800的
	TL1 = 0XF3;
	ES = 1;  //打开接收中断
	EA = 1;  //打开总中断
	TR1 = 1; //打开计数器
}

void ScrollShow(uchar *p[], uchar num)
{
	uint j;
	uchar k, ms;

	for (ms = 20; ms > 0; ms--) //移动定格时间设置
	{
		for (k = 0; k < 16; k++) //显示一个字
		{
			HC595SendData(~(*(p[0] + 2 * (k + j) + 1)), ~(*(p[0] + 2 * (k + j))), tab0[2 * k], tab0[2 * k + 1]); //因为字模软件取的数组是高电平有效，所以列要取反
		}

		//--清屏--//
		HC595SendData(0xff, 0xff, 0, 0); //清屏
	}

	j++;
	if (j == ((num + 1) * 15))
	{
		j = 0;
	}
}

void Show(uchar *p)
{
	uchar k;

	for (k = 0; k < 16; k++) //显示一个字
	{
		//--因为字模软件取的数组是高电平有效，所以列要取反--//
		HC595SendData(~(*(p + 2 * k + 1)), ~(*(p + 2 * k)),
					  tab0[2 * k], tab0[2 * k + 1]);
	}
}

void SendData(uchar ch[32])
{
	uchar i;
	for (i = 0; i < 32; i++)
	{
		SBUF = ch[i]; //将接收到的数据放入到发送寄存器
		while (!TI)
		{
		}		//等待发送数据完成
		TI = 0; //清除发送完成标志位
	}
}

void UpdateData(uchar buf)
{
	uchar i;
	buffer[bufferCount++] = buf;
	if (bufferCount == 32)
	{
		flag = FLAG_SHOW;
		for (i = 0; i < 32; i++)
		{
			buffered[i] = buffer[i];
			buffer[i] = 0;
		}
		SendData(buffered);
		for (i = 0; i < 32; i++)
		{
			if (buffered[i] != 0xff)
			{
				break;
			}
			else
			{
				flag = FLAG_SCROLL;
			}
		}
		bufferCount = 0;
	}
}

/*******************************************************************************
* 函数名         : Usart() interrupt 4
* 函数功能		  : 串口通信中断函数
* 输入           : 无
* 输出         	 : 无
*******************************************************************************/
void Usart() interrupt 4
{
	uchar buffer;
	if (RI)
	{
		buffer = SBUF; //接收到的数据
		UpdateData(buffer);
		RI = 0; //清除接收中断标志位
	}
}

/*******************************************************************************
* 函 数 名         : main
* 函数功能		   : 主函数
* 输    入         : 无
* 输    出         : 无
*******************************************************************************/

void Init()
{
	bufferCount = 0;	//缓存个数初始化
	flag = FLAG_SCROLL; //标志初始化
	num = 4;			//初始化滚动显示个数
	UsartInit();		//串口初始化
}

void main(void)
{
	Init(); //初始化程序

	while (1)
	{
		if (flag == FLAG_SCROLL)
		{
			ScrollShow(p, num);
		}
		else if (flag == FLAG_SHOW)
		{
			Show(buffered);
		}
	}
}