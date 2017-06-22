#include <REG51.H>
#include "char_code.h"

//--�ض��庯������--//
#define uchar unsigned char
#define uint unsigned int
#define ulong unsigned long

//--����SPIҪʹ�õ� IO--//
sbit MOSIO = P3 ^ 4;
sbit R_CLK = P3 ^ 5;
sbit S_CLK = P3 ^ 6;

//--���峣��--//
const uchar FLAG_SCROLL = 'l';
const uchar FLAG_SHOW = 'w';

//--�������--//
uchar bufferCount;  //���������һ����һ���ֽڣ�
uchar buffer[32];   //������
uchar buffered[32]; //���������
uchar flag;			//��ʾ��ʽ��־λ
uchar num;			//������ʾ����

//--����һ��ָ������ָ����--//
uchar *p[] = {tab1, tab2, tab3, tab4, tab5, tab6};

/*******************************************************************************
* �� �� ��         : HC595SendData
* ��������		   : ͨ��595�����ĸ��ֽڵ�����
* ��    ��         : BT3�����ĸ�595�����ֵ
*                  * BT2: ������595�����ֵ
*                  * BT1���ڶ���595�����ֵ
*                  * BT0����һ��595�����ֵ
* ��    ��         : ��
*******************************************************************************/

void HC595SendData(uchar BT3, uchar BT2, uchar BT1, uchar BT0)
{
	uchar i;

	//--���͵�һ���ֽ�--//
	for (i = 0; i < 8; i++)
	{
		MOSIO = BT3 >> 7; //�Ӹ�λ����λ
		BT3 <<= 1;

		S_CLK = 0;
		S_CLK = 1;
	}

	//--���͵�һ���ֽ�--//
	for (i = 0; i < 8; i++)
	{
		MOSIO = BT2 >> 7; //�Ӹ�λ����λ
		BT2 <<= 1;

		S_CLK = 0;
		S_CLK = 1;
	}

	//--���͵�һ���ֽ�--//
	for (i = 0; i < 8; i++)
	{
		MOSIO = BT1 >> 7; //�Ӹ�λ����λ
		BT1 <<= 1;
		S_CLK = 0;
		S_CLK = 1;
	}

	//--���͵�һ���ֽ�--//
	for (i = 0; i < 8; i++)
	{
		MOSIO = BT0 >> 7; //�Ӹ�λ����λ
		BT0 <<= 1;
		S_CLK = 0;
		S_CLK = 1;
	}

	//--���--//
	R_CLK = 0; //set dataline low
	R_CLK = 1; //Ƭѡ
	R_CLK = 0; //set dataline low
}

/*******************************************************************************
* ������         :UsartInit()
* ��������		   :���ô���
* ����           : ��
* ���         	 : ��
*******************************************************************************/
void UsartInit()
{
	SCON = 0X50; //����Ϊ������ʽ1
	TMOD = 0X20; //���ü�����������ʽ2
	PCON = 0X80; //�����ʼӱ�
	TH1 = 0XF3;  //��������ʼֵ���ã�ע�Ⲩ������4800��
	TL1 = 0XF3;
	ES = 1;  //�򿪽����ж�
	EA = 1;  //�����ж�
	TR1 = 1; //�򿪼�����
}

void ScrollShow(uchar *p[], uchar num)
{
	uint j;
	uchar k, ms;

	for (ms = 20; ms > 0; ms--) //�ƶ�����ʱ������
	{
		for (k = 0; k < 16; k++) //��ʾһ����
		{
			HC595SendData(~(*(p[0] + 2 * (k + j) + 1)), ~(*(p[0] + 2 * (k + j))), tab0[2 * k], tab0[2 * k + 1]); //��Ϊ��ģ���ȡ�������Ǹߵ�ƽ��Ч��������Ҫȡ��
		}

		//--����--//
		HC595SendData(0xff, 0xff, 0, 0); //����
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

	for (k = 0; k < 16; k++) //��ʾһ����
	{
		//--��Ϊ��ģ���ȡ�������Ǹߵ�ƽ��Ч��������Ҫȡ��--//
		HC595SendData(~(*(p + 2 * k + 1)), ~(*(p + 2 * k)),
					  tab0[2 * k], tab0[2 * k + 1]);
	}
}

void SendData(uchar ch[32])
{
	uchar i;
	for (i = 0; i < 32; i++)
	{
		SBUF = ch[i]; //�����յ������ݷ��뵽���ͼĴ���
		while (!TI)
		{
		}		//�ȴ������������
		TI = 0; //���������ɱ�־λ
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
* ������         : Usart() interrupt 4
* ��������		  : ����ͨ���жϺ���
* ����           : ��
* ���         	 : ��
*******************************************************************************/
void Usart() interrupt 4
{
	uchar buffer;
	if (RI)
	{
		buffer = SBUF; //���յ�������
		UpdateData(buffer);
		RI = 0; //��������жϱ�־λ
	}
}

/*******************************************************************************
* �� �� ��         : main
* ��������		   : ������
* ��    ��         : ��
* ��    ��         : ��
*******************************************************************************/

void Init()
{
	bufferCount = 0;	//���������ʼ��
	flag = FLAG_SCROLL; //��־��ʼ��
	num = 4;			//��ʼ��������ʾ����
	UsartInit();		//���ڳ�ʼ��
}

void main(void)
{
	Init(); //��ʼ������

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